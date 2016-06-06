using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySqlAndLinq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 単純に post テーブルの内容を表示
            tacpmsEntities1 ent = new tacpmsEntities1();
            var records =
                from n in ent.mst_broadcast_station
                select n;
            dataGridView1.DataSource = records;
        }
    }
}
