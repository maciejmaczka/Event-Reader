using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EventReader
{
    class Settings
    {

        public string none_data_in_grid =  "<none>" ;


        public bool hg_use_highlights = false;
        public Color hg_error_color = System.Drawing.Color.LightCoral;
        public Color hg_warning_color = System.Drawing.Color.Yellow;
        public Color hg_info_color = System.Drawing.Color.Aqua;


        public bool show_column_date = true;
        public bool show_column_type = true;
        public bool show_column_source = true;
        public bool show_column_category = true;
        public bool show_column_user = true;
        public bool show_column_computer = true;
        public bool show_column_eventid = false;
        public bool show_column_description = true;



        public bool security_out_of_memory_error = true;
        public int security_out_of_memory_error_number = 500;



        public bool hg_proc = false;
        public Color hg_proc_low = System.Drawing.Color.LightGreen;
        public Color hg_proc_medium = System.Drawing.Color.LightBlue;
        public Color hg_proc_high = System.Drawing.Color.LightGoldenrodYellow;
        public Color hg_proc_idle = System.Drawing.Color.LightGray;


        public int event_log_summary_bind_to_others = 10;

    }
}
