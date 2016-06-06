using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales
{
    class Years
    {
        private short _yearItem;
        /// <summary>
        /// 年度
        /// </summary>
        public short YearItem
        {
            get { return _yearItem; }
            set
            {
                if (_yearItem == value) return;
                if (!YearItems.Contains(value)) throw new Exception("不正な値です");
            }
        }

        private short[] _yearItems;
        /// <summary>
        /// 年度の配列
        /// </summary>
        public short[] YearItems
        {
            get
            {
                if(_yearItems == null) _yearItems = CreateYearItems();
                return _yearItems;
            }
        }

        /// <summary>
        /// 年度の配列を生成
        /// </summary>
        /// <returns>年度の配列</returns>
        private short[] CreateYearItems()
        {
            int minYear = 2015;
            int maxYear = DateTime.Now.Year;

            return Enumerable.Range(minYear, maxYear).Select(i => (short)i).ToArray();
        }
    }
}
