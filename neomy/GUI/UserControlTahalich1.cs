using neomy.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace neomy.GUI//דיסק און קי
{
    public partial class UserControlTahalich1 : UserControl  //היוזר הראשי של תהליכי השתלה
    {
        Possible_donors pd = new Possible_donors();
        Possible_donorsDB possible_DonorsDB = new Possible_donorsDB();
        bool x;

        public UserControlTahalich1()
        {
            InitializeComponent();

            x = false;
        }

        //פתיחת היוזר של עדכון התורם הנבחר על ידי הרופא
        private void button1_Click(object sender, EventArgs e)
        {
            string result = null;
            //בדיקה אם יש חולה עם בעל תעודת זהות כזאת ואם לא אז שלא ימשיך, כי אחרת זה יפול
            foreach (Possible_donors pd in possible_DonorsDB.GetList())
            {
                if (pd.Tz_sick == textBox1.Text)
                {
                    result = pd.Tz_sick;
                    //האם החולה כבר נמצא בתהליך השתלה
                    if (pd.the_selected_donor == true)
                    {
                        x = true;
                    }
                }
            }
            
            //אם אין אז שיפלוט את הודעה
            if (result == null)
            {
                MessageBox.Show("אין במערכת חולה שנמצא בתהליך השתלה בעל תעודת זהות מספר " + textBox1.Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            //אם לחולה יש כבר תורם נבחר והוא נמצא בתהליך השתלה אז שיציגאת ההודעה
            if(x == true)
            {
                MessageBox.Show("החולה כבר נמצא בתהליך השתלה " , "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            //הוא יפתח לי את היוזר של עדכון התורם הנבחר כאשר הוא ימצא לי את החולה
            if(x == false && result != null)
            {
                panel1.Controls.Clear();
                UserControlTahalich2 uso = new UserControlTahalich2(textBox1.Text);
                panel1.Controls.Add(uso);
                uso.Dock = DockStyle.Fill;
            } 
        }
        
        //סגירת היוזר של תרומות בתהליך
        private void button4_Click(object sender, EventArgs e)
        {
            //UserControlTahalich1 us = new UserControlTahalich1();
            //Parent.Controls.Add(us);
            Parent.Controls.Remove(this);
            //us.Dock = DockStyle.Fill;();
            Form4 uco = new Form4();
            uco.Show();
        }

       
        //הפיכה של הגרופבוקס לנירא//של עדכון התורם הנבחר
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = true;
        }

        //הפיכה של הגרופבוקס לנירא//של עדכון תהליך תרומה
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox2.Visible = true;
        }
        
        //פתיחת היוזר של עדכון שלבי התרומה
        private void button2_Click(object sender, EventArgs e)
        {
            Possible_donors p = new Possible_donors();
            string result = null;
           
            //בדיקה אם יש חולה עם בעל תעודת זהות כזאת ואם לא אז שלא ימשיך, כי אחרת זה יפול
            foreach (Possible_donors pd in possible_DonorsDB.GetList())
            {
                if (pd.Tz_donor == textBox2.Text) 
                {
                    if (pd.the_selected_donor == true)
                    {
                        result = pd.Tz_donor;
                    }
                }
            }

            //אם אין אז שיפלוט את הודעה
            if (result == null)
            {
                MessageBox.Show("אין במערכת תורם בתהליך תרומה בעל תעודת זהות מספר " + textBox2.Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            //הוא יפתח את היוזר של תהליך התרומה כאשר הוא מצא את התורם
            else
            {   
                panel1.Controls.Clear();
                UserControlTahalich3 uso = new UserControlTahalich3(textBox2.Text);
                panel1.Controls.Add(uso);
                uso.Dock = DockStyle.Fill;
            } 
        }

        //פתיחת היוזר של קביעת השתלה 
        private void button3_Click(object sender, EventArgs e)
        {
            string result = null;
            
            //בדיקה אם יש תורם עם בעל תעודת זהות כזאת ואם לא אז שלא ימשיך, כי
            //אחרת זה יפול
            foreach (Possible_donors d in possible_DonorsDB.GetList())
            {
                if (d.Tz_donor == textBox3.Text)
                {
                    result = d.Tz_donor;
                }
            }

            //אם אין אז שיפלוט את הודעה
            if (result == null)
            {
                MessageBox.Show("אין במערכת תורם הנמצא בתהליך השתלה בעל תעודת זהות מספר " + textBox3.Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            //שיפתח את היוזר של קביעת השתלה כשאר הוא מצא את התורם
            else
            {
                panel1.Controls.Clear();
                UserControlTahalich4 uso = new UserControlTahalich4(textBox3.Text);
                panel1.Controls.Add(uso);
                uso.Dock = DockStyle.Fill;
            }
        }
    }
}
