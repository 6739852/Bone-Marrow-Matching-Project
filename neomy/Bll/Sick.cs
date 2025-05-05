using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class Sick  //מחלקת יחיד חולים
    {
        //תכונות המחלקה
        private string tz;
        private string first_name;
        private string last_name;
        private int city;
        private string numbber_phone;
        private DateTime date_of_birth;
        private double weight;
        private int hospital;
        private bool status;
        private DataRow dr;
       
        //פעולה בונה ריקה
        public Sick() { }

        //פעולות getו-set
        
        //תעודת זהות
        public string Tz
        {
            get => tz; set
            {
                if (!Validation.IsNum((value).ToString()))
                {
                    throw new Exception("תעודת זהות אינה תקינה");
                }
                tz = value;
            }
        }
        //שם פרטי
        public string First_name
        {
            get => first_name;
            set
            {
                if (!Validation.IsHebrew(value))
                {
                    throw new Exception("אותיות בעברית בלבד");
                }
                first_name = value;
            }
        }
        //שם משפחה
        public string Last_name
        {
            get => last_name;
            set
            {
                if (!Validation.IsHebrew(value))
                {
                    throw new Exception("אותיות בעברית בלבד");
                }
                
                last_name = value;
            }
        }
        public int City { get => city; set => city = value; }
        //מספר טלפון
        public string Numbber_phone
        {
            get => numbber_phone; set
            {
                if (!Validation.IsPelepon(value))
                {
                    throw new Exception("מספר לא תקין");
                }
                numbber_phone = value;
            }
        }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Hospital { get => hospital; set => hospital = value; }
        public bool Status { get => status; set => status = value; }
        public DataRow Dr { get => dr; set => dr = value; }

        //פעולה שבונה את הרשימה                      
        public Sick(DataRow dr) : this()
        {
            this.dr = dr;
            this.tz = dr["tz"].ToString();
            this.first_name = dr["first_name"].ToString(); 
            this.last_name = dr["last_name"].ToString(); 
            this.city = Convert.ToInt32(dr["city"]); 
            this.numbber_phone = dr["numbber_phone"].ToString(); 
            this.date_of_birth = Convert.ToDateTime(dr["date_of_birth"]); 
            this.weight = Convert.ToDouble(dr["weight"]); 
            this.hospital= Convert.ToInt32(dr["hospital"]);
            this.status = Convert.ToBoolean(dr["status"]); 
        }
        //PutInto פעולת  
        public void PutInto()
        { 
            Dr["tz"] = Tz;
            Dr["first_name"] = first_name;
            Dr["last_name"] = last_name;
            Dr["city"] = city;
            Dr["numbber_phone"] = numbber_phone;
            Dr["date_of_birth"] = date_of_birth;
            Dr["weight"] = weight;
            Dr["hospital"] = hospital;
            Dr["status"] = status;
        }
       
        //פעולה שמביאה עצם מסוג עיר
        public Cities CitiesOfSick()
        {
            return new CitiesDB().SearchKod(this.city);
        }
      
        //פעולה שמביאה עצם מסוג אנטיגן
        public Antigen_Sick Antigen_SickOfSick()
        {
            return new Antigen_SickDB().SearchId(this.tz);
        }

        //פעולה שמביאה עצם מסוג בית חולים
        public Hospital HospitalOfSick()
        {
            return new HospitalDB().Searchkod(this.hospital);
        }
    }
}
