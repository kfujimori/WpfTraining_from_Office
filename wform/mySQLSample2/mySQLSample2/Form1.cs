using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace mySQLSampl2
{
    public partial class Form1 : Form
    {
        MySqlDataAdapter daCountry;
        DataSet dsCountry;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string connStr = "server=AWSTEMEDDB01;user=tacpms;database=tacpms;port=3306;password=tactac;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                label1.Text = "Connecting to MySQL...";

                string sql = "select * from test_fujimori";
                daCountry = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daCountry);

                dsCountry = new DataSet();
                daCountry.Fill(dsCountry, "test_fujimori");
                dataGridView1.DataSource = dsCountry;
                dataGridView1.DataMember = "test_fujimori";
                label1.Text = "Connected to MySQL...";
            }
            catch (Exception ex)
            {
                label1.Text = ex.ToString();
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            daCountry.Update(dsCountry, "test_fujimori");
            label1.Text = "MySQL Database Updated!";
        }

    }
}