using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace EventReader
{
    public partial class Event_Log_Summary : Form
    {
        String Computer_name = ".";

        public Event_Log_Summary(String Computer_name)
        {
            InitializeComponent();

            this.Computer_name = Computer_name;

            get_summary();
            add_lower_margin();

        }

        public void add_lower_margin()
        {

            Label lbl = new Label();

            lbl.Size = new Size(10, 10);
            lbl.Visible = true;
            lbl.Show();
            lbl.Text = "";
            lbl.Location = new Point(20, (get_event_log_count() + 1) * 25 + 20);
            
            this.Controls.Add(lbl);
         

        }

        public bool date_between(DateTime date_start, DateTime date_end, DateTime date_current)
        {

            return (date_current >= date_start && date_current <= date_end);

        }

        public void get_summary()
        {

            Label[,] summary_labels = new Label[get_event_log_count(),6];



            for (int i = 0; i < get_event_log_count(); i++)
            {

                for (int j = 0; j < 6; j++)
                {

                    summary_labels[i, j] = new Label();
                    summary_labels[i, j].Size = new Size(40, 13);
                    summary_labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
                }

            }

            for (int j = 0; j < get_event_log_count(); j++)
            {

                summary_labels[j, 0].Size = new Size(100, 13);
                summary_labels[j, 0].TextAlign = ContentAlignment.MiddleLeft;
            }


            for (int log = 0; log < get_event_log_count(); log++)
            {

                int today = 0;
                int yesterday = 0;
                int week = 0;
                int month = 0;
                int all = 0;

                EventLog eLog = new EventLog(get_event_log_name(log), Computer_name);
                EventLogEntry eLog_entry;
                EventLogEntryCollection entries = eLog.Entries;


               

                //dzisiaj
                //startup.dm.hide_rows_by_date(log_grid, DateTime.Today, DateTime.Today.AddDays(1));

                //wczoraj
                //startup.dm.hide_rows_by_date(log_grid, DateTime.Today.AddDays(-1), DateTime.Today);

                for (int i = entries.Count - 1; i >= 0; i--)
                {
                    eLog_entry = entries[i];


                    // dzisiaj
                    if (date_between(DateTime.Today, DateTime.Today.AddDays(1), eLog_entry.TimeGenerated))
                    {

                        today++;

                    }


                    // wczoraj
                    if (date_between(DateTime.Today.AddDays(-1), DateTime.Today, eLog_entry.TimeGenerated))
                    {

                        yesterday++;

                    }

                    // tydzien
                    if (date_between(DateTime.Today.AddDays(-7), DateTime.Today.AddDays(1), eLog_entry.TimeGenerated))
                    {

                        week++;

                    }

                    // miesiac
                    if (date_between(DateTime.Today.AddDays(-30), DateTime.Today.AddDays(1), eLog_entry.TimeGenerated))
                    {

                        month++;

                    }

                    all++;

                    

                }

                //MessageBox.Show( get_event_log_name(log) + " Dzisiaj: " + today + " Wczoraj: " + yesterday + " Week:" + week + " Month: " + month + "Overall:" + all);

                int margin_x = -50;
                int margin_y = 40;

                int jump_x = 100;
                int jump_y = 25;

                summary_labels[log, 0].Text = get_event_log_name(log);
                summary_labels[log, 0].Location = new Point(1 * jump_x + margin_x - 20, log * jump_y + margin_y);
                summary_labels[log, 0].Visible = true;
                summary_labels[log, 0].Show();
                this.Controls.Add(summary_labels[log, 1]);

                summary_labels[log, 1].Text = today.ToString();
                summary_labels[log, 1].Location = new Point(2 * jump_x + margin_x, log * jump_y + margin_y);
                summary_labels[log, 1].Visible = true;
                summary_labels[log, 1].Show();
                this.Controls.Add(summary_labels[log, 2]);

                summary_labels[log, 2].Text = yesterday.ToString();
                summary_labels[log, 2].Location = new Point(3 * jump_x + margin_x, log * jump_y + margin_y);
                summary_labels[log, 2].Visible = true;
                summary_labels[log, 2].Show();
                this.Controls.Add(summary_labels[log, 3]);

                summary_labels[log, 3].Text = week.ToString();
                summary_labels[log, 3].Location = new Point(4 * jump_x + margin_x, log * jump_y + margin_y);
                summary_labels[log, 3].Visible = true;
                summary_labels[log, 3].Show();
                this.Controls.Add(summary_labels[log, 4]);

                summary_labels[log, 4].Text = month.ToString();
                summary_labels[log, 4].Location = new Point(5 * jump_x + margin_x, log * jump_y + margin_y);
                summary_labels[log, 4].Visible = true;
                summary_labels[log, 4].Show();
                this.Controls.Add(summary_labels[log, 0]);

                summary_labels[log, 5].Text = all.ToString();
                summary_labels[log, 5].Location = new Point(6 * jump_x + margin_x, log * jump_y + margin_y);
                summary_labels[log, 5].Visible = true;
                summary_labels[log, 5].Show();
                this.Controls.Add(summary_labels[log, 5]);

            
            
            }


        }

        public int get_event_log_count()
        {
            EventLog[] el = EventLog.GetEventLogs();

            return el.Length;

        }

        public string get_event_log_name(int log_number)
        {

            EventLog[] el = EventLog.GetEventLogs();

            return el[log_number].Log;

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
        }

    }
}
