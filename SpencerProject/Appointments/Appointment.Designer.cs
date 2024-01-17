namespace SpencerProject.Appointments
{
    partial class Appointment
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
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.title_lbl = new System.Windows.Forms.Label();
            this.time_lbl = new System.Windows.Forms.Label();
            this.userId_lbl = new System.Windows.Forms.Label();
            this.customer_lbl = new System.Windows.Forms.Label();
            this.type_lbl = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.day_lbl = new System.Windows.Forms.Label();
            this.type_txtbox = new System.Windows.Forms.TextBox();
            this.uId_txtbox = new System.Windows.Forms.TextBox();
            this.cId_combo = new System.Windows.Forms.ComboBox();
            this.desc_lbl = new System.Windows.Forms.Label();
            this.desc_txtbox = new System.Windows.Forms.TextBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.create_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timePicker
            // 
            this.timePicker.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(125, 197);
            this.timePicker.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(200, 20);
            this.timePicker.TabIndex = 1;
            this.timePicker.Value = new System.DateTime(2024, 1, 17, 1, 0, 0, 0);
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_lbl.Location = new System.Drawing.Point(12, 9);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(194, 22);
            this.title_lbl.TabIndex = 2;
            this.title_lbl.Text = "Appointment Create";
            // 
            // time_lbl
            // 
            this.time_lbl.AutoSize = true;
            this.time_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_lbl.Location = new System.Drawing.Point(63, 197);
            this.time_lbl.Name = "time_lbl";
            this.time_lbl.Size = new System.Drawing.Size(46, 18);
            this.time_lbl.TabIndex = 10;
            this.time_lbl.Text = "Time:";
            // 
            // userId_lbl
            // 
            this.userId_lbl.AutoSize = true;
            this.userId_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userId_lbl.Location = new System.Drawing.Point(45, 74);
            this.userId_lbl.Name = "userId_lbl";
            this.userId_lbl.Size = new System.Drawing.Size(64, 18);
            this.userId_lbl.TabIndex = 9;
            this.userId_lbl.Text = "User ID:";
            // 
            // customer_lbl
            // 
            this.customer_lbl.AutoSize = true;
            this.customer_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_lbl.Location = new System.Drawing.Point(10, 157);
            this.customer_lbl.Name = "customer_lbl";
            this.customer_lbl.Size = new System.Drawing.Size(99, 18);
            this.customer_lbl.TabIndex = 8;
            this.customer_lbl.Text = "Customer ID:";
            // 
            // type_lbl
            // 
            this.type_lbl.AutoSize = true;
            this.type_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.type_lbl.Location = new System.Drawing.Point(64, 117);
            this.type_lbl.Name = "type_lbl";
            this.type_lbl.Size = new System.Drawing.Size(45, 18);
            this.type_lbl.TabIndex = 6;
            this.type_lbl.Text = "Type:";
            // 
            // datePicker
            // 
            this.datePicker.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(125, 231);
            this.datePicker.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 11;
            // 
            // day_lbl
            // 
            this.day_lbl.AutoSize = true;
            this.day_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day_lbl.Location = new System.Drawing.Point(63, 233);
            this.day_lbl.Name = "day_lbl";
            this.day_lbl.Size = new System.Drawing.Size(46, 18);
            this.day_lbl.TabIndex = 12;
            this.day_lbl.Text = "Date:";
            // 
            // type_txtbox
            // 
            this.type_txtbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.type_txtbox.Location = new System.Drawing.Point(125, 114);
            this.type_txtbox.Name = "type_txtbox";
            this.type_txtbox.Size = new System.Drawing.Size(238, 26);
            this.type_txtbox.TabIndex = 13;
            // 
            // uId_txtbox
            // 
            this.uId_txtbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uId_txtbox.Location = new System.Drawing.Point(125, 71);
            this.uId_txtbox.Name = "uId_txtbox";
            this.uId_txtbox.Size = new System.Drawing.Size(42, 26);
            this.uId_txtbox.TabIndex = 16;
            // 
            // cId_combo
            // 
            this.cId_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cId_combo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cId_combo.FormattingEnabled = true;
            this.cId_combo.Location = new System.Drawing.Point(125, 154);
            this.cId_combo.Name = "cId_combo";
            this.cId_combo.Size = new System.Drawing.Size(238, 26);
            this.cId_combo.TabIndex = 17;
            // 
            // desc_lbl
            // 
            this.desc_lbl.AutoSize = true;
            this.desc_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_lbl.Location = new System.Drawing.Point(17, 271);
            this.desc_lbl.Name = "desc_lbl";
            this.desc_lbl.Size = new System.Drawing.Size(92, 18);
            this.desc_lbl.TabIndex = 18;
            this.desc_lbl.Text = "Description:";
            // 
            // desc_txtbox
            // 
            this.desc_txtbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_txtbox.Location = new System.Drawing.Point(20, 301);
            this.desc_txtbox.Multiline = true;
            this.desc_txtbox.Name = "desc_txtbox";
            this.desc_txtbox.Size = new System.Drawing.Size(434, 103);
            this.desc_txtbox.TabIndex = 19;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(373, 414);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(81, 35);
            this.cancel_btn.TabIndex = 21;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // create_btn
            // 
            this.create_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_btn.Location = new System.Drawing.Point(247, 414);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(102, 35);
            this.create_btn.TabIndex = 20;
            this.create_btn.Text = "Schedule";
            this.create_btn.UseVisualStyleBackColor = true;
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 461);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.desc_txtbox);
            this.Controls.Add(this.desc_lbl);
            this.Controls.Add(this.cId_combo);
            this.Controls.Add(this.uId_txtbox);
            this.Controls.Add(this.type_txtbox);
            this.Controls.Add(this.day_lbl);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.time_lbl);
            this.Controls.Add(this.userId_lbl);
            this.Controls.Add(this.customer_lbl);
            this.Controls.Add(this.type_lbl);
            this.Controls.Add(this.title_lbl);
            this.Controls.Add(this.timePicker);
            this.Name = "Appointment";
            this.Text = "Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Label time_lbl;
        private System.Windows.Forms.Label userId_lbl;
        private System.Windows.Forms.Label customer_lbl;
        private System.Windows.Forms.Label type_lbl;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label day_lbl;
        private System.Windows.Forms.TextBox type_txtbox;
        private System.Windows.Forms.TextBox uId_txtbox;
        private System.Windows.Forms.ComboBox cId_combo;
        private System.Windows.Forms.Label desc_lbl;
        private System.Windows.Forms.TextBox desc_txtbox;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button create_btn;
    }
}