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
    public partial class Event_Analyze : Form
    {
        DataGridView log_grid;
        String[] point_name = new string[1000];
        int[] point_value = new int[1000];
        int values_found = 0;

        public Event_Analyze(DataGridView log_grid)
        {

            InitializeComponent();

            this.log_grid = log_grid;

            for (int i = 0; i < 1000; i++)
            {

                //point_value[i] = new int();
                point_value[i] = 0;
                point_name[i] = "";

            }


            remove_all();
            analyze_statistics(log_grid, comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            remove_all();
            analyze_statistics(log_grid, comboBox1.Text);
        }

        public void remove_all()
        {

            analyze_table.Rows.Clear();
            main_chart.Series[0].Points.Clear();    


        }

        public int check_values(String value)
        {

            for (int row = 0; row < 1000; row++)
            {

                if (point_name[row] == value)
                {

                    return row;

                }


            }

            return -1;
        }


        public void analyze_statistics(DataGridView log_grid , String col_name)
        {
            values_found = 0;
            //col_name = "Source";

            for (int i = 0; i < 1000; i++)
            {
                point_name[i] = "";
                point_value[i] = 0;

            }
  
         try
         {

            for (int rows = 0; rows < log_grid.Rows.Count; rows++)
            {

 
                // sprawdz czy wartosc juz sie powtorzyla

                if (check_values(log_grid.Rows[rows].Cells[col_name].Value.ToString()) == -1)
                {
                    // wartosci nie bylo jeszcze

                    point_name[values_found] = log_grid.Rows[rows].Cells[col_name].Value.ToString();
                    point_value[values_found] = 1;

                    values_found++;

                }
                else
                {
                    // wartosc juz byla

                    point_value[check_values(log_grid.Rows[rows].Cells[col_name].Value.ToString())]++;

                }


            }


          
            

            for ( int i = 0 ;  i < values_found; i++)
            {


             //  main_chart.Series[0].Points.AddXY( point_name[i], point_value[i]);

               analyze_table.Rows.Add(point_name[i], point_value[i]);

            }

            analyze_table.Sort(analyze_table.Columns["B"], ListSortDirection.Descending);

            for (int i = 0; i < values_found; i++)
            {
                if (i == 10)
                {
                    
                    break;

                }

                main_chart.Series[0].Points.AddXY(analyze_table.Rows[i].Cells["A"].Value.ToString() + " [" + int.Parse(analyze_table.Rows[i].Cells["B"].Value.ToString()) + "]" , int.Parse(analyze_table.Rows[i].Cells["B"].Value.ToString()));
            
            }

            int others = 0;

            if (values_found > 10)
            {

                for (int i = 10; i < values_found; i++)
                {

                    others += int.Parse(analyze_table.Rows[i].Cells["B"].Value.ToString());


                }


                main_chart.Series[0].Points.AddXY("Others [" + others + "]" , others);   

            }

         }
         catch (Exception e)
         {

             MessageBox.Show(e.Message);
         }
        }


    }
}
