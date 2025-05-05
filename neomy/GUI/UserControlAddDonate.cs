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
 

namespace neomy.GUI //הוספה או עדכון תורם
{
    public partial class UserControlAddDonate : UserControl 
    {
        DonorDB tblDonates;
        CitiesDB tblCity;
        Donor d;
        bool flagUpdate = false; //האם זה עדכון

        //פעולה בונה בסיסית
        public UserControlAddDonate()  
        {
            InitializeComponent();

            tblCity = new CitiesDB();
            comboBox1.DataSource = tblCity.GetList();//.Select(x =>  x.Name_City).ToList();
            comboBox1.SelectedIndex = -1;//שלא יציג פריט בכומבו
            d = new Donor();
            tblDonates = new DonorDB();
        }

        //פעולה בונה של עדכון
        public UserControlAddDonate(string tz) : this()    
        {
            flagUpdate = true;
            d = tblDonates.SearchId(tz);
            FillTxt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CreateD())
            {
                bool b = false;
                if (!flagUpdate)  //אם זה לא עדכון
                {
                    //הוספה
                    if (tblDonates.SearchId(d.Tz) != null)
                    {
                        d = tblDonates.SearchId(d.Tz);
                        if (d.Status == false)
                        {
                            d.Status = true;
                            tblDonates.UpdateRow(d);

                        }
                        else
                        {
                            MessageBox.Show("מספר זהות זה כבר קיים במערכת");
                            b = true;
                        }
                    }
                }
                else//עדכון
                    tblDonates.UpdateRow(d);

                if (!b)//אם השמירה הצליחה
                {
                    textBox1.Text = "";     //ריקון כל פרטי התורם
                    textBox2.Text = "";
                    textBox3.Text = "";
                    comboBox1.Text = "";
                    textBox6.Text = "";
                    textBox11.Text = "";
                    comboBox5.Text = "";
                    dateTimePicker1.Text = "";

                    MessageBox.Show("הנתונים נשמרו בהצלחה");
                    panel1.Controls.Clear();   
                    UserControlAntigenDonor uso = new UserControlAntigenDonor(d);//פתיחת היוזר של האנטיגנים
                    panel1.Controls.Add(uso);
                    uso.Dock = DockStyle.Fill;
                }
            }
        }
      
        private bool CreateD()
        {
            errorProvider1.Clear();
            bool flag = true;
            try//תעודת זהות
            {

                if (textBox1.Text == "")
                    throw new Exception("שדה חובה");
                d.Tz = textBox1.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(textBox1, ex.Message);
                flag = false;
            }
            try//שם פרטי
            {
                if (textBox2.Text == "")
                    throw new Exception("שדה חובה");

                d.First_name = textBox2.Text;
            }
            catch (Exception ex)
            {

                errorProvider1.SetError(textBox2, ex.Message);
                flag = false;

            }
            try//שם משפחה
            {
                if (textBox3.Text == "")
                    throw new Exception("שדה חובה");

                d.Last_name = textBox3.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(textBox3, ex.Message);
                flag = false;

            }
            try//עיר
            {

                if (comboBox1.SelectedIndex == -1)
                    throw new Exception("שדה חובה");
                d.City = ((Cities)comboBox1.SelectedItem).Kod;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox1, ex.Message);
                flag = false;

            }
            try//מספר טלפון
            {

                if (textBox6.Text == "")
                    throw new Exception("שדה חובה");
                d.Numbber_phone = textBox6.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(textBox6, ex.Message);
                flag = false;

            }
            try//תאריך לידה
            {

                if (dateTimePicker1.Text == "")
                    throw new Exception("שדה חובה");
                d.Date_of_birth = dateTimePicker1.Value;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(dateTimePicker1, ex.Message);
                flag = false;

            }

            try//משקל
            {

                if (textBox11.Text == "")
                    throw new Exception("שדה חובה");
                d.Weight = Convert.ToInt32(textBox11.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(textBox11, ex.Message);
                flag = false;

            }
            try//סטטוס
            {

                if (comboBox5.SelectedIndex == -1)
                    throw new Exception("שדה חובה");
                d.Status = Convert.ToBoolean(comboBox5.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox5, ex.Message);
                flag = false;

            }
            d.Status = true;

            return flag;
        }

        //פעולה שממלא את פרטי התורם בעדכון
        private void FillTxt()  
        {   textBox1.Text=d.Tz.ToString();
            //שלא יהיה אפשר לשנות את התעודת זהות
            textBox1.ReadOnly = true;
            textBox2.Text = d.First_name.ToString();
            textBox3.Text = d.Last_name.ToString();
            comboBox1.Text = GetCityName(d.City);
            textBox6.Text = d.Numbber_phone.ToString();
            dateTimePicker1.Text = d.Date_of_birth.ToString();
            textBox11.Text = d.Weight.ToString();
            comboBox5.Text = d.Status.ToString();
        }

        //פעולה שמקבלת קוד עיר ומחזירה את ערכו במילים- בשביל העדכון
        public string GetCityName(int cityCode)//פעולה שמקבלת קוד עיר ומחזירה את ערכו במילים- בשביל העדכון
        {
            string cityName = "";
          
            switch (cityCode)
            {
                case 1:
                    cityName = "אלעד";
                    break;
                case 2:
                    cityName = "באר שבע";
                    break;
                case 3:
                    cityName = "בני ברק";
                    break;
                case 4:
                    cityName = "חיפה";
                    break;
                case 5:
                    cityName = "ירושלים";
                    break;
                case 6:
                    cityName = "נתניה";
                    break;
                case 7:
                    cityName = "פתח תקווה";
                    break;
                case 8:
                    cityName = "ראשון לציון";
                    break;
                case 9:
                    cityName = "רחובות";
                    break;
                case 10:
                    cityName = "תל אביב-יפו";
                    break;
            }
           return cityName;
        }

        //כפתור שסוגר את היוזר קונטרול של ההוספה והעדכון
        private void button2_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
