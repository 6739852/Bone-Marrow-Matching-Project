using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class Antigen_Donor  // מחלקת יחיד של אנטיגנים לתורם
    {
        //תכונות המחלקה
        private string tz_donor;
        private int numbber_checking;
        private string blood_type;
        private int hla_A1;
        private int hla_A2;
        private int hla_B1;
        private int hla_B2;
        private int hla_C1;
        private int hla_C2;
        private int hla_DQ1;
        private int hla_DQ2;
        private int hla_DRBI1;
        private int hla_DRBI2;
        private bool status;
        private DataRow dr;
        private int[] arrAntigen;  // מערך שאחר כך יכניסו אליו את האנטיגנים לפי הסדר

        //פעולה בונה ריקה
        public Antigen_Donor() { }

        //פעולות getן-set
        public string Tz_donor { get => tz_donor; set => tz_donor = value; }
        public int Numbber_checking { get => numbber_checking; set => numbber_checking = value; }
        public string Blood_type { get => blood_type; set => blood_type = value; }
        public int Hla_A1 { get => hla_A1; set => hla_A1 = value; }
        public int Hla_A2 { get => hla_A2; set => hla_A2 = value; }
        public int Hla_B1 { get => hla_B1; set => hla_B1 = value; }
        public int Hla_B2 { get => hla_B2; set => hla_B2 = value; }
        public int Hla_C1 { get => hla_C1; set => hla_C1 = value; }
        public int Hla_C2 { get => hla_C2; set => hla_C2 = value; }
        public int Hla_DQ1 { get => hla_DQ1; set => hla_DQ1 = value; }
        public int Hla_DQ2 { get => hla_DQ2; set => hla_DQ2 = value; }
        public int Hla_DRBI1 { get => hla_DRBI1; set => hla_DRBI1 = value; }
        public int Hla_DRBI2 { get => hla_DRBI2; set => hla_DRBI2 = value; }
        public bool Status { get => status; set => status = value; }
        public DataRow Dr { get => dr; set => dr = value; }
        public int[] ArrAntigen { get => arrAntigen; set => arrAntigen = value; }

        //פעולה שבונה את הרשימה                      
        public Antigen_Donor(DataRow dr) : this()
        {
            this.dr = dr;
            this.tz_donor = dr["tz_donor"].ToString();
            this.numbber_checking = Convert.ToInt32(dr["numbber_checking"]);
            this.blood_type = dr["blood_type"].ToString();
            this.hla_A1 = Convert.ToInt32(dr["hla_A1"]);
            this.hla_A2 = Convert.ToInt32(dr["hla_A2"]);
            this.hla_B1 = Convert.ToInt32(dr["hla_B1"]);
            this.hla_B2 = Convert.ToInt32(dr["hla_B2"]);
            this.hla_C1 = Convert.ToInt32(dr["hla_C1"]);
            this.hla_C2 = Convert.ToInt32(dr["hla_C2"]);
            this.hla_DQ1 = Convert.ToInt32(dr["hla_DQ1"]);
            this.hla_DQ2 = Convert.ToInt32(dr["hla_DQ2"]);
            this.hla_DRBI1 = Convert.ToInt32(dr["hla_DRBI1"]);
            this.hla_DRBI2 = Convert.ToInt32(dr["hla_DRBI2"]);
            this.Status = Convert.ToBoolean(dr["status"]);

            //מערך עם אנטיגנים לפי הסדר
            ArrAntigen = new int[] { hla_A1, hla_A2, hla_B1, hla_B2, hla_C1, hla_C2, hla_DQ1, hla_DQ2, hla_DRBI1, hla_DRBI2 };
        }

        //PutInto פעולת  
        public void PutInto()
        {
            Dr["tz_donor"] = tz_donor;
            Dr["numbber_checking"] = numbber_checking;
            Dr["blood_type"] = blood_type;
            Dr["hla_A1"] = hla_A1;
            Dr["hla_A2"] = hla_A2;
            Dr["hla_B1"] = hla_B1;
            Dr["hla_B2"] = hla_B2;
            Dr["hla_C1"] = hla_C1;
            Dr["hla_C2"] = hla_C2;
            Dr["hla_DQ1"] = hla_DQ1;
            Dr["hla_DQ2"] = hla_DQ2;
            Dr["hla_DRBI1"] = hla_DRBI1;
            Dr["hla_DRBI2"] = hla_DRBI2;
            Dr["status"] = status;
        }

        //??מה הפעולה הזאת
        public bool CheckAntigens(Sick s)
        {
            return true;
        }

        //פעולה שמביאה עצם מסוג תורם
        public Donor DonorOfAntigen_Donor()
        {
            return new DonorDB().SearchId(this.tz_donor);
        }
    }
}
