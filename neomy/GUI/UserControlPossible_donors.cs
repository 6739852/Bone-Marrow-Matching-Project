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
using System.Windows;
using System.Resources;
using Microsoft.Office.Interop.Excel;
using System.Net.Sockets;
using System.Net.Mail;
using System.Net;

namespace neomy.GUI  //רשיממת התורמים הפוטנציאלים
{
    public partial class UserControlPossible_donors : UserControl
    {
        Donor donor;
        DonorDB d;
        Sick sick;
        SickDB s; 

        //פעולה בונה שמקבל מספר תעודת זהות
        public UserControlPossible_donors(string tz)
        {
            InitializeComponent();

            //פתיחה של הדאטה גריביו של התרומות האפשריות
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            sick = new SickDB().SearchId(tz); 
            dataGridView1.DataSource = SearchDonrorsAntigen().Select(x => new { תעודת_זהות_תורם = x.Tz, מספר_פלאפון= x.Numbber_phone,שם_תורם= x.First_name, שם_משפחה= x.Last_name,איכות_התרומה=x.GetLevel, סטטוס= x.Status }).ToList();
            //מה זה??
            AddPossibleDonors();
            d = new DonorDB();
        }

        //פעולה שקוראת לפעולה של בדיקת אנטיגנים
        private List<Donor> SearchDonrorsAntigen()
        {
            
            //מחפש רק על התורמים עם סוג דם מתאים
            return SearchDonrorsBloodType().Where(x=>x.CheckAntigen(sick)>=8 && CheckPosibll(x) ).ToList();    
        }

        private bool CheckPosibll(Donor d)
        {
          return  new Possible_donorsDB().GetList().FirstOrDefault(x => x.Tz_donor == d.Tz && x.the_selected_donor)==null;
        }

        // בודק התאמה של סוגי דם ומחזיר את התורמים המתאימים לאותו חולה
        private List<Donor> SearchDonrorsBloodType()
        {
            string sickBloodType = sick.Antigen_SickOfSick().Blood_type; // מקבל את סוג הדם של החולה
            List<Donor> donors = new DonorDB().GetList(); // מקבל את כל הרשימה של החולים

            // מסנן לכל החולים עם סוג הדם המתאים שאו שהוא שווה או שהוא סוג דם 0 המתאים לכולם
            List<Donor> compatibleDonors = donors.Where(d => d.Antigen_DonorOfDonor().Blood_type == sickBloodType || d.Antigen_DonorOfDonor().Blood_type == "O").ToList();

            //מחזיר את התורמים התואמים
            return compatibleDonors;
        }

        // הורדת קובץ אקסל עם הפרטים של הדאטא גריביו
        private void button1_Click(object sender, EventArgs e)
        {
            // יצירת יישום Excel 
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
           
            //יצירת ספר עבודה חדש בתוך יישום Excel  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
           
            // יצירת גיליון אקסל חדש בחוברת עבודה
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // ראה את גיליון האקסל מאחורי התוכנית 
            app.Visible = true;
           
            // קבל את ההפניה של הגיליון הראשון. כברירת מחדל שמו הוא Sheet1.  
            // אחסן את ההתייחסות שלו לגליון עבודה
            //   worksheet = workbook.Sheets["גיליון1"];
            worksheet = workbook.ActiveSheet;
           
            // שינוי השם של הגיליון הפעיל 
            worksheet.Name = "רשימת תורמים פוטנציאלים";
           
            // אחסון חלק הכותרת באקסל 
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
           
            // אחסון כל ערך שורה ועמודה לגיליון אקסל
            for (int i = 0; i < dataGridView1.Rows.Count /*- 1*/ ; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            //אני עשיתי שזה לא ישמור אוטומטי ויעשו בזה שינויים // לשמור באת האפליקציה  
            //workbook.SaveAs("C:\\Users\\Neomi\\Desktop\\neomy"); ;
            ////workbook.SaveAs("C:\\excel_files\\stuff\\details", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // צא מהאפליקציה
            app.Quit(); 
        }

        //פעולה ששולחת לרופא את קובץ האקסל//צריך להוריד את רמת האבטחה במייל  
        private void button2_Click(object sender, EventArgs e)
        {
            string recipientEmail = "6739852@gmail.com";
            string senderEmail = "paulinabgnh@gmail.com";
            MailMessage emailMessage = new MailMessage();
            emailMessage.To.Add(recipientEmail);
            emailMessage.From = new MailAddress(senderEmail);
            emailMessage.Subject = "Your Excel file";
            emailMessage.Body = "Please find attached your Excel file.";

            Attachment attachment = new Attachment(@"C:\Users\נעמי\Desktop\neomy\sos.xlsx");
            emailMessage.Attachments.Add(attachment);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("paulinabgnh@gmail.com", "bgnhptukhbv");

            //אם ההודעה נשלחה אז יציג את ההודעה הזאת
            try
            {
                client.Send(emailMessage);
                MessageBox.Show("Email sent successfully!");
            }
            //אם ההודעה לא נשלחה שיציג את ההודעה הזאת 
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }
        
        Possible_donors pd;
        Possible_donorsDB pdDB;
        
        //הוספת התורמי האפשריים מאדאטא גריביו לאקסס
        public void AddPossibleDonors()
        {
            pd = new Possible_donors();
            pdDB = new Possible_donorsDB();

            //עובר על הדאטא גריביו ומכניס לאקסס
            foreach (DataGridViewRow itemRow in dataGridView1.Rows)
            {   
                //בדיקה אם כבר קיים באקסס
                pd = pdDB.GetList().FirstOrDefault(x=>x.Tz_sick==sick.Tz && x.Tz_donor== itemRow.Cells[0].Value.ToString());
              
                //אם לא קיים אז שיוסיף
                if (pd == null)
                {
                    pd = new Possible_donors();
                    //להכנסת הנתונים לתורמים הפוטנציאליים
                    pd.Tz_donor = itemRow.Cells[0].Value.ToString();
                    pd.Tz_sick = sick.Tz;
                    pd.Status = true;
                    pd.donation_phase = 0;
                    pd.the_selected_donor = false;

                    //הכנסה לאקסס
                    new Possible_donorsDB().AddNew(pd);
                }
            }
        }

        // לסגור את היוזר הזה
        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
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
