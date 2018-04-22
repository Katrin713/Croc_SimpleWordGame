namespace Words
{
    class GetWord
    {
        public Definition[] def { get; set; }
    }

    class Definition
    {
        public string text { get; set; }
        public string pos { get; set; }
        public Translate[] tr { get; set; }
    }
    class Translate
    {
        public string text { get; set; }
        public string pos { get; set; }
        public Synonims[] syn { get; set; }
    }
    class Synonims
    {
        public string text { get; set; }
        public string pos { get; set; }
    }
}
