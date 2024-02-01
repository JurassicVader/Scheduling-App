namespace SpencerProject
{
    partial class Report
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
            this.title_txt = new System.Windows.Forms.Label();
            this.desc_txt = new System.Windows.Forms.Label();
            this.data_title_txt = new System.Windows.Forms.Label();
            this.data_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title_txt
            // 
            this.title_txt.AutoSize = true;
            this.title_txt.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_txt.Location = new System.Drawing.Point(12, 9);
            this.title_txt.Name = "title_txt";
            this.title_txt.Size = new System.Drawing.Size(97, 29);
            this.title_txt.TabIndex = 1;
            this.title_txt.Text = "Report:";
            // 
            // desc_txt
            // 
            this.desc_txt.AutoSize = true;
            this.desc_txt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_txt.ForeColor = System.Drawing.Color.Black;
            this.desc_txt.Location = new System.Drawing.Point(14, 47);
            this.desc_txt.Name = "desc_txt";
            this.desc_txt.Size = new System.Drawing.Size(140, 18);
            this.desc_txt.TabIndex = 9;
            this.desc_txt.Text = "Report information:";
            // 
            // data_title_txt
            // 
            this.data_title_txt.AutoSize = true;
            this.data_title_txt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_title_txt.ForeColor = System.Drawing.Color.Black;
            this.data_title_txt.Location = new System.Drawing.Point(14, 106);
            this.data_title_txt.Name = "data_title_txt";
            this.data_title_txt.Size = new System.Drawing.Size(46, 18);
            this.data_title_txt.TabIndex = 10;
            this.data_title_txt.Text = "Data:";
            // 
            // data_txt
            // 
            this.data_txt.AutoSize = true;
            this.data_txt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_txt.ForeColor = System.Drawing.Color.Black;
            this.data_txt.Location = new System.Drawing.Point(32, 144);
            this.data_txt.Name = "data_txt";
            this.data_txt.Size = new System.Drawing.Size(54, 18);
            this.data_txt.TabIndex = 11;
            this.data_txt.Text = "*Data*";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.data_txt);
            this.Controls.Add(this.data_title_txt);
            this.Controls.Add(this.desc_txt);
            this.Controls.Add(this.title_txt);
            this.Name = "Report";
            this.Text = "Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_txt;
        private System.Windows.Forms.Label desc_txt;
        private System.Windows.Forms.Label data_title_txt;
        private System.Windows.Forms.Label data_txt;
    }
}