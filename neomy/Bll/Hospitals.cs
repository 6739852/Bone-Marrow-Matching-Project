using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    internal class Hospitals
    {
        //תכונות המחלקה
        private int kod;
        private string name_hospital;
        private DataRow dr;

        //פעולה בונה ריקה
        public Hospitals() { }
       
        //פעולות getו-set
        public int Kod { get => kod; set => kod = value; }
        public string Name_hospital { get => name_hospital; set => name_hospital = value; }
        public DataRow Dr { get => dr; set => dr = value; }


        //פעולה שבונה את הרשימה
        public Hospitals(DataRow dr) : this()
        {
            this.dr = dr;
            this.kod = Convert.ToInt32(dr["kod"]);
            this.name_hospital = dr["name_hospital"].ToString();
        }
        //PutInto פעולת  
        public void PutInto()
        {
            Dr["kod"] = kod;
            Dr["name_hospital"] = name_hospital;
        }
        public override string ToString()
        {
            //comboBox-יחזיר מה שרוצים שיראו ב
            return this.Name_hospital;
        }
    }
}
