using System;

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
    }
}