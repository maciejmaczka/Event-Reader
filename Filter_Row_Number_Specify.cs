using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EventReader
{
    public partial class Filter_Row_Num_Specify : Form
    {

        DataGridView log_grid;
        ToolStripStatusLabel down_panel_loaded_rows_label;
        ToolStripStatusLabel down_panel_visible_rows_label;

        public Filter_Row_Num_Specify()
        {

            InitializeComponent();

        }

        public void only_number_guard(object sender)
        {

            TextBox txtbox = (TextBox)sender;

            txtbox.Text = Regex.Replace(txtbox.Text, "[^.0-9]", "");

            txtbox.SelectionStart = txtbox.Text.Length;


        }

        public Filter_Row_Num_Specify(DataGridView log_grid, ToolStripStatusLabel down_panel_loaded_rows_label, ToolStripStatusLabel down_panel_visible_rows_label)
        {

            InitializeComponent();
            this.log_grid = log_grid;
            this.down_panel_loaded_rows_label = down_panel_loaded_rows_label;
            this.down_panel_visible_rows_label = down_panel_visible_rows_label;
        }

        private void count_from_TextChanged(object sender, EventArgs e)
        {

            only_number_guard(sender);
           

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
           // startup.dm.hide_rows_by_count(log_grid, 10,  20);
            
            if (Int32.Parse(count_from.Text) -1  > Int32.Parse(count_to.Text))
            {

                Console.Beep();
                return;

            }
            
            startup.dm.hide_rows_by_count(log_grid, Int32.Parse(count_from.Text)  , Int32.Parse(count_to.Text));
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
           // this.Close();
        }

        private void count_to_TextChanged(object sender, EventArgs e)
        {
            only_number_guard(sender);
        }

        private void Show_all_Button_Click(object sender, EventArgs e)
        {

            startup.dm.show_all_rows(log_grid);
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
        }


    }
}
