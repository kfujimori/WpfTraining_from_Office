using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace conMySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ///
        /// データ保持用
        ///
        DataTable m_dt;


        // クリア
        private void button1_Click_1(object sender, EventArgs e)
        {
            // 挿入時のクリア
            dataGridView1.Columns.Clear();
            // バインド時
            dataGridView1.DataSource = null;
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {

            // コネクション作成
            MySqlConnection cn = new MySqlConnection(
                "server=AWSTEMEDDB01;user=tacpms;database=tacpms;port=3306;password=tactac;");
            MySqlDataAdapter da = new MySqlDataAdapter(
                "SELECT * FROM test_fujimori", cn);
            DataTable dt = new DataTable();
            // 検索
            da.Fill(dt);
            // 表示
            dataGridView1.DataSource = dt;
            // データ保持
            m_dt = dt;
        }

        // DataSet自前ボタン
        private void button3_Click_1(object sender, EventArgs e)
        {
            // コネクション作成
            MySqlConnection cn = new MySqlConnection(
                    "server=AWSTEMEDDB01;user=tacpms;database=tacpms;port=3306;password=tactac;");
            MySqlDataAdapter da = new MySqlDataAdapter(
                    "SELECT * FROM test_fujimori", cn);
            DataTable dt = new DataTable();
            // 検索
            da.Fill(dt);
            // 自前で表示
            dataGridView1.Columns.Add("t_id", "id");
            dataGridView1.Columns.Add("t_name", "name");
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["t_id"];
                dataGridView1.Rows[n].Cells[1].Value = item["t_name"];
            }
        }

        // 保存済みのDataSetボタン
        private void button4_Click_1(object sender, EventArgs e)
        {
            // 表示
            dataGridView1.DataSource = m_dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(
                    "server=AWSTEMEDDB01;user=tacpms;database=tacpms;port=3306;password=tactac;");
            // コマンドを作成
            MySqlCommand cmd =
                new MySqlCommand("insert into test_fujimori values (@t_id, @t_name)", cn);
            DateTime dt = DateTime.Now;
            string param = dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString();
            // パラメータ設定
            cmd.Parameters.Add(
                new MySqlParameter("t_id", param));
            cmd.Parameters.Add(
                new MySqlParameter("t_name", "konica"));

            // オープン
            cmd.Connection.Open();
            // 実行
            cmd.ExecuteNonQuery();
            // クローズ
            cmd.Connection.Clone();
        }

    }
}
