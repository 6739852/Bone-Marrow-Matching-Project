using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{

    public class CitiesDB : GeneralDB  //מחלקת רבים של ערים
    {

        List<Cities> listC = new List<Cities>();

        public CitiesDB() : base("cities")
        {

        }
        public List<Cities> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Cities(dr));
            }
            return listC;
        }
        public void AddNew(Cities S)
        {
            S.Dr = dt.NewRow();
            S.PutInto();
            this.dt.Rows.Add(S.Dr);
            this.Update();
        }
        public void UpDateRow(Cities S)
        {
            S.PutInto();
            this.Update();
        }
        public Cities SearchKod(int Kod)
        {
            return GetList().Find(x => x.Kod == Kod);
        }
    }
}