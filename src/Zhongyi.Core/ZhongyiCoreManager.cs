using Macrowing.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhongyi.Core
{
    public class ZhongyiCoreManager: CoreManager
    {
        public ZhongyiCoreManager()
        {
            this.ZhongyaoManager = new ZhongyaoManager();

            this.ObjectManagers.Add(this.ZhongyaoManager);
        }

        public ZhongyaoManager ZhongyaoManager { private set; get; }
    }
}
