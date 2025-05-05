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

namespace neomy.GUI  //עדכון התורם שנבחר על ידי הרופא
{
    public partial class UserControlTahalich2 : UserControl
    {
        Possible_donorsDB pdDonorsDB;
        Possible_donors psDonors;
        List<Possible_donors> filteredList; 
        string xx = "";

        public UserControlTahalich2(string tz_sick)
        {
            InitializeComponent();

            psDonors = new Possible_donors();
            pdDonorsDB = new Possible_donorsDB();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            xx = tz_sick; 
            List<Possible_donors> donorsList = pdDonorsDB.GetList();
            filteredList = new List<Possible_donors>();
            //psDonors = donorsList.FirstOrDefault(d => d.Tz_sick == x && d.the_selected_donor);

            // קבל את כל רשימת התורמים הפוטנציאליים
            // מסנן את כל התורמים עם התעודת זהות שווה
            // ואת כל התורמים שהם זמינים
            filteredList = donorsList.Where(d => d.Tz_sick == xx && d.the_selected_donor == false).ToList();

            
            //ואז הוא פותח לי את הדאטא גריביו לפי הסינון
            dataGridView1.DataSource = filteredList.Select(x => new { תעודת_זהות_תורם = x.Tz_donor, תעודת_זהות_חולה = x.Tz_sick, סטטוס = x.Status, שלב_התרומה = x.donation_phase, התורם_הנבחר = x.the_selected_donor }).ToList();
            dataGridView1.ReadOnly = true;
        }
        
        //סגירת היוזר של עדכון התורם הנבחר
        private void button4_Click(object sender, EventArgs e)
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

        //עדכון התורם הנבחר
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //מקבל את הערך של התעודת זהות של התורם בדאטאגריביו
                string tz = dataGridView1.SelectedRows[0].Cells["תעודת_זהות_תורם"].Value.ToString();

                // מציאת התורם באקסס
                psDonors = pdDonorsDB.GetList().FirstOrDefault(x=>x.Tz_donor==tz && x.Tz_sick==xx);

                if (psDonors != null)
                {
                    // עדכון התורם הנבחר ל-אמת
                    psDonors.the_selected_donor = true;

                    // עדכון באקסס
                    pdDonorsDB.UpdateRow(psDonors);

                    // עדכון הדאטא גריביו
                    UpdateDataGridView();

                    MessageBox.Show("העדכון בוצעה בהצלחה");
                }
                else
                {
                    MessageBox.Show("לא נמצא תורם", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //יוצא מהיוזר של עדכון התורם
                panel1.Visible = false;
                Control c = this.Parent;
                while (!(c is Form4))
                    c = c.Parent;
                (c as Form4).panel1.Controls.Clear();
                UserControlTahalich1 uc = new UserControlTahalich1();
                (c as Form4).panel1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("לא נבחרה שורה", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // פעולה שמעדכנת את הדאטא גריביו  
        private void UpdateDataGridView()
        {
            // מסנן את כל התורמים עם התעודת זהות שווה
            // ואת כל התורמים שהם זמינים
            filteredList = pdDonorsDB.GetList().Where(d => d.Tz_sick == xx && d.the_selected_donor == false).ToList();

            // עדכון הדאטא גריביו
            dataGridView1.DataSource = filteredList.Select(x => new { תעודת_זהות_תורם = x.Tz_donor, תעודת_זהות_חולה = x.Tz_sick, סטטוס = x.Status, שלב_התרומה = x.donation_phase, התורם_הנבחר = x.the_selected_donor }).ToList();
        }
    }
}