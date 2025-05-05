using neomy.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using neomy.Bll;
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace neomy.GUI
{  
    //טופס של תרומות שבוצעו
    public partial class Form5 : Form
    {
        Donations_madeDB dm;
        Donations_madeDB dmD = new Donations_madeDB();

        public Form5()
        {
            InitializeComponent();

            //פתיחת הדאטא גריביו
            dm = new Donations_madeDB();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = dm.GetList().Where(x => x.Date_of_donation < DateTime.Now).Select(x => new { תעודת_זהות_תורם = x.Tz_donor, תעודת_זהות_חולה = x.Tz_sick, תאריך_התרומה = x.Date_of_donation, קןד_תרומה = x.Kod_donation, בית_חולים = x.HospitalOfDonation().Name_hospital, }).ToList(); //פתיחה של הדאטה גריביו של ההשתלות שבוצעו
            dataGridView1.ReadOnly = true;

            //שזה יואתחל למספר ההשתלות
            label3.Text = dm.GetList().Count(x => x.Date_of_donation < DateTime.Now).ToString();
        }

        //חזרה לעמוד הראשי
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 uco = new Form1();
            uco.Show();
        }

        //כפתור לחיפוש תרומה
        private void buttensearch_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlSearch3 uso = new UserControlSearch3();
            panel1.Controls.Add(uso);
            uso.Dock = DockStyle.Fill;
        }
    }
}























