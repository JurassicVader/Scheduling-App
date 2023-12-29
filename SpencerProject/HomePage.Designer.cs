﻿namespace SpencerProject
{
    partial class HomePage
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
            this.welcome_txt = new System.Windows.Forms.Label();
            this.customers_txt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customers_gridView = new System.Windows.Forms.DataGridView();
            this.appointments_gridView = new System.Windows.Forms.DataGridView();
            this.updateUser_btn = new System.Windows.Forms.Button();
            this.deleteUser_btn = new System.Windows.Forms.Button();
            this.cancelAppt_btn = new System.Windows.Forms.Button();
            this.updateAppt_btn = new System.Windows.Forms.Button();
            this.createCustomer_btn = new System.Windows.Forms.Button();
            this.scheduleAppt_btn = new System.Windows.Forms.Button();
            this.viewAppt_btn = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customers_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointments_gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // welcome_txt
            // 
            this.welcome_txt.AutoSize = true;
            this.welcome_txt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_txt.Location = new System.Drawing.Point(12, 20);
            this.welcome_txt.Name = "welcome_txt";
            this.welcome_txt.Size = new System.Drawing.Size(179, 22);
            this.welcome_txt.TabIndex = 0;
            this.welcome_txt.Text = "Welcome, *BLANK*";
            // 
            // customers_txt
            // 
            this.customers_txt.AutoSize = true;
            this.customers_txt.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_txt.Location = new System.Drawing.Point(126, 79);
            this.customers_txt.Name = "customers_txt";
            this.customers_txt.Size = new System.Drawing.Size(128, 27);
            this.customers_txt.TabIndex = 1;
            this.customers_txt.Text = "Customers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(573, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Appointments";
            // 
            // customers_gridView
            // 
            this.customers_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customers_gridView.Location = new System.Drawing.Point(12, 121);
            this.customers_gridView.Name = "customers_gridView";
            this.customers_gridView.Size = new System.Drawing.Size(371, 150);
            this.customers_gridView.TabIndex = 3;
            // 
            // appointments_gridView
            // 
            this.appointments_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointments_gridView.Location = new System.Drawing.Point(462, 121);
            this.appointments_gridView.Name = "appointments_gridView";
            this.appointments_gridView.Size = new System.Drawing.Size(371, 150);
            this.appointments_gridView.TabIndex = 4;
            // 
            // updateUser_btn
            // 
            this.updateUser_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateUser_btn.Location = new System.Drawing.Point(188, 289);
            this.updateUser_btn.Name = "updateUser_btn";
            this.updateUser_btn.Size = new System.Drawing.Size(81, 35);
            this.updateUser_btn.TabIndex = 5;
            this.updateUser_btn.Text = "Update";
            this.updateUser_btn.UseVisualStyleBackColor = true;
            // 
            // deleteUser_btn
            // 
            this.deleteUser_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteUser_btn.Location = new System.Drawing.Point(293, 289);
            this.deleteUser_btn.Name = "deleteUser_btn";
            this.deleteUser_btn.Size = new System.Drawing.Size(81, 35);
            this.deleteUser_btn.TabIndex = 6;
            this.deleteUser_btn.Text = "Delete";
            this.deleteUser_btn.UseVisualStyleBackColor = true;
            // 
            // cancelAppt_btn
            // 
            this.cancelAppt_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelAppt_btn.Location = new System.Drawing.Point(743, 289);
            this.cancelAppt_btn.Name = "cancelAppt_btn";
            this.cancelAppt_btn.Size = new System.Drawing.Size(81, 35);
            this.cancelAppt_btn.TabIndex = 8;
            this.cancelAppt_btn.Text = "Cancel";
            this.cancelAppt_btn.UseVisualStyleBackColor = true;
            // 
            // updateAppt_btn
            // 
            this.updateAppt_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateAppt_btn.Location = new System.Drawing.Point(634, 289);
            this.updateAppt_btn.Name = "updateAppt_btn";
            this.updateAppt_btn.Size = new System.Drawing.Size(81, 35);
            this.updateAppt_btn.TabIndex = 7;
            this.updateAppt_btn.Text = "Update";
            this.updateAppt_btn.UseVisualStyleBackColor = true;
            // 
            // createCustomer_btn
            // 
            this.createCustomer_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createCustomer_btn.Location = new System.Drawing.Point(188, 340);
            this.createCustomer_btn.Name = "createCustomer_btn";
            this.createCustomer_btn.Size = new System.Drawing.Size(186, 35);
            this.createCustomer_btn.TabIndex = 9;
            this.createCustomer_btn.Text = "Create Customer";
            this.createCustomer_btn.UseVisualStyleBackColor = true;
            // 
            // scheduleAppt_btn
            // 
            this.scheduleAppt_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleAppt_btn.Location = new System.Drawing.Point(614, 340);
            this.scheduleAppt_btn.Name = "scheduleAppt_btn";
            this.scheduleAppt_btn.Size = new System.Drawing.Size(210, 35);
            this.scheduleAppt_btn.TabIndex = 10;
            this.scheduleAppt_btn.Text = "Schedule Appointment";
            this.scheduleAppt_btn.UseVisualStyleBackColor = true;
            // 
            // viewAppt_btn
            // 
            this.viewAppt_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAppt_btn.Location = new System.Drawing.Point(432, 289);
            this.viewAppt_btn.Name = "viewAppt_btn";
            this.viewAppt_btn.Size = new System.Drawing.Size(186, 35);
            this.viewAppt_btn.TabIndex = 11;
            this.viewAppt_btn.Text = "View Appointments";
            this.viewAppt_btn.UseVisualStyleBackColor = true;
            // 
            // exit_btn
            // 
            this.exit_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.Location = new System.Drawing.Point(755, 440);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(81, 35);
            this.exit_btn.TabIndex = 12;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 487);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.viewAppt_btn);
            this.Controls.Add(this.scheduleAppt_btn);
            this.Controls.Add(this.createCustomer_btn);
            this.Controls.Add(this.cancelAppt_btn);
            this.Controls.Add(this.updateAppt_btn);
            this.Controls.Add(this.deleteUser_btn);
            this.Controls.Add(this.updateUser_btn);
            this.Controls.Add(this.appointments_gridView);
            this.Controls.Add(this.customers_gridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customers_txt);
            this.Controls.Add(this.welcome_txt);
            this.Name = "HomePage";
            this.Text = "HomePage";
            ((System.ComponentModel.ISupportInitialize)(this.customers_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointments_gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_txt;
        private System.Windows.Forms.Label customers_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView customers_gridView;
        private System.Windows.Forms.DataGridView appointments_gridView;
        private System.Windows.Forms.Button updateUser_btn;
        private System.Windows.Forms.Button deleteUser_btn;
        private System.Windows.Forms.Button cancelAppt_btn;
        private System.Windows.Forms.Button updateAppt_btn;
        private System.Windows.Forms.Button createCustomer_btn;
        private System.Windows.Forms.Button scheduleAppt_btn;
        private System.Windows.Forms.Button viewAppt_btn;
        private System.Windows.Forms.Button exit_btn;
    }
}