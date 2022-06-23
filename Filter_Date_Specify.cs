using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventReader
{
    public partial class Filter_Date_Specify : Form
    {

       DataGridView log_grid;
       ToolStripStatusLabel down_panel_loaded_rows_label;
       ToolStripStatusLabel down_panel_visible_rows_label;



        public Filter_Date_Specify(DataGridView log_grid, ToolStripStatusLabel down_panel_loaded_rows_label, ToolStripStatusLabel down_panel_visible_rows_label)
        {

            InitializeComponent();
            this.log_grid = log_grid;
            this.down_panel_loaded_rows_label = down_panel_loaded_rows_label;
            this.down_panel_visible_rows_label = down_panel_visible_rows_label;


            date_start.Value = DateTime.Today;
            date_end.Value = DateTime.Today.AddDays(-7);


        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void Show_all_Button_Click(object sender, EventArgs e)
        {

            startup.dm.show_all_rows(log_grid);
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {

            if ( date_end.Value > date_start.Value)
            {

                Console.Beep();
                return;

            }

            startup.dm.hide_rows_by_date(log_grid, date_end.Value, date_start.Value.AddDays(+1));
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);




        }



    }
}
