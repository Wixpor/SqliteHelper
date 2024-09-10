using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteHelper
{
    public class Lst_Enti_NotionSync
    {

        public int _Status_Code { get; set; }
        public string _Error_Desc { get; set; }
        public List<Enti_NotionSync> Lst_NotionSync { get; set; }


        public Lst_Enti_NotionSync()
        {
            _Status_Code = 0;
            _Error_Desc = "";
        }
    }
}
