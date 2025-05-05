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

namespace neomy.GUI
{
    public partial class UserControlAntigenimSick : UserControl
    {
        Antigen_Sick Antigen_sick;

        public UserControlAntigenimSick()
        {
            InitializeComponent();
            tblAntigen_sick = new Antigen_SickDB();
            a = new Antigen_Sick();
            Antigen_sick = new Antigen_Sick();
        }


        Antigen_SickDB tblAntigen_sick;


        Antigen_Sick a;
        bool flagUpdate = false;


        private void button1_Click(object sender, EventArgs e)
        {
            if (CreateD())
            {
                bool b = false;
                if (!flagUpdate)
                {

                    if (tblAntigen_sick.SearchId(a.Tz_sick) != null)
                    {
                        a = tblAntigen_sick.SearchId(a.Tz_sick);
                        if (a.Status == false)
                        {
                            a.Status = true;
                            tblAntigen_sick.UpdateRow(a);

                        }
                        else
                        {
                            MessageBox.Show("מספר זהות זה כבר קיים במערכת");
                            b = true;
                        }
                    }
                    else
                    {
                        tblAntigen_sick.AddNew(a);
                    }

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
                comboBox12.Text = "";
                textBox2.Text = "";
                textBox1.Text = "";

                if (!b)
                    MessageBox.Show("הנתונים נשמרו בהצלחה");

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
                a.Hla_A2 = Convert.ToInt32(comboBox4.Text);

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
                a.Hla_A2 = Convert.ToInt32(comboBox5.Text);

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
                a.Hla_A2 = Convert.ToInt32(comboBox6.Text);

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
                a.Hla_A2 = Convert.ToInt32(comboBox7.Text);

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
                a.Hla_A2 = Convert.ToInt32(comboBox8.Text);

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
                a.Hla_A2 = Convert.ToInt32(comboBox9.Text);

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
                a.Hla_A2 = Convert.ToInt32(comboBox10.Text);

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
            try//מספר דגימה
            {

                if (textBox1.Text == "")
                    throw new Exception("שדה חובה");
                a.Status = Convert.ToBoolean(textBox1.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(textBox1, ex.Message);
                flag = false;

            }
            try//ת"ז תורם
            {

                if (textBox2.Text == "")
                    throw new Exception("שדה חובה");
                a.Status = Convert.ToBoolean(textBox2.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(textBox2, ex.Message);
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
    } 
}
