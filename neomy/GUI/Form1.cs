using System;
using System.Windows.Forms;

namespace neomy.GUI
{  
    //טופס ראשי - דף הבית
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //לאיזה משתמש הוא שייך
            chazor();
        }
        public void chazor()
        {
            if (Validation.user == "manager")
            {
               buttonAllogeneic.Visible = true;
               buttonDonation.Visible = true;
               buttonSick.Visible = true;
               buttonDonate.Visible = true;
            }
            if (Validation.user == "remindsPassword")
            {
                buttonDonate.Visible = true;
                buttonSick.Visible=true;
                buttonDonation.Visible=true;
                buttonAllogeneic.Visible=false;
            }
            if (Validation.user == "doctorPassword")
            {
                buttonDonate.Visible = false;
                buttonSick.Visible = true;
                buttonDonation.Visible = false;
                buttonAllogeneic.Visible = false;
            }
        }
      
        //התחול הסיסמאאות של הכניסה
        string directorPassword = "111"; //הסיסמה של המנהל
        string remindsPassword = "222"; //הסיסמה של המזכיר
        string doctorPassword = "333"; //הסיסמה של הדוקטור

        //מעבר מהטופס הראשי לטופס של ההתאמות
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 uco = new Form4();
            uco.Show();
        }

        //מעבר מהטופס הראשי לטופס של החולים
        private void buttonSick_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 uco = new Form2();
            uco.Show();
        }

        //מעבר מטופס ראשי לטופס של התורמים
        private void buttonDonate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 uco = new Form3();
            uco.Show();
        }

        //מעבר מהטופס הראשי לטופס של התרומות שבוצעו
        private void buttonDonation_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 uco = new Form5();
            uco.Show();
        }

        //כאשר ילחצו על הכפתור של - כניסה זה יביא את הפנל עם הסיסמה
        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            button1.SendToBack();
        }
         
        //פעולה ששמה בטקסט בוקסים את הסיסמאות בהתאמה
        private void Form1_Load(object sender, EventArgs e)
        {
            // התחול הסיסמאות
            textBox2.Text = directorPassword;
            textBox3.Text = remindsPassword;
            textBox4.Text = doctorPassword;
        }

        //כאשר ילחצו סיסמה תקינה זה יהפוך את הכפתורים הרלוונטים לאותו משתמש לניראים
        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == directorPassword)  //מנהל
            {
                //הפיכה של הכפתורים לנראים
                label3.Visible = true;//הפנל של ניהול סיסמאות
                buttonAllogeneic.Visible = true;
                buttonDonate.Visible = true;
                buttonDonation.Visible = true;
                buttonSick.Visible = true;
                // העלמת הפנל של הסיסמה וכיתוב של כניסה
                button1.BringToFront();
               button1.Text = "החלף משתמש";
                MessageBox.Show("נכנסתה למשתמש מנהל", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Validation.user = "manager";
            }

            if (textBox1.Text == remindsPassword)  //מזכיר
            {
                //הפיכה של הכפתורים לנראים
                label3.Visible = false;//הפנל של ניהול סיסמאות
                buttonAllogeneic.Visible = false;
                buttonDonate.Visible = true;
                buttonDonation.Visible = true;
                buttonSick.Visible = true;
                // העלמת הפנל של הסיסמה וכיתוב של כניסה
                button1.BringToFront();
                button1.Text = "החלף משתמש";
                MessageBox.Show("נכנסתה למשתמש מזכיר", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Validation.user = "remindsPassword";
            }

            if (textBox1.Text == doctorPassword)  //רופא
            {
                //הפיכה של הכפתורים לנראים
                label3.Visible = false;//הפנל של ניהול סיסמאות
                buttonAllogeneic.Visible = false;
                buttonDonate.Visible = false;
                buttonDonation.Visible = false;
                buttonSick.Visible = true;
                // העלמת הפנל של הסיסמה וכיתוב של כניסה
                button1.BringToFront();
                button1.Text = "החלף משתמש";
                MessageBox.Show("נכנסתה למשתמש רופא", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Validation.user = "doctorPassword";
            }

            //אם הסיסמה שגויה אז יציג הודעה
            if (textBox1.Text != directorPassword && textBox1.Text != remindsPassword && textBox1.Text != doctorPassword && textBox1.Text != null)
            {
                MessageBox.Show("הסיסמה שגויה. נסה שנית", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }

        //כאשר המנהל ילחץ על ניהול סיסמאות זה יפתח לו את הפנל ויתן לו לעדכן את הסיסמאות
        private void label3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            textBox2.Text = directorPassword;
            textBox3.Text = remindsPassword;
            textBox4.Text = doctorPassword;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            directorPassword = textBox2.Text;
            remindsPassword = textBox3.Text;
            doctorPassword = textBox4.Text;
            MessageBox.Show("The saving was done successfully");
            panel2.Visible = false;
        }
    }
}