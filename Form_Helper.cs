using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventReader
{
    class Form_Helper
    {
        public void hide_columns_main(DataGridView log_grid)
        {

            startup.fh.hide_columns(log_grid, "Date", startup.set.show_column_date);
            startup.fh.hide_columns(log_grid, "Type", startup.set.show_column_type);
            startup.fh.hide_columns(log_grid, "Source", startup.set.show_column_source);
            startup.fh.hide_columns(log_grid, "Category", startup.set.show_column_category);
            startup.fh.hide_columns(log_grid, "User", startup.set.show_column_user);
            startup.fh.hide_columns(log_grid, "Computer", startup.set.show_column_computer);
            startup.fh.hide_columns(log_grid, "EventID", startup.set.show_column_eventid);
            startup.fh.hide_columns(log_grid, "Description", startup.set.show_column_description);


        }
        
 
        public void hide_columns(DataGridView grid , String column_name, bool setting)
        {
            grid.Columns[column_name].Visible = setting;
        }


        public void grid_settings(DataGridView grid)
        {

            grid.AllowUserToResizeColumns = true;
            grid.AllowUserToOrderColumns = true;

        }

        public void clear_datagrid(DataGridView grid)
        {

            grid.Rows.Clear();

        }

        public void hide_item_image(ToolStripMenuItem tsmi, bool setting)
        {

            if (setting == true)
            {

                tsmi.Image = Properties.Resources.yes;

            }
            else
            {

                tsmi.Image = null;

            }

        }

        public void hide_item_image(ToolStripMenuItem tsmi)
        {

            if (tsmi.Image == null)
            {
                // set image

                tsmi.Image = Properties.Resources.yes;

            }
            else
            {
                // remove image

                tsmi.Image = null;

            }



        }


       public void hide_columns(DataGridView log_grid, String column_name)
        {

            log_grid.Columns[column_name].Visible = !log_grid.Columns[column_name].Visible;

        }

       public void change_right_panel_view(SplitContainer split_container)
       {

           split_container.Panel2Collapsed = !split_container.Panel2Collapsed;


       }


       public void change_log_selection(ToolStripComboBox toolbox_choose_log)
       {

           // log_category.Text = ;

           startup.er.set_log_type(toolbox_choose_log.SelectedItem.ToString());


       }


       public void change_machine_name(ToolStripTextBox toolstrip_machine_name)
       {

           startup.er.set_machine_name(toolstrip_machine_name.Text);

       }



    }
}
