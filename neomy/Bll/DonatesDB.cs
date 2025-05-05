using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    internal class DonatesDB : GeneralDB
    {

        List<Donates> listC = new List<Donates>();

        public DonatesDB() : base("donates")
        {

        }
        public List<Donates> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Donates(dr));
            }
            return listC;
        }
        public void AddNew(Donates d)
        {
            d.Dr = dt.NewRow();
            d.PutInto();
            this.dt.Rows.Add(d.Dr);
            this.Update();
        }
        public void UpdateRow(Donates d)
        {
            d.PutInto();
            this.Update();
        }
        public Donates SearchId(string tz)
        {
            return GetList().Find(X => X.Tz == tz);
        }
    }
}