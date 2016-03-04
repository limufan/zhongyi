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
    /// 本草纲目数据专区工具
    /// </summary>
    public class BencaoGangmuZhuaquGongju
    {
        public BencaoGangmuZhuaquGongju(ZhongyiServiceManager serviceManager)
            : this()
        {
            this._serviceManager = serviceManager;
        }

        public BencaoGangmuZhuaquGongju()
        {
            this._client = new WebClient();
            this._client.Encoding = Encoding.GetEncoding("GB2312");
            this._nameRegex = new Regex("<u>([^<]*)");
            this._bencaoJiluRegex = new Regex("<TD width=100% style=\"font-size:16px;line-height:38px\" valign=bottom  background=\"./images/line_bg.gif\" >([^/]*)");
            this._qiweiRegex = new Regex("【气味】([^。]*)。");
            this._bencaoZhuzhiRegex = new Regex("【主治】([^<]*)");
        }

        ZhongyiServiceManager _serviceManager;
        WebClient _client;
        Regex _nameRegex;
        Regex _bencaoJiluRegex;
        Regex _qiweiRegex;
        Regex _bencaoZhuzhiRegex;

        public void Zhuaqu(int startPian, int endPian)
        {
            while (startPian <= endPian)
            {
                try
                {
                    string url = "http://www.zhzyw.org/zygjyd/book_show.php?id=13&name=%B1%BE%B2%DD%B8%D9%C4%BF&pian=" + startPian;
                    byte[] data = this._client.DownloadData(url);
                    string content = Encoding.GetEncoding("GB2312").GetString(data);
                    this.CreateZhongyao(content, url);
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
        }

        public void CreateZhongyao(string content, string url)
        {
            ZhongyaoCreateInfo createInfo = new ZhongyaoCreateInfo();
            string name = this._nameRegex.Match(content).Groups[1].Value;
            string bencaoJilu = this._bencaoJiluRegex.Match(content).Groups[1].Value;
            string[] qiwei = this._qiweiRegex.Match(content).Groups[1].Value.Split('，');
            string bencaoZhuzhi = this._bencaoZhuzhiRegex.Match(content).Groups[1].Value;

            createInfo.Name = name;
            createInfo.BencaoJilu = url+ " " + bencaoJilu;
            createInfo.Xingwei = string.Join(",", qiwei.Take(qiwei.Length - 1));
            createInfo.Duxing = qiwei.Last();
            createInfo.BencaoZhuzhi = bencaoZhuzhi;

            this._serviceManager.ZhongyaoService.Create(createInfo);
        }
    }
}
