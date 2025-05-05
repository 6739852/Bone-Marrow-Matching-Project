using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using neomy.Bll;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace neomy.GUI
{
    public partial class UserControlSearchSick : UserControl  //חיפוש חולה
    {
        public UserControlSearchSick()
        {
            InitializeComponent();
        }
  
        SickDB tblSick= new SickDB();

        //לולאה שמחפשת את החולה המבוקש
        private void button1_Click(object sender, EventArgs e)          
        {
           
            foreach (Control item in Parent.Parent.Controls)
            {
                if (item.Name=="dataGridView1")
                {
                    ((DataGridView)item).DataSource=tblSick.GetList().Where(s => s.Tz.StartsWith(textBox1.Text)).Select(x => new { תעודת_זהות = x.Tz, שם_פרטי = x.First_name, שם_משפחה = x.Last_name, עיר = x.CitiesOfSick().Name_city, טלפון = x.Numbber_phone, תאריך_לידה = x.Date_of_birth, סטטוס = x.Status }).ToList();
                }
            }        
        }

        //כפתור שסוגר את היוזר קונטרול של חיפוש חולה
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this); 
        }
    }
}
