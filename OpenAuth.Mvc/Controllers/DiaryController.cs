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
using OpenAuth.App.Base;
using OpenAuth.App.Interface;
using OpenAuth.Repository.dbContext;

namespace OpenAuth.Mvc.Controllers
{
    public class DiaryController : Controller
    {
        //DiaryApp diaryApp = new DiaryApp(DatabaseHelper.GetDbInstance());
        //RedisCacheApp CacheApp;
        //public DiaryController(IDistributedCache cache)
        //{
        //CacheApp = new RedisCacheApp(cache);
        //}
        private ReptilesApp ReptilesApp;
        private TicketsBusiness TicketsBusiness;
        public DiaryController(yfjbContext dbContext, TicketsBusiness ticketsBusiness)
        {
            ReptilesApp = new ReptilesApp(dbContext);
            TicketsBusiness = ticketsBusiness;
        }

        [HttpGet]
        public PagingData<Tickets> GetTickets(string code, string name, int pageIndex, int pageSize)
        {
            var data = ReptilesApp.GetTickets(code, name, pageIndex, pageSize);
            return data;
        }

        [HttpPost]
        public BaseReponse AddTicket([FromBody]Tickets ticket)
        {
            bool res = ReptilesApp.AddTicket(ticket);
            return new BaseReponse()
            {
                Code = res ? 200 : -1
            };
        }

        [HttpPost]
        public BaseReponse DelTicket([FromBody]List<Tickets> tickets)
        {
            bool res = ReptilesApp.DelTicket(tickets);
            return new BaseReponse()
            {
                Code = res ? 200 : -1
            };
        }

        [HttpPost]
        public BaseReponse StartTicket([FromBody]Tickets ticket)
        {
            bool res = ReptilesApp.StartTicket(ticket);
            if (res)
            {
                Task.Run(() =>
                {
                    TicketsBusiness.StartTicket(ticket.Code);
                    TicketsBusiness.AnalysisHtml(ticket.Code);
                });
            }
            return new BaseReponse()
            {
                Code = res ? 200 : -1
            };
        }

        [HttpPost]
        public BaseReponse StopTicket([FromBody]Tickets ticket)
        {
            bool res = ReptilesApp.StopTicket(ticket);
            if (res)
            {
                TicketsBusiness.StopTicket(ticket.Code);
            }
            return new BaseReponse()
            {
                Code = res ? 200 : -1
            };
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