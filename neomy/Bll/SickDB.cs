using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class SickDB : GeneralDB  //מחלקת רבים של חולים
    {

        List<Sick> listC = new List<Sick>();

        public SickDB() : base("sick")
        {

        }
        public List<Sick> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Sick(dr));
            }
            return listC;
        }
        public void AddNew(Sick S)
        {
            S.Dr = dt.NewRow();
            S.PutInto();
            this.dt.Rows.Add(S.Dr);
            this.Update();
        }
        public void UpdateRow(Sick S)
        {
            S.PutInto();
            this.Update();
        }
        public Sick SearchId(string tz)
        {   
            return GetList().Find(X => X.Tz == tz);
        }
    }
}
