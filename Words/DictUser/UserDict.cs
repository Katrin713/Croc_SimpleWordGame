using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Words.DictUser
{
   [Serializable, XmlRoot("Dict")]
    public class UserDict
    {
        [XmlElement(ElementName = "Item")]
        public DictItem[] dictItem;
        public static UserDict Load(string name)
        {
            XmlSerializer ser = new XmlSerializer(typeof(UserDict));

            UserDict dw;
            using (XmlReader rdr = XmlReader.Create(name))
            {
                dw = (UserDict)ser.Deserialize(rdr);
            }
            return dw;
        }

        public void Save(string name)
        {
            // Сериализатор
            XmlSerializer ser = new XmlSerializer(typeof(UserDict));
            // Режим формирования XML-файла
            var s = new XmlWriterSettings()
            {
                Indent = true
            };
            // Писатель файла
            using (XmlWriter wrt = XmlWriter.Create(name, s))
            {
                // Cериализация!
                ser.Serialize(wrt, this);
            }
        }
    }
}
