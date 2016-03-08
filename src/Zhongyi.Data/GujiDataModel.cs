using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Data
{
    public class GujiDataModel
    {
        public virtual string Id { set; get; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Biaoti { set; get; }

        /// <summary>
        /// 正文
        /// </summary>
        public virtual string Zhengwen { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Index { set; get; }

        /// <summary>
        /// 出处
        /// </summary>
        public virtual string Chuchu { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Beizhu { set; get; }
    }
}
