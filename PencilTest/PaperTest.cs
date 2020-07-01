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
    }
}