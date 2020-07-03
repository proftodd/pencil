namespace Pencil
{
    public class Paper
    {
        private string text;

        public Paper(string text)
        {
            this.text = text;
        }

        public Paper() : this("") {}

        public string read()
        {
            return text;
        }

        public void write(string text)
        {
            this.text = this.text + text;
        }

        public void erase(int position)
        {
            if (position >= 0 && position < text.Length) {
                text = text.Substring(0, position) + ' ' + text.Substring(position + 1);
            }
        }
    }
}