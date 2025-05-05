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

namespace neomy.GUI  // הוספה או עדכון אנטיגנים לתורם
{
    public partial class UserControlAntigenDonor : UserControl
    {
      
        Donor d;
        DonorDB tblDonors;
        Antigen_DonorDB tblAntigen_donor;
        Antigen_Donor a;
        bool flagUpdate = false; //האם זה עדכון
      
        //פעולה בונה בסיסית
        public UserControlAntigenDonor()            
        {
            InitializeComponent();
            tblAntigen_donor = new Antigen_DonorDB();
            tblDonors = new DonorDB();
            a = new Antigen_Donor();
          
        }

        //פעולה בונה שמקבלת תורם
        public UserControlAntigenDonor(Donor d):this()
        {
            this.d = d;    //פעולה בונה המקבלת תורם ושומרת במקומי
            label16.Text = d.Tz; //מכניס את הת"ז של התורם אוטומטי  
            a.Numbber_checking= tblAntigen_donor.GetNextKey();// מכניס את מספר הבדיקה
            label17.Text=a.Numbber_checking.ToString();
            
            // בדיקה אם כבר קיים במערכת אם כן שיציג נתונים ולשנות דגל
            if (tblDonors.SearchId(d.Tz) != null)
            {
                flagUpdate = true;
                a = tblAntigen_donor.SearchId(d.Tz);
                FillTxt();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (CreateD())
            {
                bool b = false;
                if (!flagUpdate)
                {         
                  tblDonors.AddNew(d);// הוספה של פרטי התורם
                  tblAntigen_donor.AddNew(a); // הוספה של האנטיגנים לתורם             
                  panel1.Controls.Clear(); //ניקוי הפנל
               
                }
                else
                    tblAntigen_donor.UpdateRow(a);
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";
                comboBox9.Text = "";
                comboBox10.Text = "";
                comboBox11.Text = "";
                comboBox12.Text = "";
                label16.Text = "";
                //textBox1.Text = "";

                if (!b)
                    MessageBox.Show("הנתונים נשמרו בהצלחה");
                    panel1.Controls.Clear();
            }
        }
        private bool CreateD()
        {
            errorProvider1.Clear();
            bool flag = true;
            try//אנטיגן A1 
            {

                if (comboBox1.Text == "")
                    throw new Exception("שדה חובה");
                a.Hla_A1 = Convert.ToInt32(comboBox1.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox1, ex.Message);
                flag = false;
            }
            try//אנטיגן A2
            {
                if (comboBox2.Text == "")
                    throw new Exception("שדה חובה");
                a.Hla_A2 = Convert.ToInt32(comboBox2.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox2, ex.Message);
                flag = false;

            }
            try//אנטיגן B1
            {
                if (comboBox3.Text == "")
                    throw new Exception("שדה חובה");

                a.Hla_B1 = Convert.ToInt32(comboBox3.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox3, ex.Message);
                flag = false;

            }
            try//אנטיגן B2
            {

                if (comboBox4.Text == "")
                    throw new Exception("שדה חובה");
                a.Hla_B2 = Convert.ToInt32(comboBox4.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox4, ex.Message);
                flag = false;

            }

            try//אנטיגן C1
            {

                if (comboBox5.SelectedIndex == -1)
                    throw new Exception("שדה חובה");
                a.Hla_C1 = Convert.ToInt32(comboBox5.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox5, ex.Message);
                flag = false;

            }
            try//אנטיגן C2
            {

                if (comboBox6.Text == "")
                    throw new Exception("שדה חובה");
                a.Hla_C2 = Convert.ToInt32(comboBox6.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox6, ex.Message);
                flag = false;

            }
            try//אנטיגן DQ1
            {

                if (comboBox7.Text == "")
                    throw new Exception("שדה חובה");
                a.Hla_DQ1 = Convert.ToInt32(comboBox7.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox7, ex.Message);
                flag = false;

            }
            try//אנטיגן DQ2
            {

                if (comboBox8.Text == "")
                    throw new Exception("שדה חובה");
                a.Hla_DQ2 = Convert.ToInt32(comboBox8.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox8, ex.Message);
                flag = false;

            }
            try//אנטיגן DRBI1
            {

                if (comboBox9.Text == "")
                    throw new Exception("שדה חובה");
                a.Hla_DRBI1 = Convert.ToInt32(comboBox9.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox9, ex.Message);
                flag = false;

            }
            try//אנטיגן DRBI2
            {

                if (comboBox10.Text == "")
                    throw new Exception("שדה חובה");
                a.Hla_DRBI2 = Convert.ToInt32(comboBox10.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox10, ex.Message);
                flag = false;

            }
            try//סוג דם
            {

                if (comboBox11.SelectedIndex == -1)
                    throw new Exception("שדה חובה");
                a.Blood_type = comboBox11.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox11, ex.Message);
                flag = false;

            }
            
            try// תורם תעודת זהות
            {

                if (label16.Text == "")
                    throw new Exception("שדה חובה");
                a.Tz_donor = label16.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(label16, ex.Message);
                flag = false;
            }
           
            try//סטטוס
            {

                if (comboBox12.SelectedIndex == -1)
                    throw new Exception("שדה חובה");
                a.Status = Convert.ToBoolean(comboBox12.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox12, ex.Message);
                flag = false;

            }
            //a.Status = true;

            return flag;
        }

        //פעולה שממלא את פרטי האנטיגנים של התורם בעדכון
        private void FillTxt()
        {
            //textBox1.Text = a.Numbber_checking.ToString();
            label16.Text = a.Tz_donor.ToString();
            comboBox1.Text = a.Hla_A1.ToString();
            comboBox2.Text = a.Hla_A2.ToString();
            comboBox3.Text = a.Hla_B1.ToString();
            comboBox4.Text = a.Hla_B2.ToString();
            comboBox5.Text = a.Hla_C1.ToString();
            comboBox6.Text = a.Hla_C2.ToString();
            comboBox7.Text = a.Hla_DQ1.ToString();
            comboBox8.Text = a.Hla_DQ2.ToString();
            comboBox9.Text = a.Hla_DRBI1.ToString();
            comboBox10.Text = a.Hla_DRBI2.ToString();
            comboBox11.Text = a.Blood_type.ToString();
            comboBox12.Text = a.Status.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
