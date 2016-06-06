using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.Common;

namespace tutorial6_DataGridSQLExample
{
    public class ViewModel
    {
        public ViewModel()
        {

            Console.WriteLine("--------------------");
            Console.WriteLine("checkPoint");
            Console.WriteLine("--------------------");

            try
            {

                // エンティティをインスタンス化
                tacpmsEntities ent = new tacpmsEntities();

                // エンティティインスタンスからプロパティを取得
                PropertyInfo[] infoArray = ent.GetType().GetProperties();
                this.ComboList = new List<TableComboItem>();

                // テーブルプロパティのみを抽出
                foreach (PropertyInfo info in infoArray)
                {
                    if (info.PropertyType.Name.Equals("ObjectSet`1"))
                    {

                        TableComboItem tci = new TableComboItem();
                        tci.Id = info.GetHashCode().ToString();
                        tci.Name = info.Name;
                        this.ComboList.Add(tci);
                    }
                }

                Console.WriteLine("--------------------");
                Console.WriteLine("checkPoint2");
                Console.WriteLine("--------------------");

            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("--------------------");
            }

        }


        public List<TableComboItem> ComboList { get; set; }


        internal System.Collections.IEnumerable setQuery(String selectedTable)
        {
            tacpmsEntities ent = new tacpmsEntities();

            Type myType = typeof(tacpmsEntities);
            PropertyInfo myPropertyInfo = myType.GetProperty(selectedTable);

            
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(myPropertyInfo.GetValue(ent, null));
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(ent.mst_cd);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            
            //DataSet dataSet = new DataSet();

            //DataTable dataTable = dataSet.Tables[selectedTable];

            //Console.WriteLine(selectedTable);
            //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            var query =
                from dt in ent.mst_department
                select dt;
            return query.ToList();
        }
    }
}
