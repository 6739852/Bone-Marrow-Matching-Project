using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    internal class Antigen_DonorsDB : GeneralDB
    {

            List<Antigen_Donors> listC = new List<Antigen_Donors>();

            public Antigen_DonorsDB() : base("antigen_donors")
            {

            }
            public List<Antigen_Donors> GetList()
            {
                listC.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    listC.Add(new Antigen_Donors(dr));
                }
                return listC;
            }
            public void AddNew(Antigen_Donors S)
            {
                S.Dr = dt.NewRow();
                S.PutInto();
                this.dt.Rows.Add(S.Dr);
                this.Update();
            }
        public void UpdateRow(Antigen_Donors a)
        {
            a.PutInto();
            this.Update();
        }
        public Antigen_Donors SearchId(string tz_donor)
        {
            return GetList().Find(X => X.Tz_donor == tz_donor);
        }
    }
}
