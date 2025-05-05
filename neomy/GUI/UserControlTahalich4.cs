using neomy.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace neomy.GUI
{
    public partial class UserControlTahalich4 : UserControl
    {
        List<Possible_donors> p = new List<Possible_donors>();
        Possible_donors pd;
        Possible_donorsDB pdDB;
        Donor donor = new Donor();
        Sick sick = new Sick();
        Donations_made z = new Donations_made();
        Donations_madeDB zDB = new Donations_madeDB();
        bool flag = false;
        HospitalDB tblHospital = new HospitalDB();
        Hospital h = new Hospital();

        public UserControlTahalich4(string tz)
        {
            InitializeComponent();

            pdDB = new Possible_donorsDB();
            pd = new Possible_donors();

        }

        // פעולה בונה שנפתחת משלבי התרומה
        public UserControlTahalich4(Possible_donors pd):this(pd.Tz_sick)
        {
            this.pd = pd;
            //הכנסת התורם
            textBox2.Text = pd.Tz_donor;
            //הכנסת החולה
            textBox1.Text = pd.Tz_sick;
            //הכנסת הבית חולים
            textBox3.Text = pd.SickOfPossible_donors(pd.Tz_sick).HospitalOfSick().Name_hospital;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            Donations_made d1 = new Donations_made();
            Donations_made d2 = new Donations_made();
            Donations_madeDB md = new Donations_madeDB();

            //אם כל הפרטים נכנסו 
            if (CreateD()) 
            { 
               zDB.AddNew(z);// הוספה של פרטי החולה
               //שיפלוט הודעה אם זה הוסיף ואז לסגוראת היוזר ואז להעביר אותו לאן שהוא
               MessageBox.Show(" ההשתלה נקבעה בהצלחה ,אתה מועבר לדף הבית");
               
               //מאתחל את ההשתלה שהתורם כבר לא יהיה שייך אליו
               pd.The_selected_donor = false;
               pd.donation_phase= 0;
               pdDB.UpdateRow(pd);
                
               //מעבר לדף הבית
               this.Hide();
               Form1 uco = new Form1();
               uco.Show();
            }
        }

        private bool CreateD()
        {
            errorProvider1.Clear();
             flag = true;

            try//תעודת זהות חולה
            {
                if (textBox1.Text == "")
                    throw new Exception("שדה חובה");
                z.Tz_sick = textBox1.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
                flag = false;
            }
            try//תעודת זהות תורם
            {
                if (textBox2.Text == "")
                    throw new Exception("שדה חובה");

                z.Tz_donor = textBox2.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox2, ex.Message);
                flag = false;
            }
            try//בית חולים  
            {
                if (textBox3.Text == "")
                    throw new Exception("שדה חובה");
                z.Hospitail =new HospitalDB().GetList().FirstOrDefault(x=>x.Name_hospital== textBox3.Text).Kod;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox3, ex.Message);
                flag = false;
            }
            try//תאריך תרומה
            {
                if (dateTimePicker1.Text == "")
                    throw new Exception("שדה חובה");

                z.Date_of_donation = dateTimePicker1.Value;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox2, ex.Message);
                flag = false;
            }
            z.Kod_donation = zDB.GetNextKey();
           
            return flag;
        }

        //כפתור לסגירת היוזר
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Control c = this.Parent;
            while (!(c is Form4))
                c = c.Parent;
            (c as Form4).panel1.Controls.Clear();
            UserControlTahalich1 uc = new UserControlTahalich1();
            (c as Form4).panel1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}
