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

        [Test, Category("Erase")]
        public void can_erase_characters()
        {
            var prevText = "Hello";
            var newText = "Hel o";

            var paper = new Paper(prevText);
            paper.erase(3);

            Assert.AreEqual(newText, paper.read());
        }

        [Test, Category("Erase")]
        public void does_nothing_if_instructed_to_erase_to_left_of_text()
        {
            var text = "Hello";

            var paper = new Paper(text);
            paper.erase(-1);

            Assert.AreEqual(text, paper.read());
        }

        [Test, Category("Erase")]
        public void does_nothing_if_instructed_to_erase_to_right_of_text()
        {
            var text = "Hello";

            var paper = new Paper(text);
            paper.erase(5);

            Assert.AreEqual(text, paper.read());
        }

        [Test, Category("Erase")]
        public void erases_first_character_of_text()
        {
            var prevText = "Hello";
            var newText = " ello";

            var paper = new Paper(prevText);
            paper.erase(0);

            Assert.AreEqual(newText, paper.read());
        }

        [Test, Category("Erase")]
        public void erases_last_character_of_text()
        {
            var prevText = "Hello";
            var newText = "Hell ";

            var paper = new Paper(prevText);
            paper.erase(4);

            Assert.AreEqual(newText, paper.read());
        }
    }
}