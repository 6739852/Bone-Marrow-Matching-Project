using ExampleProject.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy.Bll
{

    public class Search_requestsDB : GeneralDB
    {

        List<Search_request> listC = new List<Search_request>();

        public Search_requestsDB() : base("search_requests")
        {

        }
        public List<Search_request> GetList()
        {
            listC.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listC.Add(new Search_request(dr));
            }
            return listC;
        }
        public void AddNew(Search_request S)
        {
            S.Dr = dt.NewRow();
            S.PutInto();
            this.dt.Rows.Add(S.Dr);
            this.Update();
        }
    }
}
