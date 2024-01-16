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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.title_lbl = new System.Windows.Forms.Label();
            this.time_lbl = new System.Windows.Forms.Label();
            this.userId_lbl = new System.Windows.Forms.Label();
            this.customer_lbl = new System.Windows.Forms.Label();
            this.Schedule_lbl = new System.Windows.Forms.Label();
            this.type_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(124, 218);
            this.dateTimePicker.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 1;
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
            this.time_lbl.Location = new System.Drawing.Point(52, 184);
            this.time_lbl.Name = "time_lbl";
            this.time_lbl.Size = new System.Drawing.Size(46, 18);
            this.time_lbl.TabIndex = 10;
            this.time_lbl.Text = "Time:";
            // 
            // userId_lbl
            // 
            this.userId_lbl.AutoSize = true;
            this.userId_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userId_lbl.Location = new System.Drawing.Point(34, 220);
            this.userId_lbl.Name = "userId_lbl";
            this.userId_lbl.Size = new System.Drawing.Size(64, 18);
            this.userId_lbl.TabIndex = 9;
            this.userId_lbl.Text = "User ID:";
            // 
            // customer_lbl
            // 
            this.customer_lbl.AutoSize = true;
            this.customer_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_lbl.Location = new System.Drawing.Point(18, 110);
            this.customer_lbl.Name = "customer_lbl";
            this.customer_lbl.Size = new System.Drawing.Size(80, 18);
            this.customer_lbl.TabIndex = 8;
            this.customer_lbl.Text = "Customer:";
            // 
            // Schedule_lbl
            // 
            this.Schedule_lbl.AutoSize = true;
            this.Schedule_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Schedule_lbl.Location = new System.Drawing.Point(21, 148);
            this.Schedule_lbl.Name = "Schedule_lbl";
            this.Schedule_lbl.Size = new System.Drawing.Size(77, 18);
            this.Schedule_lbl.TabIndex = 7;
            this.Schedule_lbl.Text = "Schedule:";
            // 
            // type_lbl
            // 
            this.type_lbl.AutoSize = true;
            this.type_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.type_lbl.Location = new System.Drawing.Point(53, 70);
            this.type_lbl.Name = "type_lbl";
            this.type_lbl.Size = new System.Drawing.Size(45, 18);
            this.type_lbl.TabIndex = 6;
            this.type_lbl.Text = "Type:";
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 450);
            this.Controls.Add(this.time_lbl);
            this.Controls.Add(this.userId_lbl);
            this.Controls.Add(this.customer_lbl);
            this.Controls.Add(this.Schedule_lbl);
            this.Controls.Add(this.type_lbl);
            this.Controls.Add(this.title_lbl);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "Appointment";
            this.Text = "Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Label time_lbl;
        private System.Windows.Forms.Label userId_lbl;
        private System.Windows.Forms.Label customer_lbl;
        private System.Windows.Forms.Label Schedule_lbl;
        private System.Windows.Forms.Label type_lbl;
    }
}