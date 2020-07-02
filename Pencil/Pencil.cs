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

        // NOTE: I am assuming only ASCII characters
        public void write(Paper paper, string text)
        {
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < text.Length; ++i)
            {
                if (text[i] == ' ' || text[i] == '\t' || text[i] == '\n')
                {
                    sb.Append(text[i]);
                }
                else if (text[i] >= 'A' && text[i] <= 'Z')
                {
                    if (durability > 1)
                    {
                        durability = durability - 2;
                        sb.Append(text[i]);
                    } else {
                        sb.Append(' ');
                    }
                } else
                {
                    if (durability > 0)
                    {
                        durability = durability - 1;
                        sb.Append(text[i]);
                    } else {
                        sb.Append(' ');
                    }
                }
            }
            paper.write(sb.ToString());
        }
    }
}