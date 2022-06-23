using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EventReader
{
    public partial class Go_to_Row_Number : Form
    {

        DataGridView log_grid;

        public Go_to_Row_Number()
        {
            InitializeComponent();
        }

        public Go_to_Row_Number(DataGridView log_grid)
        {

            InitializeComponent();
            this.log_grid = log_grid;

        }




        public void only_number_guard(object sender)
        {

            TextBox txtbox = (TextBox)sender;

            txtbox.Text = Regex.Replace(txtbox.Text, "[^.0-9]", "");

            txtbox.SelectionStart = txtbox.Text.Length;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            only_number_guard(sender);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            startup.dm.go_to_row_number(log_grid, Int32.Parse(row_number_textbox.Text.ToString()));

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}
