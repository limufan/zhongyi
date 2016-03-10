using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Macrowing.Core;
using Macrowing;

namespace Zhongyi.Core
{
    public class GujiFilter: ObjectFilter<Guji>
    {
        public GujiFilter()
        {
            
        }

        public override List<Guji> Filtrate(List<Guji> source, out int totalCount)
        {
            this.OrderBy = "Chuchu";
            return base.Filtrate(source, out totalCount);
        }

        protected override bool Check(Guji dangan)
        {
            if (this.Keyword != null && !this.Keyword.IsMatch(dangan.Keywords))
            {
                return false;
            }

            return true;
        }
    }
}
