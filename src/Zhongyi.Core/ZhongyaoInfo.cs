﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Core
{
    public class ZhongyaoBaseInfo
    {
        public string Name { set; get; }

        /// <summary>
        /// 性味
        /// </summary>
        public string Xingwei { set; get; }

        /// <summary>
        /// 毒性
        /// </summary>
        public string Duxing { set; get; }

        /// <summary>
        /// 归经
        /// </summary>
        public string Guijing { set; get; }

        /// <summary>
        /// 神农本草主治说明
        /// </summary>
        public string ShenongZhuzhi { set; get; }

        /// <summary>
        /// 别录主治说明
        /// </summary>
        public string BieluZhuzhi { set; get; }

        /// <summary>
        /// 本草纲目主治说明
        /// </summary>
        public string BencaoZhuzhi { set; get; }

        /// <summary>
        /// 本草纲目记录
        /// </summary>
        public string BencaoJilu { set; get; }
    }

    public class ZhongyaoInfo : ZhongyaoBaseInfo
    {
        public string Id { set; get; }

    }

    public class ZhongyaoCreateInfo : ZhongyaoBaseInfo
    {

    }

    public class ZhongyaoChangeInfo : ZhongyaoBaseInfo
    {
        public ZhongyaoChangeInfo(Zhongyao zhongyao)
        {

        }

        public Zhongyao Zhongyao { set; get; }
    }
}
