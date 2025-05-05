using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    internal class Antigen_donate
    {
        //תכונות המחלקה
        private string blood_type;
        private int antigen_1;
        private int antigen_2;
        private int antigen_3;
        private int antigen_4;
        private int antigen_5;
        private DateTime date_of_set;
        private string tz_checking;
        private bool status;
        private DataRow dr;


        //פעולה בונה ריקה
        public Antigen_donate() { }

        //פעולות getן-set
        public string Blood_type { get => blood_type; set => blood_type = value; }
        public int Antigen_1 { get => antigen_1; set => antigen_1 = value; }
        public int Antigen_2 { get => antigen_2; set => antigen_2 = value; }
        public int Antigen_3 { get => antigen_3; set => antigen_3 = value; }
        public int Antigen_4 { get => antigen_4; set => antigen_4 = value; }
        public int Antigen_5 { get => antigen_5; set => antigen_5 = value; }
        public DateTime Date_of_set { get => date_of_set; set => date_of_set = value; }
        public string Tz_checking { get => tz_checking; set => tz_checking = value; }
        public bool Status { get => status; set => status = value; }
        public DataRow Dr { get => dr; set => dr = value; }


        //פעולה שבונה את הרשימה                      
        public Antigen_donate(DataRow dr) : this()
        {
            this.blood_type = blood_type.ToString();
            this.antigen_1 = Convert.ToInt32(dr["antigen_1"]);
            this.antigen_2 = Convert.ToInt32(dr["antigen_2"]);
            this.antigen_3 = Convert.ToInt32(dr["antigen_3"]);
            this.antigen_4 = Convert.ToInt32(dr["antigen_4"]);
            this.antigen_5 = Convert.ToInt32(dr["antigen_5"]);
            this.date_of_set = Convert.ToDateTime(dr["date_of_set"]);
            this.status= Convert.ToBoolean(dr["status"]);

        }

        //PutInto פעולת  
        public void PutInto()
        {
            Dr["blood_type"] = blood_type;
            Dr["antigen_1"] = antigen_1; ;
            Dr["antigen_2"] = antigen_2;
            Dr["antigen_3"] = antigen_3;
            Dr["antigen_4"] = antigen_4;
            Dr["antigen_5"] = antigen_5;
            Dr["antigen_5"] = antigen_5;
            
        }
    }
}
