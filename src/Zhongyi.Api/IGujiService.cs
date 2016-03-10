using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhongyi.Api
{
    public interface IGujiService
    {
        List<GujiDetailsModel> Find(GujiFilterModel filterModel, out int totalCount);
    }
}
