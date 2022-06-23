namespace EventReader
{
    partial class Event_Analyze
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Event_Analyze));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.main_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.analyze_table = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.main_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analyze_table)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Type",
            "Source",
            "Category",
            "User",
            "Computer",
            "EventID"});
            this.comboBox1.Location = new System.Drawing.Point(13, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Type";
            // 
            // main_chart
            // 
            this.main_chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.main_chart.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.main_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.main_chart.Legends.Add(legend1);
            this.main_chart.Location = new System.Drawing.Point(13, 40);
            this.main_chart.Name = "main_chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.CustomProperties = "PieLineColor=Black, PieLabelStyle=Outside";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.SmartLabelStyle.Enabled = false;
            this.main_chart.Series.Add(series1);
            this.main_chart.Size = new System.Drawing.Size(642, 490);
            this.main_chart.TabIndex = 2;
            this.main_chart.Text = "chart1";
            title1.Name = "Title1";
            this.main_chart.Titles.Add(title1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // analyze_table
            // 
            this.analyze_table.AllowUserToAddRows = false;
            this.analyze_table.AllowUserToDeleteRows = false;
            this.analyze_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.analyze_table.BackgroundColor = System.Drawing.SystemColors.Control;
            this.analyze_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.analyze_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A,
            this.B});
            this.analyze_table.GridColor = System.Drawing.SystemColors.Control;
            this.analyze_table.Location = new System.Drawing.Point(650, 40);
            this.analyze_table.Name = "analyze_table";
            this.analyze_table.ReadOnly = true;
            this.analyze_table.RowHeadersVisible = false;
            this.analyze_table.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.analyze_table.Size = new System.Drawing.Size(251, 490);
            this.analyze_table.TabIndex = 4;
            // 
            // A
            // 
            this.A.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.A.FillWeight = 98.47716F;
            this.A.HeaderText = "Label";
            this.A.Name = "A";
            this.A.ReadOnly = true;
            this.A.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // B
            // 
            this.B.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.B.FillWeight = 101.5228F;
            this.B.HeaderText = "Value";
            this.B.Name = "B";
            this.B.ReadOnly = true;
            this.B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Event_Analyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 542);
            this.Controls.Add(this.analyze_table);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.main_chart);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Event_Analyze";
            this.Text = "Analyze";
            ((System.ComponentModel.ISupportInitialize)(this.main_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analyze_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart main_chart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView analyze_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
    }
}