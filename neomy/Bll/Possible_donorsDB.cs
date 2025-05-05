using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{

    public class Possible_donorsDB : GeneralDB  //מחלקת רבים של תורמים רלוונטים
    {

        List<Possible_donors> listC = new List<Possible_donors>();

        public Possible_donorsDB() : base("possible_donors")
        {

        }
        public List<Possible_donors> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Possible_donors(dr));
            }
            return listC;
        }
        public void AddNew(Possible_donors S)
        {
            S.Dr = dt.NewRow();
            S.PutInto();
            this.dt.Rows.Add(S.Dr);
            this.Update();
        }
        public void UpdateRow(Possible_donors p)
        {
            p.PutInto();
            this.Update();
        }
        public Possible_donors SearchId(string tz_donor)
        {
            return GetList().Find(X => X.Tz_donor == tz_donor);
        }
    }
}
