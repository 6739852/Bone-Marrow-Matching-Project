using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class Antigen_DonorDB : GeneralDB  //מחלקת רבים של אנטיגנים לתורם
    {

        List<Antigen_Donor> listC = new List<Antigen_Donor>();

        public Antigen_DonorDB() : base("antigen_donor")
        {

        }
        public List<Antigen_Donor> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Antigen_Donor(dr));
            }
            return listC;
        }
        public void AddNew(Antigen_Donor S)
        {
            S.Dr = dt.NewRow();
            S.PutInto();
            this.dt.Rows.Add(S.Dr);
            this.Update();
        }
        public void UpdateRow(Antigen_Donor a)
        {
            a.PutInto();
            this.Update();
        }
        public Antigen_Donor SearchId(string tz_donor)
        {
            return GetList().Find(X => X.Tz_donor == tz_donor);
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
