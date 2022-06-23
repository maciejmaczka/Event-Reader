namespace EventReader
{
    partial class Filter_Date_Specify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filter_Date_Specify));
            this.label1 = new System.Windows.Forms.Label();
            this.Show_all_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date_start = new System.Windows.Forms.DateTimePicker();
            this.date_end = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show rows:";
            // 
            // Show_all_Button
            // 
            this.Show_all_Button.Location = new System.Drawing.Point(225, 47);
            this.Show_all_Button.Name = "Show_all_Button";
            this.Show_all_Button.Size = new System.Drawing.Size(75, 23);
            this.Show_all_Button.TabIndex = 14;
            this.Show_all_Button.Text = "Show all";
            this.Show_all_Button.UseVisualStyleBackColor = true;
            this.Show_all_Button.Click += new System.EventHandler(this.Show_all_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(225, 76);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 13;
            this.Cancel_Button.Text = "Close";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(225, 18);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 12;
            this.OK_Button.Text = "Apply";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "To:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "From:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // date_start
            // 
            this.date_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_start.Location = new System.Drawing.Point(81, 31);
            this.date_start.Name = "date_start";
            this.date_start.Size = new System.Drawing.Size(121, 20);
            this.date_start.TabIndex = 15;
            // 
            // date_end
            // 
            this.date_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_end.Location = new System.Drawing.Point(81, 64);
            this.date_end.Name = "date_end";
            this.date_end.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.date_end.RightToLeftLayout = true;
            this.date_end.Size = new System.Drawing.Size(121, 20);
            this.date_end.TabIndex = 16;
            // 
            // Filter_Date_Specify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(311, 110);
            this.Controls.Add(this.date_end);
            this.Controls.Add(this.date_start);
            this.Controls.Add(this.Show_all_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Filter_Date_Specify";
            this.Text = "Show days";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Show_all_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_start;
        private System.Windows.Forms.DateTimePicker date_end;
    }
}