using System;
using System.Text;

namespace Pencil
{
    public class Pencil
    {
        public const int DEFAULT_LENGTH = 10;
        public const int DEFAULT_DURABILITY = 40_000;

        public int originalDurability { get; }
        public int durability { private set; get; }
        public int length { private set; get; }

        public Pencil(int durability = DEFAULT_DURABILITY, int length = 10)
        {
            this.originalDurability = durability;
            this.durability = durability;
            this.length = length;
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

        public void sharpen()
        {
            if (length > 0)
            {
                durability = originalDurability;
                --length;
            }
        }

        public void erase(Paper paper, string text)
        {
            int found = paper.read().LastIndexOf(text);
            if (found > 0)
            {
                for (int i = 0; i < text.Length; ++i) {
                    paper.erase(i + found);
                }
            }
        }
    }
}