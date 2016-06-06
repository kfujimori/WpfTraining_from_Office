using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales
{
    class Sections
    {




        private Section _sectionItem;
        /// <summary>
        /// 部署情報
        /// </summary>
        public Section SectionItem
        {
            get { return _sectionItem; }
            set
            {
                if (_sectionItem == value) return;
                if (!SectionItems.Contains(value))
                {
                    throw new Exception("不正な値です");
                }
                _sectionItem = value;
            }
        }




        private Section[] _sectionItems;
        /// <summary>
        /// 部署情報の配列
        /// </summary>
        public Section[] SectionItems {
            get
            {
                if (_sectionItems == null) _sectionItems = CreateSectionItemList();
                return _sectionItems;
            }
        }




        /// <summary>
        /// 部署情報（ID, 名称）のリストを生成します
        /// </summary>
        /// <returns>部署情報（ID, 名称）のリスト</returns>
        private Section[] CreateSectionItemList()
        {
            string[] records = GetRecords();
            char[] separator = {':'};

            Section[] sectionArray = new Section[records.Length];

            for (int i = 0; i < records.Length; i++)
            {
                string[] sectionPair = records[i].Split(separator);

                if (sectionPair.Length != 2)
                {
                    throw new Exception("セクションのマスタ文字列がおかしい");
                }

                Section section = new Section();
                section.Id = byte.Parse(sectionPair[0]);
                section.Title = sectionPair[1].ToString();

                sectionArray[0] = section;
            }

            return sectionArray;
        }

        /// <summary>
        /// 部署情報の配列（IDと名称をコロンで結合した文字列の配列）を生成します
        /// </summary>
        /// <returns>部署情報の配列（IDと名称をコロンで結合した文字列の配列）</returns>
        private string[] GetRecords()
        {
            char[] separator = {'|'};
            string sections = "1:第一営業課|2:第二営業課|3:第三営業課|";
            return sections.Split(separator);
        }



    }
}
