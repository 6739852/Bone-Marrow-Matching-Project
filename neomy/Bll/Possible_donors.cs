using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class Possible_donors  //מחלקת יחיד של תורמים רלוונטים
    {
        //תכונות המחלקה
        private string tz_donor;
        private string tz_sick;
        private bool status;
        public int donation_phase;
        public bool the_selected_donor;
        private DataRow dr;

        //פעולה בונה ריקה
        public Possible_donors() { }
       
        //פעולות getו-set
        public string Tz_donor { get => tz_donor; set => tz_donor = value; }
        public string Tz_sick { get => tz_sick; set => tz_sick = value; }
        public bool Status { get => status; set => status = value; }
        public int Donation_phase { get => donation_phase; set => donation_phase = value; }
        public bool The_selected_donor { get => the_selected_donor; set => the_selected_donor = value; }
        public DataRow Dr { get => dr; set => dr = value; }

        //פעולה שבונה את המחלקה
        public Possible_donors(DataRow dr) : this()
        {
            this.Dr = dr;
            this.tz_donor = dr["tz_donor"].ToString();
            this.tz_sick = dr["tz_sick"].ToString();
            this.status = Convert.ToBoolean(dr["status"]);
            this.donation_phase = Convert.ToInt32(dr["donation_phase"]);
            this.the_selected_donor = Convert.ToBoolean(dr["the_selected_donor"]);
        }

        //PutInto פעולת  
        public void PutInto()
        {
            Dr["tz_donor"] = tz_donor;
            Dr["tz_sick"] = tz_sick;
            Dr["status"] = status;
            Dr["donation_phase"] = donation_phase;
            Dr["the_selected_donor"] = the_selected_donor;
        }

        //פעולה שמביאה עצם מסוג חולה
        public Sick SickOfPossible_donors(string tz_sick)
        {
            return new SickDB().SearchId(this.tz_sick);
        }
    }
}
