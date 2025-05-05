using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class Donations_made  //מחלקת יחיד של תרומות שבוצעו
    {
        //תכונות המחלקה
        private int kod_donation;
        private string tz_sick;
        private string tz_donor;
        private DateTime date_of_donation;
        private int hospitail;

        //פעולה בונה ריקה
        public Donations_made() { }

        //פעולות get ו-set
        public string Tz_sick { get => tz_sick; set => tz_sick = value; }
        public string Tz_donor { get => tz_donor; set => tz_donor = value; }
        public DateTime Date_of_donation { get => date_of_donation; set => date_of_donation = value; }
        public int Hospitail { get => hospitail; set => hospitail = value; }
        public DataRow Dr { get; set; }
        public int Kod_donation { get => kod_donation; set => kod_donation = value; }

        //פעולה שבונה את הרשימה
        public Donations_made(DataRow dr) : this()
        {
            this.Dr = dr;
            this.Kod_donation =Convert.ToInt32( dr["kod_donation"]); 
            this.Tz_sick = dr["Tz_sick"].ToString(); 
            this.Tz_donor = dr["Tz_donor"].ToString();
            this.Date_of_donation= Convert.ToDateTime(dr["Date_of_donation"]);
            this.hospitail= Convert.ToInt32(dr["hospitail"]);
        }
       
        //PutInto פעולת  
        public void PutInto()
        {
            Dr["Tz_sick"] = Tz_sick;
            Dr["kod_donation"] = kod_donation;
            Dr["Tz_donor"] = Tz_donor;
            Dr["Date_of_donation"] = Date_of_donation;
            Dr["hospitail"] = hospitail;
        }

        //פעולה שמביאה עצם מסוג בית חולים
        public Hospital HospitalOfDonation()
        {
            return new HospitalDB().Searchkod(this.hospitail);
        }
    }
}
