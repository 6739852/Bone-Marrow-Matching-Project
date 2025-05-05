using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class Donor  // מחלקת יחיד של תורמים
    {
        //תכונות המחלקה
        private string tz;
        private string first_name;
        private string last_name;
        private int city;
        private string numbber_phone;
        private DateTime date_of_birth;
        private int weight;
        private bool status;
        private DataRow dr;

        //פעולה בונה ריקה 
        public Donor() { }

        // פעולות get ו-set //בדיקות תקינות של הקלט  
       
        //תעודת זהות
        public string Tz
        {
            get => tz; set
            {
                if (!Validation.CheckId((value).ToString()))
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
                    throw new Exception("Hebrew letters only");
                }
                last_name = value;
            }
        }
        //עיר
        public int City { get => city; set => city = value; }
        //מספר טלפון
        public string Numbber_phone
        {
            get => numbber_phone; set
            {
                if (!Validation.IsPelepon(value))
                {
                    throw new Exception("מספר לא תקין");
                } numbber_phone = value;
            }
        }
        //תאריך לידה
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        //משקל
        public int Weight { get => weight; set => weight = value; }
        //סטטוס
        public bool Status { get => status; set => status = value; }
        public DataRow Dr { get => dr; set => dr = value; }

        //פעולה שבונה את הרשימה
        public Donor(DataRow dr) : this()
        {
            this.dr = dr;
            this.tz = dr["tz"].ToString();
            this.first_name = dr["first_name"].ToString();
            this.last_name = dr["last_name"].ToString();
            this.city = Convert.ToInt32(dr["city"]);
            this.numbber_phone = dr["numbber_phone"].ToString();
            this.date_of_birth = Convert.ToDateTime(dr["date_of_birth"]);
            this.weight = Convert.ToInt32(dr["weight"]);
            this.status = Convert.ToBoolean(dr["status"]);
        }
        //PutInto פעולת  
        public void PutInto()
        {
            Dr["tz"] = tz;
            Dr["first_name"] = first_name;
            Dr["last_name"] = last_name;
            Dr["city"] = city;
            Dr["numbber_phone"] = numbber_phone;
            Dr["date_of_birth"] = date_of_birth;
            Dr["weight"] = weight;
            Dr["status"] = status;
        }
        //פעולה שמביאה עצם מסוג עיר
        public Cities CitiesOfDonor()
        {
            return new CitiesDB().SearchKod(this.city);
        }

        //פעולה שמביאה עצם מסוג אנטיגן
        public Antigen_Donor Antigen_DonorOfDonor()
        {
            return new Antigen_DonorDB().SearchId(this.tz);
        }

        public  string GetLevel { get; set; }

        //פעולה שסופרת כמה אנטיגנים שווים יש בין התורם הנוכחי לחולה ששלחו
        public int CheckAntigen(Sick s) 
        {
            int count = 0;
            for (int i = 0; i < s.Antigen_SickOfSick().ArrAntigen.Length; i++)
            {
                //בדיקה אם המשקל של התורם קטן או שווה ל45 אז זה יחזיר 0
                if (this.weight <= 45 &&  this.Antigen_DonorOfDonor().Status == false) 
                {
                    count = 0;
                    return count;
                }
                if (this.Antigen_DonorOfDonor().ArrAntigen[i] == s.Antigen_SickOfSick().ArrAntigen[i] )
                    count++;  
            }
            if (count == 10)
                GetLevel = "A";
            else if (count == 9)
                GetLevel = "B";
            else if (count == 8)
                GetLevel = "C";
            return count;
        }
    }
}
