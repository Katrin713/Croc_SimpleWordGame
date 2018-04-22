using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Words
{
    public class YandexDict
    {
        private string path = "https://dictionary.yandex.net/api/v1/dicservice.json/lookup?";
        private string key = "key=dict.1.1.20180422T095855Z.ca85a4432a8a4b68.01df85ec78e2eba45ea8213fa997e6c3fd5fa230";

        public string Translate(string s, string lang = "ru-ru")
        {
            if (s.Length > 0)
            {
                WebRequest request = WebRequest.Create(path
                    + key
                    + "&lang=" + lang
                    + "&text=" + s);
               
                WebResponse response = request.GetResponse();

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;

                    if ((line = stream.ReadLine()) != null)
                    {
                        GetWord translation = JsonConvert.DeserializeObject<GetWord>(line);

                        if (translation.def.Count() == 0)
                            throw new Exception("Слова не существует в словаре!");

                        s = translation.def[0].text;
                    }
                }
                return s;
            }
            else throw new Exception("Пустая стока");
        }
    }
}
