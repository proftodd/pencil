using System.Linq;
using NUnit.Framework;

namespace Pencil
{
    [TestFixture]
    public class PencilTest
    {
        [Test]
        public void pencil_created_with_no_parameters_has_default_durability()
        {
            var pencil = new Pencil();

            Assert.AreEqual(Pencil.DEFAULT_DURABILITY, pencil.durability);
        }

        [Test]
        public void pencil_created_with_durability_has_that_durability()
        {
            var durability = 42;
            var pencil = new Pencil(durability);

            Assert.AreEqual(durability, pencil.durability);
        }

        [Test]
        public void can_write_to_paper()
        {
            var text = "Hi there";
            Paper paper = new Paper();
            Pencil pencil = new Pencil();
            pencil.write(paper, text);
            Assert.AreEqual(text, paper.read());
        }

        [Test]
        public void can_append_text_to_paper()
        {
            var prevText = "She sells sea shells";
            var newText = " down by the seashore";
            Paper paper = new Paper(prevText);
            Pencil pencil = new Pencil();

            pencil.write(paper, newText);

            Assert.AreEqual(prevText + newText, paper.read());
        }

        [Test]
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

        [Test]
        public void lowercase_characters_decrease_durability_by_one()
        {
            var text = "text";
            var paper = new Paper();
            var pencil = new Pencil(4);

            pencil.write(paper, text);

            Assert.AreEqual(text, paper.read());
            Assert.AreEqual(0, pencil.durability);
        }

        [Test]
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

        [Test]
        public void handles_nonascii_unicode_characters()
        {
            var text = "\u00C6sop wrote f\u00E0bles";
            var paper = new Paper();
            var pencil = new Pencil(20);

            pencil.write(paper, text);

            Assert.AreEqual(text, paper.read());
            Assert.AreEqual(4, pencil.durability);
        }
    }
}