using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{

    internal class HospitalsDB : GeneralDB
    {

        List<Hospitals> listC = new List<Hospitals>();

        public HospitalsDB() : base("hospitals")
        {

        }
        public List<Hospitals> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Hospitals(dr));
            }
            return listC;
        }
        public void AddNew(Hospitals S)
        {
            S.Dr = dt.NewRow();
            S.PutInto();
            this.dt.Rows.Add(S.Dr);
            this.Update();
        }

    }
}
