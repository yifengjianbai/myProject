﻿using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using OpenAuth.App;
using OpenAuth.App.Interface;
using OpenAuth.App.Request;
using OpenAuth.Repository.Domain;

namespace OpenAuth.Mvc.Controllers
{
    public class SysLogsController : BaseController
    {
        private readonly SysLogApp _app;

         public SysLogsController(SysLogApp app, IAuth auth) : base(auth)
        {
            _app = app;
        }

        //主页
        public ActionResult Index()
        {
            return View();
        }

        //添加或修改
        [HttpPost]
        public string Add(Syslog obj)
        {
            try
            {
                _app.Add(obj);

            }
            catch (Exception ex)
            {
                Result.Code = 500;
                Result.Message = ex.Message;
            }
            return JsonHelper.Instance.Serialize(Result);
        }

        //添加或修改
        [HttpPost]
        public string Update(Syslog obj)
        {
            try
            {
                _app.Update(obj);

            }
            catch (Exception ex)
            {
                Result.Code = 500;
                Result.Message = ex.Message;
            }
            return JsonHelper.Instance.Serialize(Result);
        }

        /// <summary>
        /// 加载列表
        /// </summary>
        public string Load([FromQuery]QuerySysLogListReq request)
        {
            return JsonHelper.Instance.Serialize(_app.Load(request));
        }

        [HttpPost]
        public string Delete(string[] ids)
        {
            try
            {
                _app.Delete(ids);
            }
            catch (Exception e)
            {
                Result.Code = 500;
                Result.Message = e.Message;
            }

            return JsonHelper.Instance.Serialize(Result);
        }
    }
}