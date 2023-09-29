namespace AsciiImage
{
    public interface IGradient
    {
        public string Alphabet { get;  }

        public Range GetRange()
        {
            return new Range(0, Alphabet.Length - 1);
        }

        public char this[int i]
        {
            get { return Alphabet[i]; }
        }
    }
}
