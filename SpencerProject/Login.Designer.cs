namespace SpencerProject
{
    partial class Login
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
            this.login_btn = new System.Windows.Forms.Button();
            this.username_txtbox = new System.Windows.Forms.TextBox();
            this.Password_txtBox = new System.Windows.Forms.TextBox();
            this.username_lbl = new System.Windows.Forms.Label();
            this.title_txt = new System.Windows.Forms.Label();
            this.password_lbl = new System.Windows.Forms.Label();
            this.exit_btn = new System.Windows.Forms.Button();
            this.incorrect_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // login_btn
            // 
            this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.Location = new System.Drawing.Point(201, 180);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(79, 32);
            this.login_btn.TabIndex = 0;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // username_txtbox
            // 
            this.username_txtbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_txtbox.Location = new System.Drawing.Point(123, 88);
            this.username_txtbox.Name = "username_txtbox";
            this.username_txtbox.Size = new System.Drawing.Size(253, 26);
            this.username_txtbox.TabIndex = 2;
            // 
            // Password_txtBox
            // 
            this.Password_txtBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_txtBox.Location = new System.Drawing.Point(123, 131);
            this.Password_txtBox.Name = "Password_txtBox";
            this.Password_txtBox.PasswordChar = '*';
            this.Password_txtBox.Size = new System.Drawing.Size(253, 26);
            this.Password_txtBox.TabIndex = 3;
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_lbl.Location = new System.Drawing.Point(12, 91);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(84, 18);
            this.username_lbl.TabIndex = 4;
            this.username_lbl.Text = "Username:";
            // 
            // title_txt
            // 
            this.title_txt.AutoSize = true;
            this.title_txt.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_txt.Location = new System.Drawing.Point(87, 9);
            this.title_txt.Name = "title_txt";
            this.title_txt.Size = new System.Drawing.Size(252, 36);
            this.title_txt.TabIndex = 5;
            this.title_txt.Text = "User Login Form";
            // 
            // password_lbl
            // 
            this.password_lbl.AutoSize = true;
            this.password_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_lbl.Location = new System.Drawing.Point(12, 131);
            this.password_lbl.Name = "password_lbl";
            this.password_lbl.Size = new System.Drawing.Size(82, 18);
            this.password_lbl.TabIndex = 6;
            this.password_lbl.Text = "Password:";
            // 
            // exit_btn
            // 
            this.exit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.Location = new System.Drawing.Point(297, 180);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(79, 32);
            this.exit_btn.TabIndex = 7;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // incorrect_txt
            // 
            this.incorrect_txt.AutoSize = true;
            this.incorrect_txt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrect_txt.ForeColor = System.Drawing.Color.Red;
            this.incorrect_txt.Location = new System.Drawing.Point(103, 54);
            this.incorrect_txt.Name = "incorrect_txt";
            this.incorrect_txt.Size = new System.Drawing.Size(219, 18);
            this.incorrect_txt.TabIndex = 8;
            this.incorrect_txt.Text = "Invalid Username or Password";
            this.incorrect_txt.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 260);
            this.Controls.Add(this.incorrect_txt);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.password_lbl);
            this.Controls.Add(this.title_txt);
            this.Controls.Add(this.username_lbl);
            this.Controls.Add(this.Password_txtBox);
            this.Controls.Add(this.username_txtbox);
            this.Controls.Add(this.login_btn);
            this.Name = "Login";
            this.Text = "User Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.TextBox username_txtbox;
        private System.Windows.Forms.TextBox Password_txtBox;
        private System.Windows.Forms.Label username_lbl;
        private System.Windows.Forms.Label title_txt;
        private System.Windows.Forms.Label password_lbl;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Label incorrect_txt;
    }
}

