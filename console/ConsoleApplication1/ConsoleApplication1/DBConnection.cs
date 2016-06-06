using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ConsoleApplication1
{
    class DBConnection
    {




        // create connection
        public static MySqlConnection createConnection(string filePath)
        {
            // connect to MySQL
            string connParam = getConString(filePath);
            MySqlConnection conn = new MySqlConnection(connParam);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connectiong failed!!!!");
                Console.WriteLine(ex.ToString());
                throw;
            }

        }








        // execute SQL(ExecuteReader)
        internal void executeSelect(MySqlConnection conn, string sql)
        {
            // execute SQL
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " -- " + rdr[1]);
            }
            rdr.Close();

            conn.Close();
            Console.WriteLine("Done.");
            System.Threading.Thread.Sleep(2000);
        }




        // execute SQL(ExecuteNonQuery)
        internal void executeInsert(MySqlConnection conn, string sqlInsert)
        {
            // execute SQL
            MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            Console.WriteLine("Done.");
            System.Threading.Thread.Sleep(2000);
        }

        // execute SQL(ExecuteScalar)
        internal object executeGetScalar(MySqlConnection conn, string sqlInsert)
        {
            // execute SQL
            MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);

            conn.Close();
            Console.WriteLine("Done.");
            System.Threading.Thread.Sleep(2000);

            return cmd.ExecuteScalar();
        }


        // make connection string
        private static string getConString(string filePath)
        {
            IniFile.ReadIniData(filePath);

            IniFile iniFile = new IniFile(filePath);
            string server = iniFile.GetIniData("CON_PARAM", "server");
            string database = iniFile.GetIniData("CON_PARAM", "database");
            string user = iniFile.GetIniData("CON_PARAM", "user");
            string password = iniFile.GetIniData("CON_PARAM", "password");
            string charset = iniFile.GetIniData("CON_PARAM", "charset");
            // when charaset specified, error happens on opening onnection.
            // string returnString = @"server=" + server + @";user=" + user + @";database=" + database + @";password=" + password + @";charset=" + charset + ";";
            string returnString = @"server=" + server + @";user=" + user + @";database=" + database + @";password=" + password + ";";

            Console.WriteLine(returnString);
            return returnString;

        }


    }
}
