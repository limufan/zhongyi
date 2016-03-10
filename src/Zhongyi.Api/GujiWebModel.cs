using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Api
{
    [Serializable]
    public class GujiDetailsModel
    {

    }

    [Serializable]
    public class GujiFilterModel
    {
        public string Keyword { set; get; }

        public string OrderBy { set; get; }

        public bool Descending { set; get; }

        public int Start { set; get; }

        public int Size { set; get; }
    }
}
