using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;
using System.Data.OleDb;

namespace EventReader
{
    public partial class Main : Form
    {
        public Main()
        {

            InitializeComponent();

            startup_components();

        }

        public void startup_components()
        {

            startup.er.toolbox_combo_fill_logs(toolbox_choose_log);     // load event log types
                          
            startup.fh.hide_columns_main(log_grid);     // hide invisible columns - settings based


            clear_items();                          // clear menu items
            clear_grids();                          // clear grids from data

            
        }

        public void clear_items()
        {

            startup.fh.hide_item_image(up_panel_show_columns_date, startup.set.show_column_date);
            startup.fh.hide_item_image(up_panel_show_columns_type, startup.set.show_column_type);
            startup.fh.hide_item_image(up_panel_show_columns_source, startup.set.show_column_source);
            startup.fh.hide_item_image(up_panel_show_columns_category, startup.set.show_column_category);
            startup.fh.hide_item_image(up_panel_show_columns_user, startup.set.show_column_user);
            startup.fh.hide_item_image(up_panel_show_columns_computer, startup.set.show_column_computer);
            startup.fh.hide_item_image(up_panel_show_columns_eventid, startup.set.show_column_eventid);
            startup.fh.hide_item_image(up_panel_show_columns_description, startup.set.show_column_description);


        }

        public void clear_grids()
        {

            startup.fh.clear_datagrid(log_grid);
            startup.fh.clear_datagrid(proc_grid);

            startup.fh.grid_settings(log_grid);
            startup.fh.grid_settings(proc_grid);
            

        }





 


        public void exit()
        {

            this.Close();

        }


        public void log_grid_selection_change()
        {
            try
            {



                log_date_value.Text = log_grid.SelectedRows[0].Cells["Date"].Value.ToString();

                log_type_value.Text = log_grid.SelectedRows[0].Cells["Type"].Value.ToString();

                log_source_value.Text = log_grid.SelectedRows[0].Cells["Source"].Value.ToString();

                log_category_value.Text = log_grid.SelectedRows[0].Cells["Category"].Value.ToString();

                log_user_value.Text = log_grid.SelectedRows[0].Cells["User"].Value.ToString();

                log_machine_value.Text = log_grid.SelectedRows[0].Cells["Computer"].Value.ToString();

                log_event_id_value.Text = log_grid.SelectedRows[0].Cells["EventID"].Value.ToString();

                log_description_value.Text = log_grid.SelectedRows[0].Cells["Description"].Value.ToString();
                // type  source category user computer event id message

            }
            catch
            {

            }



        }


       


        public void highligh_row_severity()
        {


            startup.set.hg_use_highlights = !startup.set.hg_use_highlights;

            startup.dm.highlights_severity_row(log_grid);


        }

        public void highliht_process_priority()
        {

            startup.set.hg_proc = !startup.set.hg_proc;
            startup.dm.highlights_process(proc_grid);


        }

        public void show_specify_date()
        {

            Filter_Date_Specify fds = new Filter_Date_Specify(log_grid, down_panel_loaded_rows_label , down_panel_visible_rows_label);
            fds.TopMost = true;
            fds.Show();

        }

        public void show_specify_count()
        {

            Filter_Row_Num_Specify fcs = new Filter_Row_Num_Specify(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
            fcs.TopMost = true;
            fcs.Show();

        }


        public void show_go_to_row_number()
        {

            Go_to_Row_Number gtrn = new Go_to_Row_Number(log_grid);
            gtrn.TopMost = true;
            gtrn.Show();

        }



        private void toolbox_change_view_Click(object sender, EventArgs e)
        {

            startup.fh.change_right_panel_view(split_container);

        }

        private void up_panel_exit_item_Click(object sender, EventArgs e)
        {


            exit();


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            startup.er.run_read_log_from_system_last_7(log_grid,down_panel_loaded_rows_label, down_panel_visible_rows_label);

        }

  

        public DataGridView get_datagrid_view()
        {

            return log_grid;
        }

        private void log_grid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

  


        }

        private void log_grid_SelectionChanged(object sender, EventArgs e)
        {
            log_grid_selection_change();
        }

        private void toolbox_choose_log_SelectedIndexChanged(object sender, EventArgs e)
        {

            startup.fh.change_log_selection(toolbox_choose_log);
           
        }

        private void up_panel_show_columns_date_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem tsmi = (ToolStripMenuItem) sender;
            startup.fh.hide_columns(log_grid, tsmi.Text);
            startup.fh.hide_item_image(tsmi);
            

        }

        private void up_panel_highlights_rows_Click(object sender, EventArgs e)
        {

            highligh_row_severity();


        }

        private void last100ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_rows_by_count(log_grid, 0, 100);
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);

        }

        private void last500ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_rows_by_count(log_grid, 0, 500);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
            startup.dm.recalculate_rows(log_grid);

        }

        private void last1000ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_rows_by_count(log_grid, 0, 1000);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
            startup.dm.recalculate_rows(log_grid);

        }

        private void clearFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.show_all_rows(log_grid);
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);

        }

        private void specifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            show_specify_count();
            startup.dm.recalculate_rows(log_grid);

        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.filter_reverse(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
            startup.dm.recalculate_rows(log_grid);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int find_zero = 0;

                for (int row = 0; row < log_grid.Rows.Count; row++)
                {

                    if (log_grid.Rows[row].Cells["No"].Value.ToString() == 1.ToString())
                    {

                        find_zero = row;

                    }


                }

                log_grid.FirstDisplayedScrollingRowIndex = find_zero;

            }
            catch (Exception exp)
            {
                
            }
        }

        private void to_down_Click(object sender, EventArgs e)
        {

            try
            {
                int rows_visible = 0;

                for (int row = 0; row < log_grid.Rows.Count; row++)
                {

                    if (log_grid.Rows[row].Visible == true)
                    {

                        rows_visible++;

                    }

                }


                int temp = rows_visible - log_grid.DisplayedRowCount(false) + 1;
                int temp_show = 0;

                for ( int row = 0 ; row < log_grid.Rows.Count; row++)
                {

                    if ( log_grid.Rows[row].Cells["No"].Value.ToString() == temp.ToString())
                    {

                        temp_show = row;

                    }


                }

                log_grid.FirstDisplayedScrollingRowIndex = temp_show;
                
            }
            catch (Exception exp)
            {


            }
        }

        private void log_grid_Sorted(object sender, EventArgs e)
        {

           
            startup.dm.recalculate_rows(log_grid);

        }

        private void log_grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void log_grid_DoubleClick(object sender, EventArgs e)
        {
          //  
        }

        private void changeRowNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startup.dm.recalculate_rows(log_grid);
        }

        private void rowToolStripMenuItem_Click(object sender, EventArgs e)
        {

            show_go_to_row_number();

        }

        private void todayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_rows_by_date(log_grid, DateTime.Today, DateTime.Today.AddDays(1));
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);

        }

        private void yesterdayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //DateTime dt_start = DateTime.Today;

            startup.dm.hide_rows_by_date(log_grid, DateTime.Today.AddDays(-1), DateTime.Today);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);

        }

        private void lastWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_rows_by_date(log_grid, DateTime.Today.AddDays(-7), DateTime.Today.AddDays(1));
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
        }

        private void specyfiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            show_specify_date();
            startup.dm.recalculate_rows(log_grid);


        }

        private void lastWeekToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            startup.er.run_read_log_from_system_last_7(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
        }

        private void todayToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            startup.er.run_read_log_from_system_last_1(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
        }

        private void lastMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startup.er.run_read_log_from_system_last_30(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startup.er.run_read_log_from_system_all(log_grid, down_panel_loaded_rows_label, down_panel_visible_rows_label);
        }



        public void click_chage_selection(object sender , MouseEventArgs e)
        {



        }

        private void log_grid_CellClick(object sender, MouseEventArgs e)
        {
           // click_chage_selection(sender , e);
        }

        private void errorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_rows_by_severity(log_grid, "Error", "Critical");
            startup.dm.recalculate_rows(log_grid);

        }

        private void warningToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_rows_by_severity(log_grid, "Warning", "N/A");
            startup.dm.recalculate_rows(log_grid);

        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_rows_by_severity(log_grid, "Information", "N/A");
            startup.dm.recalculate_rows(log_grid);

        }

        private void log_filter_by_severity_Click(object sender, EventArgs e)
        {

            filter_out("Type");

        }


        public void filter_out(string column_name)
        {

            startup.dm.hide_all(log_grid);

            for (int row = 0; row < log_grid.SelectedRows.Count; row++)
            {


                startup.dm.hide_rows_by_custom_column_multiple(log_grid, column_name, log_grid.SelectedRows[row].Cells[column_name].Value.ToString());

            }

            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label , down_panel_visible_rows_label);


        }

        private void log_filter_by_source_Click(object sender, EventArgs e)
        {
            filter_out("Source");
        }

        private void log_filter_by_category_Click(object sender, EventArgs e)
        {
            filter_out("Category");
        }

        private void log_filter_by_user_Click(object sender, EventArgs e)
        {
            filter_out("User");
        }

        private void log_filter_by_computer_Click(object sender, EventArgs e)
        {
            filter_out("Computer");
        }

        private void log_filter_by_eventid_Click(object sender, EventArgs e)
        {
            filter_out("EventID");
        }

        private void hideSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_selected(log_grid);
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label , down_panel_visible_rows_label);

        }

        private void showOnlySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startup.dm.hide_show_only_selected(log_grid);
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label , down_panel_visible_rows_label);

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            startup.dm.show_all_rows(log_grid);
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label , down_panel_visible_rows_label);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            highligh_row_severity();
            
        }


        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {


            if (log_grid.Rows.Count <= 1)
            {
                return;
            }

            startup.dm.find_in_row(log_grid, toolStrip_search_txtbox.Text, 0);
            
 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (log_grid.Rows.Count <= 1)
            {
                return;
            }

            startup.dm.find_in_row(log_grid, toolStrip_search_txtbox.Text, log_grid.SelectedRows[0].Index + 1);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (log_grid.Rows.Count <= 1)
            {
                return;
            }

            startup.dm.find_in_row_prev(log_grid, toolStrip_search_txtbox.Text, log_grid.SelectedRows[0].Index - 1);

        }

        private void toolStrip_search_txtbox_TextChanged(object sender, EventArgs e)
        {

            if (log_grid.Rows.Count <= 1)
            {
                return;
            }

            startup.dm.find_in_row(log_grid, toolStrip_search_txtbox.Text, 0);
           
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            startup.dm.find_in_row_and_filter(log_grid, toolStrip_search_txtbox.Text);
            startup.dm.recalculate_rows(log_grid);
            startup.dm.count_rows(log_grid, down_panel_loaded_rows_label , down_panel_visible_rows_label);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

            Event_Log_Summary els = new Event_Log_Summary(toolstrip_machine_name.Text);
            els.ShowDialog();

        }

        private void toolstrip_machine_name_TextChanged(object sender, EventArgs e)
        {

            startup.fh.change_machine_name(toolstrip_machine_name);

        }

        private void toFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";

            sfd.ShowDialog();

            if (sfd.FileName.Length == 0)
            {

                return;

            }

            startup.dm.write_to_csv(log_grid, sfd.FileName);


        }

        private void tomdbFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "mdb files (*.mdb)|*.mdb|All files (*.*)|*.*";

            sfd.ShowDialog();

            if (sfd.FileName.Length == 0)
            {

                return;

            }

           // startup.dm.write_to_access(log_grid, sfd.FileName);

        }

        private void analyzeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Event_Analyze ea = new Event_Analyze(log_grid);
            ea.ShowDialog();


        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Event_Analyze ea = new Event_Analyze(log_grid);
            ea.ShowDialog();

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {

            startup.pr.read_processes(proc_machine_name.Text, proc_grid);

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            highliht_process_priority();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            startup.pr.read_performance(".", proc_grid);
        }

        private void BG_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void BG_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }



    }
}
