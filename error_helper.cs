using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace EventReader
{
    class error_helper
    {


        public void show_error_message(Exception e , String location)
        {

            MessageBox.Show("(" + location + ")" + e.Message, "UPS: Error");


        }





    }
}
