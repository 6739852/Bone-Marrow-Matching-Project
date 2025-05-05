using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace ExampleProject.Data
{
    class Dal
    {
        private static Dal instance;

        private OleDbConnection con;//מכיל את מחרוזת החיבור = מיקום קובץ האקסס
        private DataSet ds;//DB - אובייקט המכיל את כל ה

        //פעולה בונה המקבלת את מחרוזת החיבור
        private Dal(string connectionString)
        {
            con = new OleDbConnection(connectionString);
            ds = new DataSet();
        }
        public static Dal GetInstance()
        {
            if (instance == null)
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                int x = path.IndexOf("\\bin");
                path = path.Substring(0, x) + "\\Data\\data.accdb";
                instance = new Dal(@"Provider= Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Persist Security Info=True");

            }
            return instance;
        }
        //מקבלת שם טבלה ומוסיפה לדטהסט
        public void AddTable(string tableName)
        {
            if (!ds.Tables.Contains(tableName))
            {
                //יוצר אדפטר המקבל מחרוזת חיבור ופקודה
                OleDbDataAdapter adapter = new OleDbDataAdapter(" Select * from " + tableName, con);
                adapter.Fill(ds, tableName);//ומכניס לדטהסט DBשולף נתונים מ 
            }
        }

        //פעולה המקבלת שם טבלה ומחזירה אותה כעצם מסוג טבלה
        public DataTable GetTable(string tableName)
        {
            if (!ds.Tables.Contains(tableName))
                AddTable(tableName);
            return ds.Tables[tableName];
        }
 
        //DBפעולה המקבלת שם טבלה ומעדכנת את הנתונים מהדטהסט ל
        public void Update(string tableName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("select*from " + tableName, con);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.DeleteCommand = builder.GetDeleteCommand();
            adapter.Update(ds, tableName);
        }

        //DBפעולה המעדכנת את הנתונים מהדטהסט ל
        public void Update()
        {
            foreach (DataTable table in ds.Tables)
            {
                Update(table.TableName);
            }
        }
    }
}
