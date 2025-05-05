using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class HospitalDB : GeneralDB //מחלקת רבים של בית חולים
    {
        List<Hospital> listC = new List<Hospital>();

        public HospitalDB() : base("hospital")
        {

        }
        public List<Hospital> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Hospital(dr));
            }
            return listC;
        }
        public void AddNew(Hospital S)
        {
            S.Dr = dt.NewRow();
            S.PutInto();
            this.dt.Rows.Add(S.Dr);
            this.Update();
        }
       
        public Hospital Searchkod(int Kod)
        {
            return GetList().Find(x => x.Kod == Kod);
        }
    }
}
