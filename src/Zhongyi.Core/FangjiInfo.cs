using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Core
{
    public class FangjiBaseInfo
    {
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
    }

    public class FangjiInfo : FangjiBaseInfo
    {
        public string Id { set; get; }

    }

    public class FangjiCreateInfo : FangjiBaseInfo
    {

    }

    public class FangjiChangeInfo : FangjiBaseInfo
    {
        public FangjiChangeInfo(Fangji zhongyao)
        {

        }

        public Fangji Fangji { set; get; }
    }
}
