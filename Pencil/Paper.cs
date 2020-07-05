using System;
using System.Text;

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
            write(text, this.text.Length);
        }

        public void write(string text, int position)
        {
            if (position < 0)
            {
                return;
            }
            var builder = new StringBuilder(this.text);
            for (int i = 0; i < text.Length; )
            {
                if (position + i > builder.Length)
                {
                    builder.Append(' ');
                }
                else if (position + i == builder.Length)
                {
                    builder.Append(text[i]);
                    ++i;
                }
                else if (Char.IsWhiteSpace(builder[position + i]))
                {
                    builder[position + i] = text[i];
                    ++i;
                } else {
                    builder[position + i] = '@';
                    ++i;
                }
            }
            this.text = builder.ToString();
        }

        public void erase(int position)
        {
            if (position >= 0 && position < text.Length) {
                text = text.Substring(0, position) + ' ' + text.Substring(position + 1);
            }
        }
    }
}