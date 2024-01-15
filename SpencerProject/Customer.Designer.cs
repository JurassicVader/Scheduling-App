namespace SpencerProject
{
    partial class Customer
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
            this.components = new System.ComponentModel.Container();
            this.title_lbl = new System.Windows.Forms.Label();
            this.name_lbl = new System.Windows.Forms.Label();
            this.address_lbl = new System.Windows.Forms.Label();
            this.phone_lbl = new System.Windows.Forms.Label();
            this.city_lbl = new System.Windows.Forms.Label();
            this.country_lbl = new System.Windows.Forms.Label();
            this.name_txtbox = new System.Windows.Forms.TextBox();
            this.address_txtbox = new System.Windows.Forms.TextBox();
            this.phone_txtbox = new System.Windows.Forms.TextBox();
            this.create_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.country_combo = new System.Windows.Forms.ComboBox();
            this.city_combo = new System.Windows.Forms.ComboBox();
            this.page_tick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_lbl.Location = new System.Drawing.Point(16, 9);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(167, 22);
            this.title_lbl.TabIndex = 0;
            this.title_lbl.Text = "Customer Create";
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_lbl.Location = new System.Drawing.Point(28, 57);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(54, 18);
            this.name_lbl.TabIndex = 1;
            this.name_lbl.Text = "Name:";
            // 
            // address_lbl
            // 
            this.address_lbl.AutoSize = true;
            this.address_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_lbl.Location = new System.Drawing.Point(11, 135);
            this.address_lbl.Name = "address_lbl";
            this.address_lbl.Size = new System.Drawing.Size(71, 18);
            this.address_lbl.TabIndex = 2;
            this.address_lbl.Text = "Address:";
            // 
            // phone_lbl
            // 
            this.phone_lbl.AutoSize = true;
            this.phone_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_lbl.Location = new System.Drawing.Point(12, 96);
            this.phone_lbl.Name = "phone_lbl";
            this.phone_lbl.Size = new System.Drawing.Size(70, 18);
            this.phone_lbl.TabIndex = 3;
            this.phone_lbl.Text = "Phone #:";
            // 
            // city_lbl
            // 
            this.city_lbl.AutoSize = true;
            this.city_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city_lbl.Location = new System.Drawing.Point(43, 216);
            this.city_lbl.Name = "city_lbl";
            this.city_lbl.Size = new System.Drawing.Size(39, 18);
            this.city_lbl.TabIndex = 4;
            this.city_lbl.Text = "City:";
            // 
            // country_lbl
            // 
            this.country_lbl.AutoSize = true;
            this.country_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.country_lbl.Location = new System.Drawing.Point(17, 175);
            this.country_lbl.Name = "country_lbl";
            this.country_lbl.Size = new System.Drawing.Size(65, 18);
            this.country_lbl.TabIndex = 5;
            this.country_lbl.Text = "Country:";
            // 
            // name_txtbox
            // 
            this.name_txtbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_txtbox.Location = new System.Drawing.Point(110, 54);
            this.name_txtbox.Name = "name_txtbox";
            this.name_txtbox.Size = new System.Drawing.Size(238, 26);
            this.name_txtbox.TabIndex = 1;
            // 
            // address_txtbox
            // 
            this.address_txtbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_txtbox.Location = new System.Drawing.Point(110, 132);
            this.address_txtbox.Name = "address_txtbox";
            this.address_txtbox.Size = new System.Drawing.Size(238, 26);
            this.address_txtbox.TabIndex = 3;
            // 
            // phone_txtbox
            // 
            this.phone_txtbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_txtbox.Location = new System.Drawing.Point(110, 93);
            this.phone_txtbox.Name = "phone_txtbox";
            this.phone_txtbox.Size = new System.Drawing.Size(238, 26);
            this.phone_txtbox.TabIndex = 2;
            // 
            // create_btn
            // 
            this.create_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_btn.Location = new System.Drawing.Point(162, 257);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(81, 35);
            this.create_btn.TabIndex = 11;
            this.create_btn.Text = "Create";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(267, 257);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(81, 35);
            this.cancel_btn.TabIndex = 12;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // country_combo
            // 
            this.country_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.country_combo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.country_combo.FormattingEnabled = true;
            this.country_combo.Location = new System.Drawing.Point(110, 172);
            this.country_combo.Name = "country_combo";
            this.country_combo.Size = new System.Drawing.Size(238, 26);
            this.country_combo.TabIndex = 4;
            // 
            // city_combo
            // 
            this.city_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.city_combo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city_combo.FormattingEnabled = true;
            this.city_combo.Location = new System.Drawing.Point(110, 213);
            this.city_combo.Name = "city_combo";
            this.city_combo.Size = new System.Drawing.Size(238, 26);
            this.city_combo.TabIndex = 5;
            // 
            // page_tick
            // 
            this.page_tick.Enabled = true;
            this.page_tick.Interval = 250;
            this.page_tick.Tick += new System.EventHandler(this.page_tick_Tick);
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 315);
            this.Controls.Add(this.city_combo);
            this.Controls.Add(this.country_combo);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.phone_txtbox);
            this.Controls.Add(this.address_txtbox);
            this.Controls.Add(this.name_txtbox);
            this.Controls.Add(this.country_lbl);
            this.Controls.Add(this.city_lbl);
            this.Controls.Add(this.phone_lbl);
            this.Controls.Add(this.address_lbl);
            this.Controls.Add(this.name_lbl);
            this.Controls.Add(this.title_lbl);
            this.Name = "Customer";
            this.Text = "Customer Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.Label address_lbl;
        private System.Windows.Forms.Label phone_lbl;
        private System.Windows.Forms.Label city_lbl;
        private System.Windows.Forms.Label country_lbl;
        private System.Windows.Forms.TextBox name_txtbox;
        private System.Windows.Forms.TextBox address_txtbox;
        private System.Windows.Forms.TextBox phone_txtbox;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.ComboBox country_combo;
        private System.Windows.Forms.ComboBox city_combo;
        private System.Windows.Forms.Timer page_tick;
    }
}