using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ExampleProject.Data;

namespace ExampleProject.Bll
{
     public class GeneralDB
    {
        protected DataTable dt;//עצם המכיל טבלה שלמה


        //את הטבלה המבוקשת dtפעולה בונה המקבלת שם טבלה ומכניסה ל
         public GeneralDB(string tableName)
        {
            //פונה לפעולה במחלקת דאל המקבלת שם טבלה ומחזירה טבלה כעצם
            this.dt = Dal.GetInstance().GetTable(tableName);
        }

        public void Update()
        {
            Dal.GetInstance().Update(dt.TableName);
        }
    }
}
