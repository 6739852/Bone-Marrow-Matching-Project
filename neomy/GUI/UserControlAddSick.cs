using neomy.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace neomy.GUI //הוספה או עדכון חולה
{
    public partial class UserControlAddSick : UserControl  
    {
        SickDB tblSick;
        CitiesDB tblCity;
        HospitalDB tblHospital;
        Sick s;
        bool flagUpdate = false;  //האם זה עדכון

        //פעולה בונה בסיסית
        public UserControlAddSick() 
        {
            InitializeComponent();

            tblHospital = new HospitalDB();
            tblCity = new CitiesDB();
            comboBox1.DataSource = tblCity.GetList();//.Select(x =>  x.Name_City).ToList();
            comboBox1.SelectedIndex = -1;//שלא יציג פריט בכומבו
            comboBox5.DataSource = tblHospital.GetList();//.Select(x =>  x.Name_hospital).ToList();
            comboBox5.SelectedIndex = -1;//שלא יציג פריט בכומבו
            s = new Sick();
            tblSick = new SickDB();

        }

        //פעולה בונה של עדכון
        public UserControlAddSick(string tz) : this()      
        {
            flagUpdate = true;
            s = tblSick.SearchId(tz);
            FillTxt();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (CreateD())
            {
                bool b = false;
                if (!flagUpdate)  //אם זה לא עדכון
                {
                    //הוספה
                    if (tblSick.SearchId(s.Tz) != null)
                    {
                        s = tblSick.SearchId(s.Tz);
                        if (s.Status == false)
                        {
                            s.Status = true;
                            tblSick.UpdateRow(s);

                        }
                        else
                        {
                            MessageBox.Show("מספר זהות זה כבר קיים במערכת");
                            b = true;
                        }
                    }
                }
                else  // עדכון

                    tblSick.UpdateRow(s);

                if (!b)//אם השמירה הצליחה
                {
                    textBox1.Text = "";     //ריקון כל פרטי התורם
                    textBox2.Text = "";
                    textBox3.Text = "";
                    comboBox1.Text = "";
                    textBox8.Text = "";
                    textBox5.Text = "";
                    comboBox5.Text = "";
                    dateTimePicker1.Text = "";

                    MessageBox.Show("הנתונים נשמרו בהצלחה");
                    panel1addS.Controls.Clear();
                    UserControlAntigenSick uso = new UserControlAntigenSick(s); //פתיחת היוזר של האנטיגנים
                    panel1addS.Controls.Add(uso);
                    uso.Dock = DockStyle.Fill;
                }
            }
        }

        private bool CreateD()
        {
            //errorProvider1.Clear()
            bool flag = true;
            
            try//תעודת זהות
            {

                if (textBox1.Text == "")
                    throw new Exception("שדה חובה");
                s.Tz = textBox1.Text;

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

                s.First_name = textBox2.Text;
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

                s.Last_name = textBox3.Text;

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
                s.City = ((Cities)comboBox1.SelectedItem).Kod;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox1, ex.Message);
                flag = false;

            }
            try//מספר טלפון
            {

                if (textBox5.Text == "")
                    throw new Exception("שדה חובה");
                s.Numbber_phone = textBox5.Text;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(textBox5, ex.Message);
                flag = false;

            }
            try//תאריך לידה
            {

                if (dateTimePicker1.Text == "")
                    throw new Exception("שדה חובה");
                s.Date_of_birth = dateTimePicker1.Value;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(dateTimePicker1, ex.Message);
                flag = false;

            }
            try//משקל
            {

                if (textBox8.Text == "")
                    throw new Exception("שדה חובה");
                s.Weight = Convert.ToDouble(textBox8.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(textBox8, ex.Message);
                flag = false;

            }
            try//בית חולים
            {

                if (comboBox5.SelectedIndex == -1)
                    throw new Exception("שדה חובה");
                s.Hospital = ((Hospital)comboBox5.SelectedItem).Kod;

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox5, ex.Message);
                flag = false;

            }
            try//סטטוס
            {

                if (comboBox4.SelectedIndex == -1)
                    throw new Exception("שדה חובה");
                s.Status = Convert.ToBoolean(comboBox4.Text);

            }
            catch (Exception ex)
            {

                errorProvider1.SetError(comboBox4, ex.Message);
                flag = false;

            }
            s.Status = true;

            return flag;
        }

        //ממלא את פרטי החולה כדי שיהיה אפשר לעדכן
        private void FillTxt()
        {
            textBox1.Text = s.Tz.ToString();
            //שלא יהיה אפשר לשנות את התעודת זהות
            textBox1.ReadOnly = true;
            textBox2.Text = s.First_name.ToString();
            textBox3.Text = s.Last_name.ToString();
            comboBox1.Text = GetCityName(s.City);
            textBox5.Text = s.Numbber_phone.ToString();
            dateTimePicker1.Text = s.Date_of_birth.ToString();
            textBox8.Text = s.Weight.ToString();
            comboBox5.Text = hospitaiNames.ContainsKey(s.Hospital) ? hospitaiNames[s.Hospital] : "";
            comboBox4.Text = s.Status.ToString();
        }

        //פעולה שמקבלת קוד עיר ומחזירה את ערכו במילים- בשביל העדכון
        private string GetCityName(int cityCode)
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

        //פעולה שמטרתה שבעדכון בבית חולים יהיה כתוב במילים ולא את הקוד- הערך המספרי
        Dictionary<int, string> hospitaiNames = new Dictionary<int, string>()
        {
                    { 1, "שיבא- רמת גן" },
                    { 2, "דוידוף- פתח תקווה" },
                    { 3, "הדסה- ירושלים" },
                    { 4, "רמבם- חיפה" },
                    { 5, "סוראסקי- תל אביב" },
                    { 6, "שנידר- פתח תקווה" },
        };

        //כפתור האיקס של הוספה או עדכון חולה
        private void button2_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}