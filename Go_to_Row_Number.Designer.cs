namespace EventReader
{
    partial class Go_to_Row_Number
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Go_to_Row_Number));
            this.label1 = new System.Windows.Forms.Label();
            this.row_number_textbox = new System.Windows.Forms.TextBox();
            this.go_to_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Go to row:";
            // 
            // row_number_textbox
            // 
            this.row_number_textbox.Location = new System.Drawing.Point(74, 33);
            this.row_number_textbox.Name = "row_number_textbox";
            this.row_number_textbox.Size = new System.Drawing.Size(110, 20);
            this.row_number_textbox.TabIndex = 1;
            this.row_number_textbox.Text = "1";
            this.row_number_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.row_number_textbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // go_to_button
            // 
            this.go_to_button.Location = new System.Drawing.Point(223, 30);
            this.go_to_button.Name = "go_to_button";
            this.go_to_button.Size = new System.Drawing.Size(75, 23);
            this.go_to_button.TabIndex = 2;
            this.go_to_button.Text = "Go";
            this.go_to_button.UseVisualStyleBackColor = true;
            this.go_to_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(223, 59);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 3;
            this.close_button.Text = "Close";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // Go_to_Row_Number
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(310, 88);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.go_to_button);
            this.Controls.Add(this.row_number_textbox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Go_to_Row_Number";
            this.Text = "Go to row";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox row_number_textbox;
        private System.Windows.Forms.Button go_to_button;
        private System.Windows.Forms.Button close_button;
    }
}