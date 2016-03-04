using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Data
{
    public class FangjiDataModel
    {
        public virtual string Id { set; get; }

        public virtual string Name { set; get; }

        /// <summary>
        /// 主治
        /// </summary>
        public virtual string Zhuzhi { set; get; }

        /// <summary>
        /// 配方
        /// </summary>
        public virtual string Peifang { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Index { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Beizhu { set; get; }
    }
}
