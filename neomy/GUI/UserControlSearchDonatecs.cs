using neomy.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neomy.GUI
{
    public partial class UserControlSearchDonatecs : UserControl //חיפוש תורם
    {
        public UserControlSearchDonatecs()
        {
            InitializeComponent();
        }

        DonorDB tbldonor = new DonorDB();

        //לולאה שמחפשת את התורם המבוקש
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in Parent.Parent.Controls)
            {
                if (item.Name == "dataGridView1")
                {
                   ((DataGridView)item).DataSource = tbldonor.GetList().Where(d => d.Tz.StartsWith(textBox1.Text)).Select(x => new { תעודת_זהות = x.Tz, שם_פרטי = x.First_name, שם_משפחה = x.Last_name, עיר = x.CitiesOfDonor().Name_city, טלפון = x.Numbber_phone, תאריך_לידה = x.Date_of_birth, סטטוס = x.Status }).ToList(); //פתיחה של הדאטה גריביו של התורמים.ToList();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
