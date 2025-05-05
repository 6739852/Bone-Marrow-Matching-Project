using neomy.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace neomy.GUI
{
    public partial class UserControlTahalich3 : UserControl  //שלבי התרומה
    {
        CheckBox[] checkBoxes;
        Possible_donorsDB pdDonorsDB;
        Possible_donors psDonors;
        Possible_donors selectedDonor = null;
        List<Possible_donors> filteredList = new List<Possible_donors>();
        string x = "";
        string selectedDonorId = "";
        //משתנה ששומר מה מספר של שלב התרומה
        int z = 0;

        public UserControlTahalich3(string tz_donor)
        {
            InitializeComponent();
            psDonors = new Possible_donors();
            pdDonorsDB = new Possible_donorsDB();
            x = tz_donor;
            label4.Text = x;
            //מערך של צ'ק בוקסים לשלבי התרומה
            checkBoxes = new CheckBox[4] { checkBox1, checkBox2, checkBox3, checkBox4 };
            ToList();
        }

        private void ToList()
        {
            //מספר תעודת הזהות שהתקבל בטקסט בוקס
            string tzDonor = x;

            //מקבל את רשימת התורמים הפוטנציאלים מהדאטא
            List<Possible_donors> donorsList = pdDonorsDB.GetList();

            // מסנן ובוחר את המישהוא שמספר תעודת הזהות תורם שלו כמו בטקסט בוקס 
            //וגם שהוא התורם  הנבחר- לאותו חולה
            filteredList = donorsList.Where(d => d.Tz_donor == tzDonor && d.the_selected_donor == true).ToList();

            //אם נמצא רק תורם אחד - מה שאמור להיות
            if (filteredList.Count == 1)
            {
                // אז שיכניס אותו לתוך משתנה
                selectedDonor = filteredList[0];
            }
            if (selectedDonor != null)
            {
                 selectedDonorId = selectedDonor.Tz_donor;
            }

            //לשים בללבלים את המספרי תעודות זהות
            label4.Text = selectedDonorId;
            //לעדכן את השלבים שכבר עשו
            SelectCheckbox(selectedDonor.donation_phase);
        }
       
        //פעולה שבודקת כמה צ'קבוקסים מסומנים 
        private int CountCheckedCheckboxes(Control control)
        {
            int count = 0;

            foreach (Control c in control.Controls)
            {
                if (c is CheckBox checkBox && checkBox.Checked)
                {
                    count++;
                }
                else if (c.Controls.Count > 0)
                {
                    count += CountCheckedCheckboxes(c);
                }
            }
            return count;
        }

        //כפתור של עדכון מצב התרומה
        private void button1_Click(object sender, EventArgs e)
        {   //אם  נמצא לאותו חולה תורם 
            if (selectedDonor != null)
            {
                int checkedCount = CountCheckedCheckboxes(this);
                if (checkedCount == 4)
                {
                    MessageBox.Show($"שלבי ההכנה לתרומה הסתיימו, עבור לתאום השתלה");
                    panel1.Controls.Clear();
                    UserControlTahalich4 uso = new UserControlTahalich4(selectedDonor);
                    panel1.Controls.Add(uso);
                    uso.Dock = DockStyle.Fill;
                }
                else
                {
                    //שליחת הודעה על השלב שבה היא נמצאת
                    MessageBox.Show($" שלה התרומה הגיע לרמה: {checkedCount}");
                }
                //עדכון של התרומה במשתנה
                selectedDonor.donation_phase = checkedCount;
                pdDonorsDB.UpdateRow(selectedDonor);
                
            }
            //אם לא נמצא תורם
            if (selectedDonor == null)
            {
                MessageBox.Show("התורם לא נמצא בתהליך השתלה", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
       
        //פעולה שמעדכנת את השלבים שכבר נעשו
        public void SelectCheckbox(int phase)
        {
           for(int i = 0; i < selectedDonor.donation_phase; i++)
           {
                checkBoxes[i].Checked = true;
                checkBoxes[i].Enabled = false;
           } 
        }

       //הסגירה הטובה ביותר, להעתיק לכולם
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Control c = this.Parent;
            while(!(c is Form4))
                c = c.Parent;
            (c as Form4).panel1.Controls.Clear();
            UserControlTahalich1 uc=new UserControlTahalich1();
            (c as Form4).panel1.Controls.Add(uc);    
            uc.Dock = DockStyle.Fill;
        }
    }
}
