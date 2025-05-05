using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    internal class Donates
    {
        //תכונות המחלקה
        private string tz;
        private string first_name;
        private string last_name;
        private string street;
        private int city;
        private string numbber_phon;
        private DateTime date_of_birth;
        private string mail;
        private string male_or_female;
        private string blood_type;
        private double weight;
        private bool cmv;
        private bool status;
        private DataRow dr;

        //פעולה בונה ריקה 
        public Donates() { }
        
        //פעולות get ו-set
        public string First_name { get => first_name;
            set 
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("אותיות בעברית בלבד"); first_name = value;

            } 
        }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Street { get => street; set => street = value; }
        public int City { get => city; set => city = value; }
        public string Numbber_phon { get => numbber_phon; set => numbber_phon = value; }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Male_or_female { get => male_or_female; set => male_or_female = value; }
        public string Blood_type { get => blood_type; set => blood_type = value; }
        public double Weight { get => weight; set => weight = value; }
        public bool Cmv { get => cmv; set => cmv = value; }
        public bool Status { get => status; set => status = value; }
        public DataRow Dr { get => dr; set => dr = value; }
        public string Tz { get => tz; set => tz = value; }

        //פעולה שבונה את הרשימה
        public Donates(DataRow dr) : this()
        {
            this.dr = dr;
            this.tz = dr["tz"].ToString();
            this.first_name = dr["first_name"].ToString();
            this.last_name = dr["last_name"].ToString();
            this.street = dr["street"].ToString(); 
            this.city = Convert.ToInt32(dr["city"]); 
            this.numbber_phon = dr["numbber_phon"].ToString(); 
            this.date_of_birth = Convert.ToDateTime(dr["date_of_birth"]); 
            this.mail = dr["mail"].ToString(); ;
            this.male_or_female = dr["Male_or_female"].ToString(); 
            this.blood_type = dr["blood_type"].ToString(); 
            this.Weight = Convert.ToDouble(dr["Weight"]); 
            this.cmv = Convert.ToBoolean(dr["cmv"]); 
            this.status = Convert.ToBoolean(dr["status"]); 
        }
        //PutInto פעולת  
        public void PutInto()
        {
            Dr["tz"] = tz;
            Dr["first_name"] = first_name;
            Dr["last_name"] = last_name;
            Dr["street"] = street;
            Dr["city"] = city;
            Dr["numbber_phon"] = numbber_phon;
            Dr["date_of_birth"] = date_of_birth;
            Dr["mail"] = mail;
            Dr["Male_or_female"] = male_or_female;
            Dr["blood_type"] = blood_type;
            Dr["weight"] = Weight;
            Dr["cmv"] = cmv;
            Dr["status"] = status;

        }
    }
}
