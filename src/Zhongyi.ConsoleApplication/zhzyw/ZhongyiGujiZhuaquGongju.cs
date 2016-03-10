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
    /// 中医古籍抓取
    /// </summary>
    public class ZhongyiGujiZhuaquGongju
    {
        public ZhongyiGujiZhuaquGongju(ZhongyiServiceManager serviceManager, string chuchu, string url)
            : this(chuchu, url)
        {
            this._serviceManager = serviceManager;
        }

        public ZhongyiGujiZhuaquGongju(string chuchu, string url)
        {
            this._chuchu = chuchu;
            this._url = url;
            this._client = new WebClient();
            this._client.Encoding = Encoding.GetEncoding("GB2312");
            //this._client.Headers.Add("Host", "www.zhzyw.org");
            //this._client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.132 Safari/537.36");

            this._client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        }

        private string _chuchu;
        private string _url;
        ZhongyiServiceManager _serviceManager;
        WebClient _client;

        public void Zhuaqu(int startPian, int endPian)
        {
            Console.WriteLine("开始中医古籍...");
            while (startPian <= endPian)
            {
                try
                {
                    string url = this._url + startPian;
                    byte[] data = this._client.DownloadData(url);
                    string content = Encoding.GetEncoding("GB2312").GetString(data);
                    this.CreateGuji(content, url, startPian);
                    if (startPian % 100 == 0)
                    {
                        Console.WriteLine("抓取进度：" + startPian);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("抓取错误：" + startPian + "-----" + ex.Message);
                }

                startPian++;
                Thread.Sleep(2000);
            }
            Console.WriteLine("抓取完成。");
        }

        public void CreateGuji(string content, string url, int index)
        {
            string neirongStratTableHtml = "<TABLE align=center style=\"BORDER-COLLAPSE: collapse\" height=1 cellSpacing=0 cellPadding=0 width=\"95%\" border=0>";
            int neirongStartIndex = content.IndexOf(neirongStratTableHtml) + neirongStratTableHtml.Length;
            int neirongEndIndex = content.IndexOf("</table>");
            string neirong = content.Substring(neirongStartIndex, neirongEndIndex - neirongStartIndex);

            GujiCreateInfo createInfo = new GujiCreateInfo();

            createInfo.Biaoti = this.GetBiaoti(neirong);
            createInfo.Zhengwen = this.GetZhengwen(neirong);
            createInfo.Beizhu = url;
            createInfo.Index = index;
            createInfo.Chuchu = this._chuchu;

            this._serviceManager.GujiService.Create(createInfo);
        }

        private string GetBiaoti(string content)
        {
            string biaotiStartTdHtml = "<TD width=100% style=\"font-size:20px;line-height:56px;font-family:黑体\" valign=bottom >";
            int biaotiStartIndex = content.IndexOf(biaotiStartTdHtml) + biaotiStartTdHtml.Length;
            int biaotiEndIndex = content.IndexOf("</td>");
            string biaoti = content.Substring(biaotiStartIndex, biaotiEndIndex - biaotiStartIndex);
            
            return biaoti.Trim();
        }

        private string GetZhengwen(string content)
        {
            string zhengwenStartTdHtml = "<TD width=100% style=\"font-size:16px;line-height:38px\" valign=bottom  background=\"./images/line_bg.gif\" >";
            int zhengwenStartIndex = content.IndexOf(zhengwenStartTdHtml) + zhengwenStartTdHtml.Length;
            int zhengwenEndIndex = content.LastIndexOf("</td>");
            string zhengwen = content.Substring(zhengwenStartIndex, zhengwenEndIndex - zhengwenStartIndex);

            return zhengwen.Trim();
        }
    }
}
