using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteHelper
{
    public class ControllerNotionSync
    {
        public static Lst_Enti_NotionSync Get_Lst_Enti_NotionEmails()
        {
            var NotionEmails = new Lst_Enti_NotionSync();
            NotionEmails.Lst_NotionSync = new List<Enti_NotionSync>();
            var SQLite = new SQLiteDatabaseManager("C:\\BotGhl2Notion\\BatchNotion.db");
            try
            {
                var stL_Sql = " Select * from NotionSync order by NOSY_ID ASC";
                var dataTable_Response = SQLite.SelectData(stL_Sql);

                if (dataTable_Response != null)
                {
                    for (int inL_Row = 0; inL_Row < dataTable_Response.Rows.Count; inL_Row++)
                    {
                        DataRow Info_Fila = dataTable_Response.Rows[inL_Row];

                        NotionEmails.Lst_NotionSync.Add(new Enti_NotionSync()
                        {
                            NOSY_ID = Convert.ToInt32(Info_Fila["NOSY_ID"]),
                            NOSY_EMAIL = Info_Fila["NOSY_EMAIL"].ToString(),
                            NOSY_INSERT_DATETIME = Convert.ToDateTime(Info_Fila["NOSY_INSERT_DATETIME"])
                        });
                    }
                }
                else
                {
                    NotionEmails._Status_Code = 404;
                    NotionEmails._Error_Desc = "Data not found";
                }
                NotionEmails._Status_Code = 200;
                NotionEmails._Error_Desc = "Successful";
            }
            catch (Exception ex)
            {
                NotionEmails._Status_Code = 401;
                NotionEmails._Error_Desc = ex.Message;
            }
            return NotionEmails;
        }

        public static List<string> Get_Lst_NotionEmails()
        {
            List<string> lst_NotionEmails = new List<string>();
            var SQLite = new SQLiteDatabaseManager("C:\\BotGhl2Notion\\BatchNotion.db");
            try
            {
                var stL_Sql = " Select * from NotionSync order by NOSY_ID ASC";
                var dataTable_Response = SQLite.SelectData(stL_Sql);

                if (dataTable_Response != null)
                {
                    for (int inL_Row = 0; inL_Row < dataTable_Response.Rows.Count; inL_Row++)
                    {
                        DataRow Info_Fila = dataTable_Response.Rows[inL_Row];
                        lst_NotionEmails.Add(Info_Fila["NOSY_EMAIL"].ToString());
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lst_NotionEmails;
        }

    }
}
