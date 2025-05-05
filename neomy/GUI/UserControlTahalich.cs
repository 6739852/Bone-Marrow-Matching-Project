using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace neomy.GUI
{
    public partial class UserControlTahalich : UserControl
    {
        public UserControlTahalich()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
       
        }
    

        //כפתור שמעדכן את הנתונים בדאטא גירביו לפי האקסל שבוחרים// לא עובד צריל לסדר
        private void label1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";
            openFileDialog1.Title = "Select an Excel File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                UpdatedataGridView1FromExcel(filePath);
            }
        }
       
        private void UpdatedataGridView1FromExcel(string filePath)
        {
            // Create an Excel application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // Open the Excel file
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Open(filePath);

            // Get the first worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = workbook.Sheets[1];

            // Get the range of cells with data
            Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;

            // Loop through each row of data
            for (int i = 2; i <= range.Rows.Count; i++)
            {
                // Get the values from the Excel sheet
                string tz = (string)(range.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2;
                string numbber_phone = (string)(range.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2;
                string first_name = (string)(range.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2;
                string Last_name = (string)(range.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2;
                bool status = (bool)(range.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2;

                // Update the Gribio data
                UpdatedataGridView1(tz, numbber_phone, first_name, Last_name, status);
            }

            // Close the Excel file
            workbook.Close(false);

            // Exit the app
            app.Quit();
        }
   
        private void UpdatedataGridView1(string tz, string numbber_phone, string first_name, string Last_name, bool status)
        {
            // הקוד לעדכון נתוני Gribio מגיע לכאן
        }

    }
}
