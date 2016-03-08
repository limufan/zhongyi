using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhongyi.ConsoleApplication.zhzyw;
using Zhongyi.Service;

namespace Zhongyi.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("正在启动服务......");
                string nhibernatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Zhongyi.HB.config");
                ZhongyiServiceManager serviceManager = new ZhongyiServiceManager(nhibernatePath);
                serviceManager.Start();
                Console.WriteLine("服务已启动");

                while (true)
                {
                    try
                    {
                        Console.Write("$ ");
                        string cmd = Console.ReadLine();
                        cmd = cmd.TrimStart("$ ".ToArray());
                        if (cmd == "本草纲目数据抓取")
                        {
                            BencaoGangmuZhuaquGongju bencaoGangmuZhuaquGongju = new BencaoGangmuZhuaquGongju(serviceManager);
                            bencaoGangmuZhuaquGongju.Zhuaqu(132, 1920);
                        }
                        else if (cmd == "太平惠民合剂局数据抓取")
                        {
                            TaipingHuiminZhuaquGongju taipingHuiminZhuaquGongju = new TaipingHuiminZhuaquGongju(serviceManager);
                            taipingHuiminZhuaquGongju.Zhuaqu(2, 809);
                        }
                        else if (cmd == "脾胃论数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=614&name=%C6%A2%CE%B8%C2%DB&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "脾胃论", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(1, 102);
                        }
                        else if (cmd == "伤寒论数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=457&name=%C9%CB%BA%AE%C2%DB&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "伤寒论", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(0, 9);
                        }
                        else if (cmd == "金匮要略数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=499&name=%BD%F0%D8%D1%D2%AA%C2%D4%B7%BD%C2%DB&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "金匮要略", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(0, 24);
                        }
                        else if (cmd == "黄帝内经素问数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=437&name=%BB%C6%B5%DB%C4%DA%BE%AD%CB%D8%CE%CA&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "黄帝内经素问", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(0, 82);
                        }
                        else if (cmd == "黄帝内经灵枢数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=431&name=%BB%C6%B5%DB%C4%DA%BE%AD%C1%E9%CA%E0%BC%AF%D7%A2&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "黄帝内经灵枢", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(0, 109);
                        }
                        else if (cmd == "难经数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=421&name=%B0%CB%CA%AE%D2%BB%C4%D1%BE%AD&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "难经", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(0, 80);
                        }
                        else if (cmd == "温病条辨数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=526&name=%CE%C2%B2%A1%CC%F5%B1%E6&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "温病条辨", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(0, 85);
                        }
                        else if (cmd == "诸病源候论数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=571&name=%D6%EE%B2%A1%D4%B4%BA%F2%C2%DB&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "诸病源候论", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(0, 1737);
                        }
                        else if (cmd == "医宗金鉴数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=575&name=%D2%BD%D7%DA%BD%F0%BC%F8&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "医宗金鉴", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(0, 2381);
                        }
                        else if (cmd == "小儿药证直诀数据抓取")
                        {
                            string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=133&name=%D0%A1%B6%F9%D2%A9%D6%A4%D6%B1%BE%F7&pian=";
                            ZhongyiGujiZhuaquGongju zhongyiGujiZhuaquGongju = new ZhongyiGujiZhuaquGongju(serviceManager, "小儿药证直诀", url);
                            zhongyiGujiZhuaquGongju.Zhuaqu(0, 219);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            Console.ReadLine();
        }
    }
}
