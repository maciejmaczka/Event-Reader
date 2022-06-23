using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Security;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;
using System.Data.OleDb;


namespace EventReader
{
    class Data_Manipulator
    {


        public void write_to_csv(DataGridView log_grid, String csv_file)
        {

            try
            {

                StreamWriter writer = new StreamWriter(csv_file, false);

                for (int col = 0; col < log_grid.Columns.Count; col++)                      // headers
                {

                    writer.Write(log_grid.Columns[col].Name + ";");

                }


                writer.WriteLine();


                for (int row = 0; row < log_grid.Rows.Count; row++)                         // data , only visilbe rows
                {                                                                           // all columns

                    if (log_grid.Rows[row].Visible == false)
                    {

                        continue;

                    }


                    for (int col = 0; col < log_grid.Columns.Count; col++)
                    {



                        writer.Write(log_grid.Rows[row].Cells[col].Value.ToString() + ";");



                    }

                    writer.WriteLine();

                }

                writer.Close();

            }
            catch (Exception e)
            {

                startup.error.show_error_message(e, "0x02");

            }


        }

    
        public void find_in_row_and_filter(DataGridView log_grid, String search_text)
        {
          

            grid_suspend(log_grid);

             if (log_grid.Rows.Count <= 1)
            {

                return;

            }

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {

                for (int column = 0; column < log_grid.ColumnCount; column++)
                {

                    if (log_grid.Rows[row].Cells[column].Value.ToString().ToLower().Contains(search_text.ToLower()))
                    {

                        log_grid.Rows[row].Visible = true;                      
                        break;
                    }
                    else
                    {

                        log_grid.Rows[row].Visible = false;

                    }


                    

                }
            }

            
            grid_resume(log_grid);
        }

        public void find_in_row(DataGridView log_grid, string search_text, int start_from_row)
        {

            if (log_grid.Rows.Count <= 1)
            {

                return;

            }

            if (search_text.Length == 0)
            {

                return;

            }

            for (int row = start_from_row; row < log_grid.Rows.Count; row++)
            {

                for (int column = 0; column < log_grid.ColumnCount; column++)
                {

                    if (log_grid.Rows[row].Cells[column].Value.ToString().ToLower().Contains(search_text.ToLower()))
                    {
                        
                        if (log_grid.Rows[row].Visible == false)
                        {
                            // szukaj tylko w widocznych 
                            continue;
                        }


                        log_grid.ClearSelection();

                        log_grid.Rows[row].Selected = true;

                        log_grid.CurrentCell = log_grid.Rows[row].Cells[0];

                        return;

                    }


                    

                }
            }


        }

        public void find_in_row_prev(DataGridView log_grid, string search_text, int start_from_row)
        {

            if (log_grid.Rows.Count <= 1)
            {

                return;

            }

            if (search_text.Length == 0)
            {

                return;

            }

            for (int row = start_from_row; row >= 0; row--)
            {

                for (int column = 0; column < log_grid.ColumnCount; column++)
                {

                    if (log_grid.Rows[row].Cells[column].Value.ToString().ToLower().Contains(search_text.ToLower()))
                    {

                        if (log_grid.Rows[row].Visible == false)
                        {
                            // szukaj tylko w widocznych 
                            continue;
                        }


                        log_grid.ClearSelection();

                        log_grid.Rows[row].Selected = true;


                        return;

                    }




                }
            }


        }

    

        public bool date_between(DateTime date_start, DateTime date_end, DateTime date_current)
        {

            return (date_current >= date_start && date_current <= date_end);

        }

        public void hide_selected(DataGridView log_grid)
        {

            grid_suspend(log_grid);

            for (int row = 0; row < log_grid.SelectedRows.Count; row++)
            {

                log_grid.SelectedRows[row].Visible = false;
             
            }

            grid_resume(log_grid);
        }


        public void hide_show_only_selected(DataGridView log_grid)
        {

            grid_suspend(log_grid);
           
            hide_all(log_grid);

            for (int row = 0; row < log_grid.SelectedRows.Count; row++)
            {

                log_grid.SelectedRows[row].Visible = true;

            }

            grid_resume(log_grid);
        }


        public void hide_all(DataGridView log_grid)
        {

            grid_suspend(log_grid);

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {

                log_grid.Rows[row].Visible = false;

            }

            grid_resume(log_grid);

        }


        public void hide_rows_by_custom_column_multiple(DataGridView log_grid, String column_name, String value)
        {
            grid_suspend(log_grid);

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {

                if ((log_grid.Rows[row].Cells[column_name].Value.ToString().CompareTo(value) == 0))
                {

                    log_grid.Rows[row].Visible = true;

                }


            }

            grid_resume(log_grid);

        }


        public void hide_rows_by_custom_column(DataGridView log_grid, String column_name, String value)
        {
            grid_suspend(log_grid);

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {


                if ((log_grid.Rows[row].Cells[column_name].Value.ToString().CompareTo(value) == 0))
                {

                    log_grid.Rows[row].Visible = true;

                }
                else
                {

                    log_grid.Rows[row].Visible = false;

                }


            }

            grid_resume(log_grid);

        }

        public void hide_rows_by_severity(DataGridView log_grid, String severity , String severity2)
        {
            grid_suspend(log_grid);

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {


                if ((log_grid.Rows[row].Cells["Type"].Value.ToString().CompareTo(severity) == 0) || (log_grid.Rows[row].Cells["Type"].Value.ToString().CompareTo(severity2) == 0))
                {
                    log_grid.Rows[row].Visible = true;
                }
                else
                {

                    log_grid.Rows[row].Visible = false;

                }



            }


            grid_resume(log_grid);


        }

        public void hide_rows_by_date(DataGridView log_grid , DateTime date_start, DateTime date_end)
        {

            grid_suspend(log_grid);

            DateTime time;

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {

                time = Convert.ToDateTime( log_grid.Rows[row].Cells["Date"].Value.ToString());

                if (date_between(date_start, date_end, time))
                {

                    log_grid.Rows[row].Visible = true;

                }
                else
                {

                    log_grid.Rows[row].Visible = false;

                }

            }

            recalculate_rows(log_grid);
            grid_resume(log_grid);

            

        }

        public void go_to_row_number(DataGridView log_grid, int row_number)
        {

            int found_row = 0;

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {

                if (Int32.Parse(log_grid.Rows[row].Cells["No"].Value.ToString()) == row_number)
                {

                    found_row = row;

                }

            }

            try
            {

                log_grid.FirstDisplayedScrollingRowIndex = found_row;

            }
            catch (Exception exp)
            {

                MessageBox.Show("This row is not visible");

            }

        }

        public void recalculate_rows(DataGridView log_grid)
        {

            if (log_grid.Rows.Count == 0)
            {

                return;

            }

            grid_suspend(log_grid);


            int row_number = 0;

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {


                if (log_grid.Rows[row].Visible == true)
                {

                    log_grid.Rows[row].Cells["No"].Value = row_number + 1;
                    row_number++;

                }

                
            }

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {


                if (log_grid.Rows[row].Visible == false)
                {

                    log_grid.Rows[row].Cells["No"].Value = row_number + 1;
                    row_number++;
                }

                //           log_grid.Rows[row].Cells["No"].Value = row + 1;



            }


            grid_resume(log_grid);

        }


        public void add_to_grid(System.Windows.Forms.DataGridView destination_grid, EventLogEntry eLog_entry, int row_number)
        {

            // dopisz do gridu wiersz - sprawdz czy wartosc istnieje a jak nie to zastap 
            // wybrana wartoscia


            if (startup.set.security_out_of_memory_error == false)
            {

                destination_grid.Rows.Add(row_number.ToString(),
                                             change_to_none(eLog_entry.TimeGenerated.ToString()),
                                             change_to_none(eLog_entry.EntryType.ToString()),
                                             change_to_none(eLog_entry.Source.ToString()),
                                             change_to_none(eLog_entry.Category.ToString()),
                                             change_to_none(eLog_entry.UserName),
                                             change_to_none(eLog_entry.MachineName.ToString()),
                                             change_to_none(eLog_entry.EventID.ToString()),
                                             change_to_none(eLog_entry.Message.ToString()));

            }
            else
            {

                            int message_length = eLog_entry.Message.ToString().Length;

                            if (message_length > startup.set.security_out_of_memory_error_number)
                            {

                                message_length = startup.set.security_out_of_memory_error_number;
                            }

                            destination_grid.Rows.Add(row_number.ToString(),
                                            change_to_none(eLog_entry.TimeGenerated.ToString()),
                                            change_to_none(eLog_entry.EntryType.ToString()),
                                            change_to_none(eLog_entry.Source.ToString()),
                                            change_to_none(eLog_entry.Category.ToString()),
                                            change_to_none(eLog_entry.UserName),
                                            change_to_none(eLog_entry.MachineName.ToString()),
                                            change_to_none(eLog_entry.EventID.ToString()),
                                            change_to_none(eLog_entry.Message.ToString().Substring(0,message_length))); 

            }


        }


        public void add_to_grid(System.Windows.Forms.DataGridView destination_grid, Process proc, bool idle)
        {
            String machine_name = proc.MachineName;
            if (proc.MachineName == ".")
            {
                machine_name = System.Environment.MachineName;
            }

            

            if (idle == false)
            {
                destination_grid.Rows.Add(
                                            proc.ProcessName,
                                            proc.Id,
                                            machine_name,
                                            "User",
                                            proc.Responding,
                                            proc.PriorityClass,
                                            0, //proc.TotalProcessorTime.Ticks,
                                            proc.WorkingSet64 / 1024,
                                            proc.PagedSystemMemorySize64 / 1024,
                                            proc.NonpagedSystemMemorySize64 / 1024,
                                            proc.VirtualMemorySize64 / 1024,
                                            proc.PrivateMemorySize64 / 1024,
                                            proc.PriorityBoostEnabled,
                                            proc.HandleCount,
                                            proc.Threads.Count,
                                            proc.StartTime);
            }
            else
            {

                        destination_grid.Rows.Add(
                                    proc.ProcessName,
                                    0,
                                    machine_name,
                                    "User",
                                    "None",
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0);


            }



        }

        private String change_to_none(String text)
        {

            // zastap puste komorki lub (0) wybrana przez siebie wartoscia


            if (text == null)
            {
                return startup.set.none_data_in_grid;
            }


            if (text == "(0)")
            {
                return startup.set.none_data_in_grid;
            }


            text = text.Replace(System.Environment.NewLine, " ");
            text = text.Trim();

            return text;
        }


        public void grid_suspend(DataGridView log_grid)
        {


            
            log_grid.SuspendLayout();

            foreach (DataGridViewColumn c in log_grid.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

        }

        public void grid_resume(DataGridView log_grid)
        {

            foreach (DataGridViewColumn c in log_grid.Columns)
            {
                if (c.Frozen == true)
                {

                    continue;
                }

                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }



            //    log_grid.Visible = true;
           

            foreach (DataGridViewColumn c in log_grid.Columns)
            {
                if (c.Frozen == true)
                {

                    continue;
                }

                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }




           
            log_grid.ResumeLayout();


        }


        public void show_all_rows(DataGridView log_grid)
        {

            grid_suspend(log_grid);

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {

                log_grid.Rows[row].Visible = true;

            }

            grid_resume(log_grid);

        }

        public void hide_rows_by_count(DataGridView log_grid, int count_start , int count_stop)
        {

          

            if ((log_grid.Rows.Count < count_stop) ||  (log_grid.Rows.Count < count_start)) 
            {

                return;

            }


            grid_suspend(log_grid);


            for (int row = 0; row < log_grid.Rows.Count; row++)
            {

                if ((Int32.Parse(log_grid.Rows[row].Cells["No"].Value.ToString()) >= count_start) && (Int32.Parse(log_grid.Rows[row].Cells["No"].Value.ToString()) <= count_stop))
                {
                    log_grid.Rows[row].Visible = true;

                }
                else
                {
                    log_grid.Rows[row].Visible = false;

                }

            }


/*        for (int row = 0; row < count_start; row++)
        {

            log_grid.Rows[row].Visible = false;
        }


        for (int row = count_start; row < count_stop; row++)
        {

                
            log_grid.Rows[row].Visible = true;
                
                

        }

        for (int row = count_stop; row < log_grid.Rows.Count; row++)
        {

             log_grid.Rows[row].Visible = false;

        }

*/
            grid_resume(log_grid);

        }

        public void filter_reverse(DataGridView log_grid)
        {


            grid_suspend(log_grid);

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {

                log_grid.Rows[row].Visible = !log_grid.Rows[row].Visible;


            }


            grid_resume(log_grid);
        }

        public void highlights_severity_row(DataGridView log_grid)
        {
            // Error - 
            // Information - 
            // Warning   - 

            if (log_grid.Rows.Count == 0)
            {

                return;

            }

            for (int row = 0; row < log_grid.Rows.Count; row++)
            {

                if (startup.set.hg_use_highlights == true)
                {

                    log_grid.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.White;

                }
                else
                {


                    if ((log_grid.Rows[row].Cells["Type"].Value.ToString().CompareTo("Error") == 0) || (log_grid.Rows[row].Cells["Type"].Value.ToString().CompareTo("Critical") == 0)) 
                    {
                        log_grid.Rows[row].DefaultCellStyle.BackColor = startup.set.hg_error_color;
                    }


                    if (log_grid.Rows[row].Cells["Type"].Value.ToString().CompareTo("Warning") == 0)
                    {
                        log_grid.Rows[row].DefaultCellStyle.BackColor = startup.set.hg_warning_color;
                    }


                    if (log_grid.Rows[row].Cells["Type"].Value.ToString().CompareTo("Information") == 0)
                    {
                        log_grid.Rows[row].DefaultCellStyle.BackColor = startup.set.hg_info_color;
                    }

                }



            }

            



        }

        public void highlights_process(DataGridView proc_grid)
        {

            if (proc_grid.Rows.Count == 0)
            {           

                return;

            }


            for (int row = 0; row < proc_grid.Rows.Count; row++)
            {

                if (startup.set.hg_proc == false)
                {
                    proc_grid.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.White;

                }
                else
                {


                    if ((proc_grid.Rows[row].Cells["Priority"].Value.ToString().CompareTo("High") == 0))
                    {
                        proc_grid.Rows[row].DefaultCellStyle.BackColor = startup.set.hg_proc_high;
                    }
                    if ((proc_grid.Rows[row].Cells["Priority"].Value.ToString().CompareTo("Normal") == 0))
                    {
                        proc_grid.Rows[row].DefaultCellStyle.BackColor = startup.set.hg_proc_medium;
                    }
                    if ((proc_grid.Rows[row].Cells["Priority"].Value.ToString().CompareTo("Low") == 0))
                    {
                        proc_grid.Rows[row].DefaultCellStyle.BackColor = startup.set.hg_proc_low;
                    }
                    if ((proc_grid.Rows[row].Cells["Priority"].Value.ToString().CompareTo("Idle") == 0))
                    {
                        proc_grid.Rows[row].DefaultCellStyle.BackColor = startup.set.hg_proc_idle;
                    }

                }



            }

        }


        public void count_rows(DataGridView log_grid, ToolStripStatusLabel label_visible, ToolStripStatusLabel label_hidden)
        {

            int loaded_rows = log_grid.Rows.Count;
            int visible_rows = 0;

            for (int row = 0; row < loaded_rows; row++)
            {

                if (log_grid.Rows[row].Visible == true)
                {

                    visible_rows++;

                }

            }

            label_visible.Text = "Loaded: " + loaded_rows;
            label_hidden.Text = "Visible: " + visible_rows;


        }

    }
}
