using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    internal class Antigen_donateDB : GeneralDB
    {

            List<Antigen_donate> listC = new List<Antigen_donate>();

            public Antigen_donateDB() : base("antigen_donate")
            {

            }
            public List<Antigen_donate> GetList()
            {
                listC.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    listC.Add(new Antigen_donate(dr));
                }
                return listC;
            }
            public void AddNew(Antigen_donate S)
            {
                S.Dr = dt.NewRow();
                S.PutInto();
                this.dt.Rows.Add(S.Dr);
                this.Update();
            }
        }
}
