namespace SpencerProject.Appointments
{
    partial class FormCalendar
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Select_btn = new System.Windows.Forms.Button();
            this.customers_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // Select_btn
            // 
            this.Select_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_btn.Location = new System.Drawing.Point(20, 226);
            this.Select_btn.Name = "Select_btn";
            this.Select_btn.Size = new System.Drawing.Size(225, 35);
            this.Select_btn.TabIndex = 16;
            this.Select_btn.Text = "Select";
            this.Select_btn.UseVisualStyleBackColor = true;
            this.Select_btn.Click += new System.EventHandler(this.Select_btn_Click);
            // 
            // customers_txt
            // 
            this.customers_txt.AutoSize = true;
            this.customers_txt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_txt.Location = new System.Drawing.Point(16, 189);
            this.customers_txt.Name = "customers_txt";
            this.customers_txt.Size = new System.Drawing.Size(229, 22);
            this.customers_txt.TabIndex = 17;
            this.customers_txt.Text = "Default Selection is Today";
            // 
            // FormCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 278);
            this.Controls.Add(this.customers_txt);
            this.Controls.Add(this.Select_btn);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "FormCalendar";
            this.Text = "FormCalendar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button Select_btn;
        private System.Windows.Forms.Label customers_txt;
    }
}