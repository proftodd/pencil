using System.Linq;
using NUnit.Framework;

namespace Pencil
{
    [TestFixture]
    public class PencilTest
    {
        [Test, Category("Creation")]
        public void pencil_created_with_no_parameters_has_default_durability()
        {
            var pencil = new Pencil();

            Assert.AreEqual(Pencil.DEFAULT_DURABILITY, pencil.durability);
        }

        [Test, Category("Creation")]
        public void pencil_created_with_durability_has_that_durability()
        {
            var durability = 42;
            var pencil = new Pencil(durability);

            Assert.AreEqual(durability, pencil.durability);
        }

        [Test, Category("Write")]
        public void can_write_to_paper()
        {
            var text = "Hi there";
            Paper paper = new Paper();
            Pencil pencil = new Pencil();
            pencil.write(paper, text);
            Assert.AreEqual(text, paper.read());
        }

        [Test, Category("Write")]
        public void can_append_text_to_paper()
        {
            var prevText = "She sells sea shells";
            var newText = " down by the seashore";
            Paper paper = new Paper(prevText);
            Pencil pencil = new Pencil();

            pencil.write(paper, newText);

            Assert.AreEqual(prevText + newText, paper.read());
        }

        [Test, Category("Point Degradation")]
        public void whitespace_does_not_decrease_durability()
        {
            string text = $"all lowercase   with{'\n'}whitespace";
            var wsQuery = from ch in text where char.IsWhiteSpace(ch) select ch;
            var numWhitespaceChars = wsQuery.Count();
            var paper = new Paper();
            var pencil = new Pencil();

            pencil.write(paper, text);

            Assert.AreEqual(text, paper.read());
            Assert.AreEqual(Pencil.DEFAULT_DURABILITY - text.Length + numWhitespaceChars, pencil.durability);
        }

        [Test, Category("Point Degradation")]
        public void lowercase_characters_decrease_durability_by_one()
        {
            var text = "text";
            var paper = new Paper();
            var pencil = new Pencil(4);

            pencil.write(paper, text);

            Assert.AreEqual(text, paper.read());
            Assert.AreEqual(0, pencil.durability);
        }

        [Test, Category("Point Degradation")]
        public void uppercase_characters_decrease_durability_by_two()
        {
            var text = "Text";
            var expectedText = "Tex ";
            var paper = new Paper();
            var pencil = new Pencil(4);

            pencil.write(paper, text);

            Assert.AreEqual(expectedText, paper.read());
            Assert.AreEqual(0, pencil.durability);
        }

        [Test, Category("Point Degradation")]
        public void handles_nonascii_unicode_characters()
        {
            var text = "\u00C6sop wrote f\u00E0bles";
            var paper = new Paper();
            var pencil = new Pencil(20);

            pencil.write(paper, text);

            Assert.AreEqual(text, paper.read());
            Assert.AreEqual(4, pencil.durability);
        }

        [Test, Category("Sharpen")]
        public void can_sharpen_pencil()
        {
            var pencil = new Pencil();

            pencil.write(new Paper(), "some text");
            pencil.sharpen();

            Assert.AreEqual(pencil.originalDurability, pencil.durability);
        }

        [Test, Category("Sharpen")]
        public void sharpening_shortens_length()
        {
            var originalLength = 5;
            var newLength = 4;
            var pencil = new Pencil(Pencil.DEFAULT_DURABILITY, originalLength);

            pencil.write(new Paper(), "some text");
            pencil.sharpen();

            Assert.AreEqual(newLength, pencil.length);
        }

        [Test, Category("Sharpen")]
        public void if_length_is_zero_cannot_sharpen()
        {
            var pencil = new Pencil(Pencil.DEFAULT_DURABILITY, 0);

            pencil.write(new Paper(), "some text");
            pencil.sharpen();

            Assert.AreNotEqual(pencil.durability, pencil.originalDurability);
        }

        [Test, Category("Erase")]
        public void it_erases_last_instance_of_string_on_paper()
        {
            var prevText = "How much wood would a woodchuck chuck if a woodchuck could chuck wood?";
            var firstNewText = "How much wood would a woodchuck chuck if a woodchuck could       wood?";
            var secondNewText = "How much wood would a woodchuck chuck if a wood      could       wood?";

            var paper = new Paper(prevText);
            var pencil = new Pencil();

            pencil.erase(paper, "chuck");
            Assert.AreEqual(firstNewText, paper.read());

            pencil.erase(paper, "chuck");
            Assert.AreEqual(secondNewText, paper.read());
        }

        [Test, Category("Erase")]
        public void it_does_nothing_if_text_not_found_on_paper()
        {
            var text = "How much wood would a woodchuck chuck if a woodchuck could chuck wood?";

            var paper = new Paper(text);
            var pencil = new Pencil();

            pencil.erase(paper, "hoohah");

            Assert.AreEqual(text, paper.read());
        }

        [Test, Category("Erase")]
        public void erasing_decreases_eraser_durability()
        {
            var paper = new Paper("some text");
            var pencil = new Pencil();
            var originalEraser = pencil.eraser;

            pencil.erase(paper, "text");

            Assert.IsTrue(pencil.eraser < originalEraser);
        }

        [Test, Category("Erase")]
        public void erasing_whitespace_does_not_decrease_eraser_durability()
        {
            var paper = new Paper("some text");
            var pencil = new Pencil();
            var originalEraser = pencil.eraser;

            pencil.erase(paper, " ");

            Assert.AreEqual(pencil.eraser, originalEraser);
        }

        [Test, Category("Erase")]
        public void cannot_erase_if_eraser_durability_is_exhausted()
        {
            var paper = new Paper("Buffalo Bill");
            var pencil = new Pencil(eraser: 3);

            pencil.erase(paper, "Bill");

            Assert.AreEqual("Buffalo B   ", paper.read());
        }

        [Test, Category("Editing")]
        public void can_insert_text_to_paper()
        {
            var prevText = "An       a day keeps the doctor away";
            var insertText = "apple";
            var newText = $"An {insertText} a day keeps the doctor away";

            var paper = new Paper(prevText);
            var pencil = new Pencil();
            pencil.write(paper, insertText, 3);

            Assert.AreEqual(newText, paper.read());
        }
    }
}