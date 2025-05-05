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

namespace neomy
{  
    //טופס של תורמים
    public partial class Form3 : Form
    {
        DonorDB donates;

        public Form3()
        {
            InitializeComponent(); 

            donates = new DonorDB();                                             
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = donates.GetList().Select(x=>new { תעודת_זהות = x.Tz, שם_פרטי = x.First_name, שם_משפחה = x.Last_name, עיר = x.CitiesOfDonor().Name_city, טלפון = x.Numbber_phone, תאריך_לידה = x.Date_of_birth, סטטוס = x.Status }).ToList(); //פתיחה של הדאטה גריביו של התורמים                
            dataGridView1.ReadOnly = true;

        }
       
        //פתיחת היוזר של ההוספת תורם
        private void button1_Click(object sender, EventArgs e)
        {
            panelDonate.Controls.Clear();
            UserControlAddDonate uso = new UserControlAddDonate();     
            panelDonate.Controls.Add(uso);
            uso.Dock = DockStyle.Fill;
        }

        //פתיחת היוזר של עדכון תורם
        private void button3_Click(object sender, EventArgs e)
        {
            string tz = "";

            //בודק אם יש שורות בדאטא גריביו
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Cells[0] != null)
            {
                tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }

            //אם נבחרה שורה
            if (tz != "")
            {
                UserControlAddDonate uco = new UserControlAddDonate(tz);
                panelDonate.Controls.Add(uco);
                panelDonate.Controls.Remove(this);
                uco.Dock = DockStyle.Fill;
            }
            //אם לא נבחרה שורה
            else
            {
                MessageBox.Show("לא נמצא תורם לעדכן", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //פתיחת היוזר של ההוספת חולה
        private void buttensearch_Click(object sender, EventArgs e)
        {
            panelDonate.Controls.Clear();
            UserControlSearchDonatecs uso = new UserControlSearchDonatecs();     
            panelDonate.Controls.Add(uso);
            uso.Dock = DockStyle.Fill;
        }

        //חזרה לעמוד הראשי
        private void button2_Click(object sender, EventArgs e)     
        {
            this.Hide();                                       
            Form1 uco = new Form1();                 
            uco.Show();
        }
	}
}
