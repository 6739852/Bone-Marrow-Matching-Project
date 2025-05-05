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

namespace neomy.GUI //הוספה או עדכון אנטיגנים לחולה
{
    public partial class UserControlAntigenSick : UserControl
    {
        Sick s;
        SickDB sDB;
        Antigen_SickDB tblAntigen_sick;
        Antigen_Sick a;
        bool flagUpdate = false;  //האם זה עדכון

        //פעולה בונה בסיסית
        public UserControlAntigenSick()  
        {
            InitializeComponent();
            tblAntigen_sick = new Antigen_SickDB();
            sDB = new SickDB();
            a = new Antigen_Sick();
        }
      
        //פעולה בונה שמקבלת חולה
        public UserControlAntigenSick(Sick s) : this()
        {
            this.s = s;    //פעולה בונה המקבלת תורם ושומרת במקומי
            label16.Text = s.Tz; //מכניס את הת"ז של התורם אוטומטי  
            a.Numbber_checking= tblAntigen_sick.GetNextKey();
            label17.Text= a.Numbber_checking.ToString();
          
            // בדיקה אם כבר קיים במערכת אם כן שיציג נתונים ולשנות דגל
            if (sDB.SearchId(s.Tz) != null)
            {
                flagUpdate = true;
                a = tblAntigen_sick.SearchId(s.Tz);
                FillTxt();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CreateD())
            {
                bool b = false;
                if (!flagUpdate)
                {
                    sDB.AddNew(s);// הוספה של פרטי החולה
                    tblAntigen_sick.AddNew(a); // הוספה של האנטיגנים לחולה             
                    panel1.Controls.Clear(); //ניקוי הפנל
                }
                else
                    tblAntigen_sick.UpdateRow(a);
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

                if (comboBox1.SelectedIndex<0)
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
                if (comboBox2.SelectedIndex==-1)
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
                if (comboBox3.SelectedIndex < 0)
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

                if (comboBox4.SelectedIndex < 0)
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

                if (comboBox5.SelectedIndex < 0)
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

                if (comboBox6.SelectedIndex < 0)
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

                if (comboBox7.SelectedIndex < 0)
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

                if (comboBox8.SelectedIndex < 0)
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

                if (comboBox9.SelectedIndex < 0)
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

                if (comboBox10.SelectedIndex < 0)
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
           
            try//ת"ז תורם
            {

                if (label16.Text == "")
                    throw new Exception("שדה חובה");
                a.Tz_sick = label16.Text;
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
            a.Status = true;

            return flag;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        //פעולה שממלא את פרטי האטיגנים של החולה בעדכון
        private void FillTxt()
        {
            //textBox1.Text = a.Numbber_checking.ToString();
            label16.Text = a.Tz_sick.ToString();
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
