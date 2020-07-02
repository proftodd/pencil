using NUnit.Framework;

namespace Pencil
{
    [TestFixture]
    public class PencilTest
    {
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
    }
}