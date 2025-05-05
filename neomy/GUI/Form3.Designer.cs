
namespace neomy
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonU = new System.Windows.Forms.Button();
            this.buttonS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDonate = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Guttman Kav", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(794, -2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 35);
            this.button2.TabIndex = 0;
            this.button2.Text = "דף הבית";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(366, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(552, 281);
            this.dataGridView1.TabIndex = 26;
            // 
            // buttonA
            // 
            this.buttonA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonA.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.buttonA.Font = new System.Drawing.Font("Guttman Kav", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonA.ForeColor = System.Drawing.Color.Transparent;
            this.buttonA.Location = new System.Drawing.Point(752, 425);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(120, 39);
            this.buttonA.TabIndex = 27;
            this.buttonA.Text = "הוספה";
            this.buttonA.UseVisualStyleBackColor = false;
            this.buttonA.UseWaitCursor = true;
            this.buttonA.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonU
            // 
            this.buttonU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonU.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.buttonU.Font = new System.Drawing.Font("Guttman Kav", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonU.ForeColor = System.Drawing.Color.Transparent;
            this.buttonU.Location = new System.Drawing.Point(626, 425);
            this.buttonU.Name = "buttonU";
            this.buttonU.Size = new System.Drawing.Size(120, 39);
            this.buttonU.TabIndex = 28;
            this.buttonU.Text = "עדכון";
            this.buttonU.UseVisualStyleBackColor = false;
            this.buttonU.UseWaitCursor = true;
            this.buttonU.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonS
            // 
            this.buttonS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonS.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.buttonS.Font = new System.Drawing.Font("Guttman Kav", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonS.ForeColor = System.Drawing.Color.Transparent;
            this.buttonS.Location = new System.Drawing.Point(500, 425);
            this.buttonS.Name = "buttonS";
            this.buttonS.Size = new System.Drawing.Size(120, 39);
            this.buttonS.TabIndex = 29;
            this.buttonS.Text = "חיפוש";
            this.buttonS.UseVisualStyleBackColor = false;
            this.buttonS.UseWaitCursor = true;
            this.buttonS.Click += new System.EventHandler(this.buttensearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Guttman Kav", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(637, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 34);
            this.label1.TabIndex = 30;
            this.label1.Text = "תורמים";
            // 
            // panelDonate
            // 
            this.panelDonate.Location = new System.Drawing.Point(12, 12);
            this.panelDonate.Name = "panelDonate";
            this.panelDonate.Size = new System.Drawing.Size(331, 501);
            this.panelDonate.TabIndex = 31;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 516);
            this.Controls.Add(this.panelDonate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonS);
            this.Controls.Add(this.buttonU);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form3";
            this.Text = "מאגר מח עצם- תורמים";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDonate;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button buttonA;
        public System.Windows.Forms.Button buttonU;
        public System.Windows.Forms.Button buttonS;
    }
}