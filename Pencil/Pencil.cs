using System;
using System.Text;

namespace Pencil
{
    public class Pencil
    {
        public static readonly int DEFAULT_DURABILITY = 40_000;
        public int durability { private set; get; }

        public Pencil() : this(DEFAULT_DURABILITY) {}

        public Pencil(int durability)
        {
            this.durability = durability;
        }

        // NOTE: I am assuming Unicode characters
        public void write(Paper paper, string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Char ch in text)
            {
                if (Char.IsWhiteSpace(ch))
                {
                    sb.Append(ch);
                }
                else if (Char.IsUpper(ch))
                {
                    if (durability > 1)
                    {
                        durability = durability - 2;
                        sb.Append(ch);
                    } else {
                        sb.Append(' ');
                    }
                } else
                {
                    if (durability > 0)
                    {
                        durability = durability - 1;
                        sb.Append(ch);
                    } else {
                        sb.Append(' ');
                    }
                }
            }
            paper.write(sb.ToString());
        }
    }
}