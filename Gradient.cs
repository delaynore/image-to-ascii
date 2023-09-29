namespace AsciiImage
{
    public class Gradient : IGradient
    {
        public string Alphabet { get; init; }
        
        private Gradient(string aplhabet)
        {
            Alphabet = aplhabet;
        }

        private const string _default = @" .:!/r(l1Z4H9W8$@\";
        private static readonly string _defaultReversed = string.Join("", _default.Reverse());
        
        public static Gradient Default => new(_default);
        
        public static Gradient WhiteTheme => new(_defaultReversed);
        
        public static Gradient BlackTheme => Default;

        public static Gradient Make(string aplhabet) => new Gradient(aplhabet);

    }
}
