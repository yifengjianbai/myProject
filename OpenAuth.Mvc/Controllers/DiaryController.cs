using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using OpenAuth.App;
using OpenAuth.App.Interface;
using OpenAuth.Repository.dbContext;

namespace OpenAuth.Mvc.Controllers
{
    public class DiaryController : BaseController
    {
        //DiaryApp diaryApp = new DiaryApp(DatabaseHelper.GetDbInstance());
        //RedisCacheApp CacheApp;
        //public DiaryController(IDistributedCache cache)
        //{
        //CacheApp = new RedisCacheApp(cache);
        //}
        private static bool _isOpen = false;
        public DiaryController(IAuth authUtil) : base(authUtil)
        {

        }

        [AllowAnonymous]
        public string Open(bool type)
        {
            Result.Code = 200;
            Result.Message = $"操作成功";
            if (!_isOpen)
            {
                _isOpen = type;
                if (_isOpen)
                {
                    GetTicksInfo();
                }
            }
            else
            {
                _isOpen = type;
                if (!_isOpen)
                {
                    ReptilesApp.StopAnalysis();
                }
            }
            return JsonHelper.Instance.Serialize(Result);
        }

        private void GetTicksInfo()
        {
            Task.Run(() =>
            {
                ReptilesApp.AnalysisHtml();
            });
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            //int port = Request.HttpContext.Connection.LocalPort;
            //string dateTime;
            //if (CacheApp.Exists("CacheTime"))
            //{
            //    dateTime = (string)CacheApp.Get("CacheTime");
            //}
            //else
            //{
            //    dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    CacheApp.Add("CacheTime", dateTime);
            //}

            //int requestTimes;
            //if (CacheApp.Exists("RequestTimes"))
            //{
            //    requestTimes = Convert.ToInt32(CacheApp.Get("RequestTimes"));
            //    requestTimes++;
            //    CacheApp.Modify("RequestTimes", requestTimes);
            //}
            //else
            //{
            //    requestTimes = 1;
            //    CacheApp.Add("RequestTimes", requestTimes);
            //}
            //ViewData["RequestTimes"] = requestTimes;
            //ViewData["CacheTime"] = dateTime;
            //ViewData["Port"] = port;
            return View();
        }
    }
}