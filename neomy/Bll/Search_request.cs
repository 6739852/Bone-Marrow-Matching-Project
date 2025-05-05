using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{
    public class Search_request
    {  
        //תכונות המחלקה
        private int kod;
        private string tz_sick;
        private DateTime date_please;
        private string contact;
        private string hospital;
        private bool status;
        private DataRow dr;

        //פעולה בונה ריקה
        public Search_request() { }

        //פעולות get ו-set
        public int Kod { get => kod; set => kod = value; }
        public string Tz_sick { get => tz_sick; set => tz_sick = value; }
        public DateTime Date_please { get => date_please; set => date_please = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Hospital { get => hospital; set => hospital = value; }
        public bool Status { get => status; set => status = value; }
        public DataRow Dr { get => dr; set => dr = value; }

        //פעולה שבונה את הרשימה
        public Search_request(DataRow dr) : this()
        {
            this.dr = dr;
            this.kod = Convert.ToInt32(dr["kod"]);
            this.tz_sick = dr["tz_sick"].ToString();
            this.date_please = Convert.ToDateTime(dr["date_please"]);
            this.contact = dr["contact"].ToString();
            this.hospital = dr["hospital"].ToString();
            this.status = Convert.ToBoolean(dr["status"]);
        }
        //PutInto פעולת  
        public void PutInto()
        {
            Dr["kod"] = kod;
            Dr["tz_sick"] = tz_sick;
            Dr["date_please"] = date_please;
            Dr["contact"] = contact;
            Dr["hospital"] = hospital;
            Dr["status"] = status;
        }
    }
}
