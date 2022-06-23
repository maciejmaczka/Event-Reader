using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace EventReader
{
    class Proc_class
    {
        System.Diagnostics.Process[] proc;
        PerformanceCounter[] perf_c;
        int proc_count = 0;
        
        public void load_depedities(String machine_name)
        {

            proc = System.Diagnostics.Process.GetProcesses(machine_name);

            proc_count = 0;
            

            foreach (System.Diagnostics.Process p in proc)
            {

                proc_count++;

            }

            perf_c = new PerformanceCounter[proc_count];//, p.ProcessName); 

            for (int i = 0; i < proc_count ; i++)
            {

                try
                {

                    perf_c[i] = new PerformanceCounter("Process", "% Processor Time", proc[i].ProcessName.ToString());
                    perf_c[i].NextValue();

                }
                catch (Exception e)
                {

                    startup.error.show_error_message(e, "0x03");

                }

                

            }

            System.Threading.Thread.Sleep(10000);

        }

        public void read_performance(String macine_name, DataGridView proc_grid)
        {

            for (int cur_proc = 0; cur_proc < proc_count; cur_proc++)
            {
                try
                {
                 

                    proc_grid.Rows[cur_proc].Cells["CPU"].Value = (int)perf_c[cur_proc].NextValue() + " %";
                    
                }
                catch (Exception e)
                {

                    startup.error.show_error_message(e, "0x04");

                }

            }

            //proc_grid.Sort(


        }


        public void read_processes(String machine_name, DataGridView proc_grid)
        {

            load_depedities(machine_name);

            proc_grid.Rows.Clear();

            for (int cur_proc = 0 ; cur_proc < proc_count - 1 ; cur_proc++)
            {


                startup.dm.add_to_grid(proc_grid, proc[cur_proc], false);


            }

            startup.dm.add_to_grid(proc_grid, proc[proc_count -1], true);


            read_performance(machine_name, proc_grid);



        }


  
    }
}
