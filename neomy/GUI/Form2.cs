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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace neomy
{
    //טופס של חולים
    public partial class Form2 : Form
    {
        SickDB sick2;
      
        public Form2()
        {
            //פעולה שבונה את הטופס
            InitializeComponent();     

            sick2 = new SickDB();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = sick2.GetList().Select(x=> new { תעודת_זהות = x.Tz, שם_פרטי = x.First_name, שם_משפחה = x.Last_name, עיר = x.CitiesOfSick().Name_city, טלפון = x.Numbber_phone, תאריך_לידה = x.Date_of_birth, משקל = x.Weight, בית_חולים = x.HospitalOfSick().Name_hospital, סטטוס = x.Status, }).ToList(); //פתיחה של הדאטה גריביו של החולים
            dataGridView1.ReadOnly = true;

            this.Cursor = Cursors.Default;
            button1.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            button5.Cursor = Cursors.Hand;
            buttensearch.Cursor = Cursors.Hand;  
        }

        // חזרה לעמוד הראשי
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();                              
            Form1 uco = new Form1();                   
            uco.Show();
        }

        //(פתיחת היוזר של העדכון(הוספה
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
                UserControlAddSick uco = new UserControlAddSick(tz);
                panelSick.Controls.Add(uco);
                panelSick.Controls.Remove(this);
                uco.Dock = DockStyle.Fill;
            }
            //אם לא נבחרה שורה
            else
            {
                MessageBox.Show("לא נמצא חולה לעדכן", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //פתיחת היוזר של חיפוש חולה
        private void buttensearch_Click(object sender, EventArgs e)
        {
            panelSick.Controls.Clear();
            UserControlSearchSick uso = new UserControlSearchSick();   
            panelSick.Controls.Add(uso);
            uso.Dock = DockStyle.Fill;
        }

        //פתיחת היוזר של עדכון חולה
        private void button1_Click(object sender, EventArgs e)
        {
            panelSick.Controls.Clear();
            UserControlAddSick uso = new UserControlAddSick();       
            panelSick.Controls.Add(uso);
            uso.Dock = DockStyle.Fill;
        }
    }
}
