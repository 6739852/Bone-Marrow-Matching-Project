using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{

    public class Antigen_SickDB : GeneralDB // מחלקת רבים של אנטיגנים לחולה
    {

        List<Antigen_Sick> listC = new List<Antigen_Sick>();

        public Antigen_SickDB() : base("antigen_sick")
        {

        }
        public List<Antigen_Sick> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Antigen_Sick(dr));
            }
            return listC;
        }
        public void AddNew(Antigen_Sick S)
        {
            S.Dr = dt.NewRow();
            S.PutInto();
            this.dt.Rows.Add(S.Dr);
            this.Update();
        }
        public void UpdateRow(Antigen_Sick a)
        {
            a.PutInto();
            this.Update();
        }
        public Antigen_Sick SearchId(string tz_sick)
        {
            return GetList().Find(X => X.Tz_sick == tz_sick);
        }
        //מספור אוטומטי
        public int GetNextKey()
        {
            if (GetList().Count() == 0)
                return 1;
            int key = GetList().Max(x => x.Numbber_checking);//מחזיר את הקוד המקסימלי
            key++;
            return key;
        }
    }
}
