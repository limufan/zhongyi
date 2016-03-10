using Macrowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhongyi.Api
{
    public class ZhongyiServices
    {
        public ZhongyiServices(string server)
        {
            this.GujiService = RemotingServiceHelper.GetService<IGujiService>(server, "GujiService");
        }

        public IGujiService GujiService { set; get; }
    }
}
