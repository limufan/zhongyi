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
            this.FangjiManager = new FangjiManager();

            this.ObjectManagers.Add(this.ZhongyaoManager);
            this.ObjectManagers.Add(this.FangjiManager);
        }

        public ZhongyaoManager ZhongyaoManager { private set; get; }

        public FangjiManager FangjiManager { private set; get; }
    }
}
