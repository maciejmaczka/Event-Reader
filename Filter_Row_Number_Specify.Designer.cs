namespace EventReader
{
    partial class Filter_Row_Num_Specify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filter_Row_Num_Specify));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.count_from = new System.Windows.Forms.TextBox();
            this.count_to = new System.Windows.Forms.TextBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Show_all_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Show rows:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "From:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // count_from
            // 
            this.count_from.Location = new System.Drawing.Point(82, 36);
            this.count_from.Name = "count_from";
            this.count_from.Size = new System.Drawing.Size(100, 20);
            this.count_from.TabIndex = 3;
            this.count_from.Text = "1";
            this.count_from.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.count_from.TextChanged += new System.EventHandler(this.count_from_TextChanged);
            // 
            // count_to
            // 
            this.count_to.Location = new System.Drawing.Point(82, 63);
            this.count_to.Name = "count_to";
            this.count_to.Size = new System.Drawing.Size(100, 20);
            this.count_to.TabIndex = 4;
            this.count_to.Text = "100";
            this.count_to.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.count_to.TextChanged += new System.EventHandler(this.count_to_TextChanged);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(226, 19);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 5;
            this.OK_Button.Text = "Apply";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(226, 77);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "Close";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Show_all_Button
            // 
            this.Show_all_Button.Location = new System.Drawing.Point(226, 48);
            this.Show_all_Button.Name = "Show_all_Button";
            this.Show_all_Button.Size = new System.Drawing.Size(75, 23);
            this.Show_all_Button.TabIndex = 7;
            this.Show_all_Button.Text = "Show all";
            this.Show_all_Button.UseVisualStyleBackColor = true;
            this.Show_all_Button.Click += new System.EventHandler(this.Show_all_Button_Click);
            // 
            // Filter_Row_Num_Specify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(313, 112);
            this.Controls.Add(this.Show_all_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.count_to);
            this.Controls.Add(this.count_from);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filter_Row_Num_Specify";
            this.ShowInTaskbar = false;
            this.Text = "Show rows";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox count_from;
        private System.Windows.Forms.TextBox count_to;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Show_all_Button;
    }
}