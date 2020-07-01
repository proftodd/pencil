using NUnit.Framework;

namespace Pencil
{
    [TestFixture]
    public class PaperTest
    {
        [Test]
        public void can_create_blank_paper()
        {
            Paper paper = new Paper();
            Assert.AreEqual("", paper.read());
        }

        [Test]
        public void can_create_paper_with_text()
        {
            string text = "Hi there";
            Paper paper = new Paper(text);
            Assert.AreEqual(text, paper.read());
        }

        [Test]
        public void can_write_text_to_paper()
        {
            string prevText = "Hello";
            string newText = " there";
            string finalText = prevText + newText;

            Paper paper = new Paper(prevText);
            paper.write(newText);

            Assert.AreEqual(finalText, paper.read());
        }
    }
}