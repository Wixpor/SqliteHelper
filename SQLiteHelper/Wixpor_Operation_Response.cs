using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteHelper
{
    public class Wixpor_Operation_Response
    {
        public int _Status_Code { get; set; }

        public string _Error_Desc { get; set; }

        public string _Trx_Key { get; set; }

        public string _Msg { get; set; }

        public object _Object_Response { get; set; }

        public Wixpor_Operation_Response()
        {
            _Status_Code = 0;
            _Error_Desc = "";
            _Trx_Key = "";
            _Msg = "";
        }
    }
}
