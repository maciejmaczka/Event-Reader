using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventReader
{
    class startup
    {

       public static Main mf;
       public static Event_Reader_class er;
       public static Data_Manipulator dm;
       public static Settings set;
       public static Proc_class pr;
       public static Form_Helper fh;
       public static error_helper error;
      

            [STAThread]
      


        public static void Main()
        {
            // poczatkowa inicjalizacja ziennych
            er = new Event_Reader_class();
            dm = new Data_Manipulator();
            set = new Settings();
            pr = new Proc_class();
            fh = new Form_Helper();
            error = new error_helper();
           

            mf = new Main();
            


            // wystartuj okienka

            try
            {

                mf.ShowDialog();

            }
            catch (Exception e)
            {

                error.show_error_message( e , "0x01");

            }

        }

    }
}
