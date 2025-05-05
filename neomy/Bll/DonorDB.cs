using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class DonorDB : GeneralDB  //מחלקת רבים של תורמים
    {
        List<Donor> listC = new List<Donor>();

        public DonorDB() : base("donor")
        {

        }
        public List<Donor> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Donor(dr));
            }
            return listC;
        }
        public void AddNew(Donor d)
        {
            d.Dr = dt.NewRow();
            d.PutInto();
            this.dt.Rows.Add(d.Dr);
            this.Update();
        }
        public void UpdateRow(Donor d)
        {
            d.PutInto();
            this.Update();
        }
        public Donor SearchId(string tz)
        {
            return GetList().Find(X => X.Tz == tz);
        }
    }
}