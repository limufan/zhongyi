using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zhongyi.Core;
using Zhongyi.Service;
using System.Threading;

namespace Zhongyi.ConsoleApplication.zhzyw
{
    /// <summary>
    /// 太平惠民合剂局数据抓取工具
    /// </summary>
    public class TaipingHuiminZhuaquGongju
    {
        public TaipingHuiminZhuaquGongju(ZhongyiServiceManager serviceManager)
            : this()
        {
            this._serviceManager = serviceManager;
        }

        public TaipingHuiminZhuaquGongju()
        {
            this._client = new WebClient();
            this._client.Encoding = Encoding.GetEncoding("GB2312");
            this._nameRegex = new Regex("<u>([^<]*)");
            this._fangjiShuomingRegex = new Regex("<TD width=100% style=\"font-size:16px;line-height:38px\" valign=bottom  background=\"./images/line_bg.gif\" >([^/]*)");
            this._zhuzhiRegex = new Regex("&nbsp;&nbsp;&nbsp;&nbsp;([^<]*)");
            this._peifangRegex = new Regex("<br>&nbsp;&nbsp;&nbsp;&nbsp;([^/]*)");
        }

        ZhongyiServiceManager _serviceManager;
        WebClient _client;
        Regex _nameRegex;
        Regex _fangjiShuomingRegex;
        Regex _zhuzhiRegex;
        Regex _peifangRegex;

        public void Zhuaqu(int startPian, int endPian)
        {
            Console.WriteLine("开始抓取太平惠民方...");
            while (startPian <= endPian)
            {
                try
                {
                    string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=59&name=%CC%AB%C6%BD%BB%DD%C3%F1%BA%CD%BC%C1%BE%D6%B7%BD&pian=" + startPian;
                    byte[] data = this._client.DownloadData(url);
                    string content = Encoding.GetEncoding("GB2312").GetString(data);
                    this.CreateFangji(content, url, startPian);
                    if (startPian % 100 == 0)
                    {
                        Console.WriteLine("抓取进度：" + startPian);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("抓取错误："+ startPian + "-----"+ ex.Message);
                }

                startPian++;
                Thread.Sleep(2000);
            }
            Console.WriteLine("抓取完成。");
        }

        public void CreateFangji(string content, string url, int index)
        {
            FangjiCreateInfo createInfo = new FangjiCreateInfo();
            string name = this._nameRegex.Match(content).Groups[1].Value;
            string fangjiShuoming = this._fangjiShuomingRegex.Match(content).Groups[1].Value;
            string zhuzhi = this._zhuzhiRegex.Match(content).Groups[1].Value;
            string peifang = this._peifangRegex.Match(content).Groups[1].Value;
            if (string.IsNullOrEmpty(peifang))
            {
                peifang = zhuzhi;
            }
            peifang = peifang.TrimEnd('<');

            createInfo.Name = name;
            createInfo.Beizhu = url+ " " + fangjiShuoming;
            createInfo.Zhuzhi = zhuzhi;
            createInfo.Peifang = peifang;
            createInfo.Index = index;
            createInfo.Chuchu = "太平惠民合剂局";

            this._serviceManager.FangjiService.Create(createInfo);
        }
    }
}
