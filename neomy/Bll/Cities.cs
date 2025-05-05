using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace neomy.Bll
{
    public class Cities  //מחלקת יחיד של ערים

    {  //תכונות המחלקה
        private int kod;
        private string name_city;
        private DataRow dr;

        //פעולה בונה ריקה
        public Cities() { }

        //פעולות getו-set
        public int Kod { get => kod; set => kod = value; }
        public string Name_city { get => name_city; set => name_city = value; }
        public DataRow Dr { get => dr; set => dr = value; }

        //פעולה שבונה את הרשימה
        public Cities(DataRow dr) : this()
        {
            this.dr = dr;
            this.kod = Convert.ToInt32(dr["kod"]);
            this.name_city = dr["name_city"].ToString();
        }

        //PutInto פעולת  
        public void PutInto()
        {
            Dr["kod"] = kod;
            Dr["last_name"] = name_city;
        }
      
        //comboBox-יחזיר את הערך המילולי ב
        public override string ToString()
        {
            return this.Name_city;
        }
    }
}
