using Macrowing;
using Macrowing.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Core
{
    public class Guji
    {
        public Guji(GujiInfo info)
        {
            this.SetInfo(info);
        }

        [ManagerPrimaryKey]
        public string Id { set; get; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Biaoti { set; get; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Zhengwen { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Index { set; get; }

        /// <summary>
        /// 出处
        /// </summary>
        public string Chuchu { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Beizhu { set; get; }

        public string Keywords { private set; get; }


        private void BuildKeyword()
        {
            this.Keywords = "";
        }

        private void SetInfo(GujiBaseInfo info)
        {
            ObjectMapperHelper.Map(this, info);
            this.BuildKeyword();
        }

        public void Change(GujiChangeInfo changeInfo)
        {
            this.SetInfo(changeInfo);
        }
    }
}
