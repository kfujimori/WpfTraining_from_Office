using System.Runtime.InteropServices;
using System.Text;
using System;

namespace ConsoleApplication1
{
    /// <summary>
    /// INIファイルを読み書きするクラス
    /// </summary>
    public class IniFile
    {

        string filePath;
        public IniFile(string filePath)
        {
            this.filePath = filePath;
        }





        // Win32APIの GetPrivateProfileString を使う宣言
        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            uint nSize,
            string lpFileName);










        public static bool checkFileExists(string path)
        {
            // if not exists, exit this program
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("file not exists!");
                return false;
            }
            else
            {
                Console.WriteLine("exists!");
                return true;
            }
        }







        public static void ReadIniData(string path)
        {
            // streaming instance
            System.IO.StreamReader cReader = (
                new System.IO.StreamReader(path, System.Text.Encoding.Default)
            );

            // area for pushing read texts
            string stResult = string.Empty;

            // read lines untill exists
            while (cReader.Peek() >= 0)
            {
                string stBuffer = cReader.ReadLine();
                stResult += stBuffer + System.Environment.NewLine;
            }

            // close
            cReader.Close();
            // output
            Console.WriteLine(stResult);
        }



        

        public string GetIniData(string section, string key)
        {
            StringBuilder sb = new StringBuilder(1024);
            uint uintVal = Convert.ToUInt32(sb.Capacity);


            // iniファイルから文字列を取得
            IniFile.GetPrivateProfileString(
                section,
                key,
                key + " has no data",
                sb,
                Convert.ToUInt32(sb.Capacity),
                filePath);

            return sb.ToString();
        }



    }
}