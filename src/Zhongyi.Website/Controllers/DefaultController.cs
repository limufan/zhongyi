using Macrowing.Web.Controllers;
using Macrowing.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zhongyi.Api;

namespace Zhongyi.Website.Controllers
{
    public class DefaultController : BaseController
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string argsJson)
        {
            ControllerResultModel model = new ControllerResultModel();
            try
            {
                GujiFilterModel filterModel = JsonConvert.DeserializeObject<GujiFilterModel>(argsJson);
                int totalCount;
                List<GujiDetailsModel> gujiList = ZhongyiWebsiteHelper.GujiService.Find(filterModel, out totalCount);
                model.Add("gujiList", gujiList);
                model.Add("gujiCount", totalCount);
            }
            catch(Exception ex)
            {
                model.result = false;
                model.message = ex.Message;
            }
            return Json(model);
        }


    }
}
