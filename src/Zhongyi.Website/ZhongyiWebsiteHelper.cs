using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Macrowing.Api;
using Macrowing;
using Macrowing.Web;
using Zhongyi.Api;

namespace Zhongyi.Website
{
    public class ZhongyiWebsiteHelper
    {
        static ZhongyiWebsiteHelper()
        {
            ZhongyiServices zhongyiServices = new ZhongyiServices(WebHelper.ApiServiceServer);
            GujiService = zhongyiServices.GujiService;
        }

        public static IGujiService GujiService { private set; get; }

        public static string Verion
        {
            get
            {
                return "0.1";
            }
        }
    }
}