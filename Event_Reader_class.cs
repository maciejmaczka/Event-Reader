using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Security;
using System.Data;
using System.Windows.Forms;
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
    class Event_Reader_class
    {
        EventLog eLog;
        EventLogEntry eLog_entry;
        EventLogEntryCollection entries;
        Stack<EventLogEntry> stack;

        int all_logs_count = 0;

        private string log_type = "Application";
        private string machine_name = ".";
        


        public void toolbox_combo_fill_logs(ToolStripComboBox toolbox_choose_log)
        {
            try
            {
                EventLog[] all_event_logs = startup.er.get_available_event_logs();



                int lenght = all_event_logs.Length;

                for (int i = 0; i < lenght; i++)
                {

                    toolbox_choose_log.Items.Add(all_event_logs[i].Log);

                }

                toolbox_choose_log.SelectedIndex = 0;

            }
            catch (Exception e)
            {

                startup.error.show_error_message(e, "0x05");


            }
        }


        public EventLog[] get_available_event_logs()
        {
         
            return  EventLog.GetEventLogs();

             
        }

        public void read_log(System.Windows.Forms.DataGridView destination_grid , DateTime date_start , DateTime date_stop ,bool read_all)
        {

            try
            {

                startup.dm.grid_suspend(destination_grid);

                int row_count = 1;

                // tutaj pozniej to zmiany logtype i machine name

                EventLog eLog = new EventLog(log_type, machine_name);
                EventLogEntry eLog_entry;
                EventLogEntryCollection entries = eLog.Entries;


                for (int i = entries.Count - 1; i >= 0; i--)
                {
                    eLog_entry = entries[i];

                    if (startup.dm.date_between(date_start, date_stop, eLog_entry.TimeGenerated))
                    {

                        // zapisz do datagrida

                        startup.dm.add_to_grid(startup.mf.get_datagrid_view(), eLog_entry, row_count);
                        row_count++;

                    }
                    else
                    {
                        // wpis nie jest dopisany czy zakonczyc

                        if (read_all == false)
                        {

                            break;  // zakonczyc

                        }




                    }


                }

            }
            catch (Exception e)
            {

                startup.error.show_error_message(e, "0x06");

            }
    
            startup.dm.grid_resume(destination_grid);

        }


        public void read_log(System.Windows.Forms.DataGridView destination_grid)
        {

            try
            {

       //         startup.dm.grid_suspend(destination_grid);

                

                // tutaj pozniej to zmiany logtype i machine name

                eLog = new EventLog(log_type, machine_name);
                entries = eLog.Entries;

                stack = new Stack<EventLogEntry>();

                for (int i = 0; i < entries.Count; i++)
                {

                    eLog_entry = entries[i];
                    stack.Push(eLog_entry);
                    


                }



            }
            catch (Exception e)
            {

                startup.error.show_error_message(e, "0x07");

            }

           

        }

        public void read_log_to_grid(DataGridView destination_grid)
        {

            int row_count = 0;
            while (stack.Count != 0)
            {

                eLog_entry = stack.Pop();

               // zapisz do datagrida

                startup.dm.add_to_grid(startup.mf.get_datagrid_view(), eLog_entry, row_count);
                row_count++;

                startup.mf.toolStripProgressBar1.Value = (row_count * 100 / all_logs_count);

            }

       //     for (int i = entries.Count - 1; i >= 0; i--)
            {



            }

            //startup.dm.grid_resume(destination_grid);
        }


        public void set_log_type(string log_type)
        {

            this.log_type = log_type;

        }

        public void set_machine_name(string machine_name)
        {

            this.machine_name = machine_name;

        }


        public string get_log_type()
        {

            return log_type;


        }



        public void run_read_log_from_system_last_7(DataGridView log_grid, ToolStripStatusLabel label_loaded, ToolStripStatusLabel label_visible)
        {

            log_grid.Rows.Clear();
            startup.er.read_log(log_grid, DateTime.Today.AddDays(-7), DateTime.Today.AddDays(1), true);          // zaladuj logi
            startup.dm.count_rows(log_grid, label_loaded, label_visible);

        }

        public void run_read_log_from_system_last_1(DataGridView log_grid, ToolStripStatusLabel label_loaded, ToolStripStatusLabel label_visible)
        {

            log_grid.Rows.Clear();
            startup.er.read_log(log_grid, DateTime.Today, DateTime.Today.AddDays(1), true);          // zaladuj logi
            startup.dm.count_rows(log_grid, label_loaded, label_visible);

        }

        public void run_read_log_from_system_last_30(DataGridView log_grid, ToolStripStatusLabel label_loaded, ToolStripStatusLabel label_visible)
        {
            log_grid.Rows.Clear();
            startup.er.read_log(log_grid, DateTime.Today.AddDays(-30), DateTime.Today.AddDays(1), true);          // zaladuj logi
            startup.dm.count_rows(log_grid, label_loaded, label_visible);

        }

        public void run_read_log_from_system_all(DataGridView log_grid, ToolStripStatusLabel label_loaded, ToolStripStatusLabel label_visible)
        {
            var bw = new BackgroundWorker();
            bw.WorkerReportsProgress =true;

            startup.dm.grid_suspend(log_grid);      
            log_grid.Rows.Clear();
            

            
            bw.ProgressChanged += worker_ProgressChanged;
            bw.DoWork += delegate 
            {
                


                try
                {

                    //         startup.dm.grid_suspend(destination_grid);



                    // tutaj pozniej to zmiany logtype i machine name

                    eLog = new EventLog(log_type, machine_name);
                    entries = eLog.Entries;

                    stack = new Stack<EventLogEntry>();
                    all_logs_count = entries.Count;
                    for (int i = 0; i < entries.Count; i++)
                    {

                        eLog_entry = entries[i];
                        stack.Push(eLog_entry);


                        if (i % 10  == 0)
                        {
                           // progress =  (i / entries.Count * 100);
                            bw.ReportProgress((i * 100 / entries.Count));
                        }
                    }

                   

                }
                catch (Exception e)
                {

                    startup.error.show_error_message(e, "0x07");

                }

           

               
            };
           

            bw.RunWorkerCompleted += delegate
            {

                read_log_to_grid(log_grid);
                startup.dm.count_rows(log_grid, label_loaded, label_visible);
                startup.dm.grid_resume(log_grid);

            };
  


            bw.RunWorkerAsync();


           

        }



        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            startup.mf.toolStripProgressBar1.Value = e.ProgressPercentage;
        }




    }


}
    