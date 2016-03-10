using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        [Test]
        public void ZhongyiGujiZhuaquGongjuTest()
        {
            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=0&name=%C9%F1%C5%A9%B1%BE%B2%DD%BE%AD&pian=";
            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "神农本草经", url);
            zhongyiGujiZhuaquGongju.Zhuaqu(1, 1);
        } 
    }
}
