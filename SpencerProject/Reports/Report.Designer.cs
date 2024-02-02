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
            this.exit_btn = new System.Windows.Forms.Button();
            this.schedule_gridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.schedule_gridView)).BeginInit();
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
            // exit_btn
            // 
            this.exit_btn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.Location = new System.Drawing.Point(707, 403);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(81, 35);
            this.exit_btn.TabIndex = 13;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // schedule_gridView
            // 
            this.schedule_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.schedule_gridView.Location = new System.Drawing.Point(17, 144);
            this.schedule_gridView.Name = "schedule_gridView";
            this.schedule_gridView.Size = new System.Drawing.Size(497, 275);
            this.schedule_gridView.TabIndex = 14;
            this.schedule_gridView.Visible = false;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.schedule_gridView);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.data_txt);
            this.Controls.Add(this.data_title_txt);
            this.Controls.Add(this.desc_txt);
            this.Controls.Add(this.title_txt);
            this.Name = "Report";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.schedule_gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_txt;
        private System.Windows.Forms.Label desc_txt;
        private System.Windows.Forms.Label data_title_txt;
        private System.Windows.Forms.Label data_txt;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.DataGridView schedule_gridView;
    }
}