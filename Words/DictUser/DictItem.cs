using System.Xml.Serialization;

namespace Words.DictUser
{
    public class DictItem
    {
        [XmlAttribute(AttributeName = "Word")]
        public string Word;
        
        [XmlAttribute(AttributeName = "Approved")]
        public bool Approved;
       
        [XmlAttribute()]
        public int LongWord;
       
        [XmlAttribute()]
        public int LongCount;
        
        [XmlText()]
        public string Description;
    }
}
