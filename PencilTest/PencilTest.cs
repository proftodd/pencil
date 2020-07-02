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
    }
}