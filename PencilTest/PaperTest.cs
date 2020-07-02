using NUnit.Framework;

namespace Pencil
{
    [TestFixture]
    public class PaperTest
    {
        [Test, Category("Creation")]
        public void can_create_blank_paper()
        {
            Paper paper = new Paper();
            Assert.AreEqual("", paper.read());
        }

        [Test, Category("Creation")]
        public void can_create_paper_with_text()
        {
            var text = "Hi there";
            Paper paper = new Paper(text);
            Assert.AreEqual(text, paper.read());
        }

        [Test, Category("Write")]
        public void can_write_text_to_paper()
        {
            var prevText = "Hello";
            var newText = " there";
            var finalText = prevText + newText;

            Paper paper = new Paper(prevText);
            paper.write(newText);

            Assert.AreEqual(finalText, paper.read());
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
    }
}