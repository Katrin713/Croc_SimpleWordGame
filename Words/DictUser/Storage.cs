using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.DictUser
{
    public class Storage
    {
        UserDict userDict;

        public Storage()
        {
            userDict = UserDict.Load("../../DictUser/Dict.xml");
        }

        public int LongCount()
        {
            return userDict.dictItem.Max(el => el.LongWord);
        }

        public DictItem GetLongWord(int max)
        {
            var r = new Random();
            int n = r.Next(max);
            //выбор длинного слова
            var di = userDict.dictItem.Where(el => el.LongWord == n);
            return (DictItem)di.ToList()[0];
        }

        public DictItem GetWord(string w)
        {
            List<DictItem> di = userDict.dictItem.Where(el => el.Word == w).ToList();
            if (di.Count == 0)
                return null;
            else
                return di[0];
        }

        public void AddItem(string item)
        {
            List<DictItem> dictItems = (userDict.dictItem != null) ? userDict.dictItem.ToList() : new List<DictItem>();

            dictItems.Add(new DictItem() { Word = item });

            var dictItemsSort = dictItems.OrderBy(el => el.Word);
            userDict.dictItem = dictItemsSort.ToArray();
   
            userDict.Save("../../DictUser/Dict.xml");
        }
    }
}
