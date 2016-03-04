using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Data
{
    public class ZhongyaoDataModel
    {
        public virtual string Id { set; get; }

        public virtual string Name { set; get; }

        /// <summary>
        /// 性味
        /// </summary>
        public virtual string Xingwei { set; get; }

        /// <summary>
        /// 毒性
        /// </summary>
        public virtual string Duxing { set; get; }

        /// <summary>
        /// 归经
        /// </summary>
        public virtual string Guijing { set; get; }

        /// <summary>
        /// 神农本草主治说明
        /// </summary>
        public virtual string ShenongZhuzhi { set; get; }

        /// <summary>
        /// 别录主治说明
        /// </summary>
        public virtual string BieluZhuzhi { set; get; }

        /// <summary>
        /// 本草纲目主治说明
        /// </summary>
        public virtual string BencaoZhuzhi { set; get; }

        /// <summary>
        /// 本草纲目记录
        /// </summary>
        public virtual string BencaoJilu { set; get; }
    }
}
