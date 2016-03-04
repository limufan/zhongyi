using Macrowing;
using Macrowing.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Core
{
    public class Fangji
    {
        public Fangji(FangjiInfo info)
        {
            this.SetInfo(info);
        }

        [ManagerPrimaryKey]
        public string Id { set; get; }

        public string Name { set; get; }

        /// <summary>
        /// 主治
        /// </summary>
        public string Zhuzhi { set; get; }

        /// <summary>
        /// 配方
        /// </summary>
        public string Peifang { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Beizhu { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Index { set; get; }

        public string Keywords { private set; get; }


        private void BuildKeyword()
        {
            this.Keywords = "";
        }

        private void SetInfo(FangjiBaseInfo info)
        {
            ObjectMapperHelper.Map(this, info);
            this.BuildKeyword();
        }

        public void Change(FangjiChangeInfo changeInfo)
        {
            this.SetInfo(changeInfo);
        }
    }
}
