using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteHelper
{
    public class Enti_NotionSync
    {
        public int NOSY_ID { get; set; }
        public string NOSY_EMAIL { get; set; }
        public DateTime NOSY_INSERT_DATETIME { get; set; }


        public Enti_NotionSync()
        {
            this.Inicializa();
        }

        private void Inicializa()
        {
            NOSY_ID = 0;
            NOSY_EMAIL = string.Empty;
            NOSY_INSERT_DATETIME=DateTime.MinValue;
        }
    }   
}


