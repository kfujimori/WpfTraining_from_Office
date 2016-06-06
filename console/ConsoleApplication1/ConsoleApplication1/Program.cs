using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            // ini file path
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @".\AppConfig.ini";





            // file existance check
            if (!IniFile.checkFileExists(filePath))
            {
                System.Threading.Thread.Sleep(500);
                return;
            }



            // DB connecting
            try
            {
                MySqlConnection conn = null;
                DBConnection execSQL = new DBConnection();

                // select
                conn = DBConnection.createConnection(filePath); 
                string sql = "select customer_cd, customer_nm from mst_business_partner where customer_nm like '%ク%'";
                execSQL.executeSelect(conn, sql);



                // insert
                conn = DBConnection.createConnection(filePath);
                string sqlInsert = "insert into test_fujimori values ('010','hoge')";
                execSQL.executeInsert(conn, sqlInsert);


                // get scalar data
                conn = DBConnection.createConnection(filePath);
                string sqlGetScalar = "select count(*) from test_fujimori";
                System.Threading.Thread.Sleep(3000);
                object result = execSQL.executeGetScalar(conn, sqlGetScalar);

                if (result != null)
                {
                    int r = Convert.ToInt32(result);
                    Console.WriteLine("Number of countries in the World database is: " + r);
                    System.Threading.Thread.Sleep(3000);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("aborting!!!!");
                Console.WriteLine(ex.ToString());
                System.Threading.Thread.Sleep(20000);
            }



        }








    }

}
