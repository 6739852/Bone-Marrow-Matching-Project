using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    internal class DonorsDB : GeneralDB
    {

        List<Donors> listC = new List<Donors>();

        public DonorsDB() : base("donates")
        {

        }
        public List<Donors> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Donors(dr));
            }
            return listC;
        }
        public void AddNew(Donors d)
        {
            d.Dr = dt.NewRow();
            d.PutInto();
            this.dt.Rows.Add(d.Dr);
            this.Update();
        }
        public void UpdateRow(Donors d)
        {
            d.PutInto();
            this.Update();
        }
        public Donors SearchId(string tz)
        {
            return GetList().Find(X => X.Tz == tz);
        }
    }
}