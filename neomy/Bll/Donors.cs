using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    internal class Donors
    {
        //תכונות המחלקה
        private string tz;
        private string first_name;
        private string last_name;
        private int city;
        private string numbber_phon;
        private DateTime date_of_birth;
        private double weight;
        private bool status;
        private DataRow dr;

        //פעולה בונה ריקה 
        public Donors() { }
        
        //פעולות get ו-set
        public string First_name { get => first_name;
            set 
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("אותיות בעברית בלבד"); first_name = value;

            } 
        }
        public string Last_name { get => last_name; set => last_name = value; }
        public int City { get => city; set => city = value; }
        public string Numbber_phon { get => numbber_phon; set => numbber_phon = value; }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public double Weight { get => weight; set => weight = value; }
        public bool Status { get => status; set => status = value; }
        public DataRow Dr { get => dr; set => dr = value; }
        public string Tz { get => tz; set => tz = value; }

        //פעולה שבונה את הרשימה
        public Donors(DataRow dr) : this()
        {
            this.dr = dr;
            this.tz = dr["tz"].ToString();
            this.first_name = dr["first_name"].ToString();
            this.last_name = dr["last_name"].ToString(); 
            this.city = Convert.ToInt32(dr["city"]); 
            this.numbber_phon = dr["numbber_phon"].ToString(); 
            this.date_of_birth = Convert.ToDateTime(dr["date_of_birth"]); 
            this.Weight = Convert.ToDouble(dr["Weight"]); 
            this.status = Convert.ToBoolean(dr["status"]); 
        }
        //PutInto פעולת  
        public void PutInto()
        {
            Dr["tz"] = tz;
            Dr["first_name"] = first_name;
            Dr["last_name"] = last_name;
            Dr["city"] = city;
            Dr["numbber_phon"] = numbber_phon;
            Dr["date_of_birth"] = date_of_birth;
            Dr["weight"] = Weight;
            Dr["status"] = status;
        }
    }
}
