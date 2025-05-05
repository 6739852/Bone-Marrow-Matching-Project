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
    public partial class UserControlSearch3 : UserControl
    {
        public UserControlSearch3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        Donations_madeDB tbldm = new Donations_madeDB();

        // מחפש את התרומה הרצויה על ידי מספר תעודת זהות חולה
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in Parent.Parent.Controls)
            {
                if (item.Name == "dataGridView1")
                {
                    ((DataGridView)item).DataSource = tbldm.GetList().Where(d => d.Tz_sick.StartsWith(textBox1.Text)).Select(x => new { תעודת_זהות_תורם = x.Tz_donor, תעודת_זהות_חולה = x.Tz_sick, תאריך_התרומה = x.Date_of_donation, קןד_תרומה = x.Kod_donation, בית_חולים = x.HospitalOfDonation().Name_hospital, }).ToList();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
