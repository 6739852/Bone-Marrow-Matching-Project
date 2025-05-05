using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
   
    public class Donations_madeDB : GeneralDB  //מחלקת רבים של תרומות שבוצעו
    {

        List<Donations_made> listC = new List<Donations_made>();

        public Donations_madeDB() : base("Donations_made")
        {

        }
        public List<Donations_made> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Donations_made(dr));
            }
            return listC;
        }
        public void AddNew(Donations_made S)
        {
            S.Dr = dt.NewRow();
            S.PutInto();
            this.dt.Rows.Add(S.Dr);
            this.Update();
        }
        //מספור אוטומטי
        public int GetNextKey()
        {
            if (GetList().Count() == 0)
                return 1;
            int key = GetList().Max(x => x.Kod_donation);//מחזיר את הקוד המקסימלי
            key++;
            return key;
        }
        public void UpdateRow(Donor d)
        {
            d.PutInto();
            this.Update();
        }
    }
}
