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
                        if (cmd == "本草纲目")
                        {
                            BencaoGangmuZhuaquGongju bencaoGangmuZhuaquGongju = new BencaoGangmuZhuaquGongju(serviceManager);
                            bencaoGangmuZhuaquGongju.Zhuaqu(132, 1920);
                        }
                        //else if (cmd.StartsWith("zzxg"))
                        //{
                        //    string[] cmds = cmd.Split(' ');
                        //    BianhaoZhongziXiugaiGongju bianhaoZhongziXiugaiGongju = new BianhaoZhongziXiugaiGongju(serviceManager);
                        //    bianhaoZhongziXiugaiGongju.Xiugai(cmds[1], int.Parse(cmds[2]));
                        //}
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
