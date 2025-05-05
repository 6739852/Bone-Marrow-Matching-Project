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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Timers;

namespace neomy.GUI
{   
    //טופס של תהליך תרומה
    public partial class Form4 : Form
    {  
        bool x=false;
        Possible_donors ps;
        Possible_donorsDB psDB;

        public Form4()
        {
            InitializeComponent();

            ps = new Possible_donors();
            psDB = new Possible_donorsDB();
        }

        //פתיחת היוזר של תוצאות חיפוש
        private void button1_Click(object sender, EventArgs e)
        {  
            ////אתחול התרומות של אותו חולה
            ////Possible_donorsDB psDB = new Possible_donorsDB();
            //psDB = psDB.GetList().Find(a => a.Tz_sick == textBox1.Text && a.the_selected_donor == true);


            // Sick result=null;
            SickDB tblSick = new SickDB();
            
            //בדיקה אם יש חולה עם בעל מספר תעודת זהות כזאת ואם לא אז שלא ימשיך, כי אחרת זה יפול
            Sick sick = new Sick();
            sick = tblSick.SearchId(textBox1.Text);
           

            //אם אין אז שיפלוט את הודעה
            if (/*result*/ sick== null)
            {
                MessageBox.Show("  אין במערכת חולה בעל תעודת זהות מספר " + textBox1.Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
               
                Possible_donors p= new Possible_donors();
                p = psDB.GetList().Find(a => a.Tz_sick == textBox1.Text && a.the_selected_donor == true);
                //אם הוא נמצא ואין לו תורם שנבחר אז שיפתח את היוזר
                if(p==null)
                {
                   panel1.Controls.Clear();
                   UserControlPossible_donors uso = new UserControlPossible_donors(textBox1.Text);
                   panel1.Controls.Add(uso);
                   uso.Dock = DockStyle.Fill;
                }
                //אחרת עם יש כזה חולה ויש לו כבר תורם- הוא נמצא בתהליך תרומה אז שיציג הודעת שגיאה
                else
                {
                    MessageBox.Show("החולה נמצא בתהליך השתלה");
                }
            } 
        }

        //חזרה לעמוד הראשי
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();                                          
            Form1 uco = new Form1();
            uco.Show();
        }
        
        //פתיחת היוזר של תהליכים
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlTahalich1 uso = new UserControlTahalich1();      
            panel1.Controls.Add(uso);
            uso.Dock = DockStyle.Fill;
        }

    }
}
