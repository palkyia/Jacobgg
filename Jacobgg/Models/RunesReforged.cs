namespace Jacobgg.Models
{
    //public class RunesReforged
    //{
    //    public List<RuneTree> RuneTrees { get; set; }
    //}

    public class RuneTree
    {
        public int id { get; set; }
        public string key { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public List<Slot> slots { get; set; }
    }

    public class Slot
    {
        public List<Rune> runes { get; set; }
    }

    public class Rune
    {
        public int id { get; set; }
        public string key { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
    }



}
