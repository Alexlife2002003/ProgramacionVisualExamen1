using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Black
    {
        List<String> blackList;

        public Black()
        {
            blackList = new List<String>();
            blackList.Add("2");
            blackList.Add("4");
            blackList.Add("6");
            blackList.Add("8");
            blackList.Add("10");
            blackList.Add("11");
            blackList.Add("13");
            blackList.Add("15");
            blackList.Add("17");
            blackList.Add("20");
            blackList.Add("22");
            blackList.Add("24");
            blackList.Add("26");
            blackList.Add("28");
            blackList.Add("29");
            blackList.Add("31");
            blackList.Add("33");
            blackList.Add("35");
        }

        public List<String > List
        {
            get { return blackList; }
            set { blackList = value; }
        }
    }
}
