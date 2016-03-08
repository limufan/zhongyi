using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Core
{
    public class GujiBaseInfo
    {

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
    }

    public class GujiInfo : GujiBaseInfo
    {
        public string Id { set; get; }

    }

    public class GujiCreateInfo : GujiBaseInfo
    {

    }

    public class GujiChangeInfo : GujiBaseInfo
    {
        public GujiChangeInfo(Guji zhongyao)
        {

        }

        public Guji Guji { set; get; }
    }
}
