using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhongyi.ConsoleApplication.zhzyw;
using Zhongyi.Service;

namespace Zhongyi.Tests
{
    public class ZHZYWZhuaquGongjuTests
    {
        public ZHZYWZhuaquGongjuTests()
        {
            string nhibernatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Zhongyi.HB.config");
            serviceManager = new ZhongyiServiceManager(nhibernatePath);
            serviceManager.Load();
        }

        ZhongyiServiceManager serviceManager;

        [Test]
        public void BencaoGangmuZhuaquGongjuTest()
        {
            BencaoGangmuZhuaquGongju bencaoGangmuZhuaquGongju = new BencaoGangmuZhuaquGongju(serviceManager);
            bencaoGangmuZhuaquGongju.Zhuaqu(419, 419);
        }

        [Test]
        public void TaipingHuiminZhuaquGongjuTest()
        {
            TaipingHuiminZhuaquGongju taipingHuiminZhuaquGongju = new TaipingHuiminZhuaquGongju(serviceManager);
            taipingHuiminZhuaquGongju.Zhuaqu(3, 3);
        } 
    }
}
