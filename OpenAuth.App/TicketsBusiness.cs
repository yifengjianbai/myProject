using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using OpenAuth.Repository.dbContext;
using log4net;
using log4net.Repository;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace OpenAuth.App
{
    public class TicketsBusiness
    {
        //private static ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
        private static List<string> runningTickets = new List<string>();
        private static yfjbContext _dbContext;
        private static string _constr;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="context"></param>
        public TicketsBusiness(yfjbContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _constr = configuration.GetConnectionString("OpenAuthDBContext");
        }

        /// <summary>
        /// 添加到运行列表
        /// </summary>
        /// <param name="code"></param>
        public void StartTicket(string code)
        {
            runningTickets.Add(code);
        }

        /// <summary>
        /// 移除运行列表
        /// </summary>
        /// <param name="code"></param>
        public void StopTicket(string code)
        {
            runningTickets.Remove(code);
        }

        /// <summary>
        /// 运行代码
        /// </summary>
        /// <param name="code"></param>
        public void AnalysisHtml(string code)
        {
            try
            {
                HttpGet($"http://51.push2.eastmoney.com/api/qt/stock/sse?ut=fa5fd1943c7b386f172d6893dbfba10b&fltt=2&fields=f120,f121,f122,f174,f175,f59,f163,f43,f57,f58,f169,f170,f46,f44,f51,f168,f47,f164,f116,f60,f45,f52,f50,f48,f167,f117,f71,f161,f49,f530,f135,f136,f137,f138,f139,f141,f142,f144,f145,f147,f148,f140,f143,f146,f149,f55,f62,f162,f92,f173,f104,f105,f84,f85,f183,f184,f185,f186,f187,f188,f189,f190,f191,f192,f107,f111,f86,f177,f78,f110,f262,f263,f264,f267,f268,f255,f256,f257,f258,f127,f199,f128,f198,f259,f260,f261,f171,f277,f278,f279,f288,f152,f250,f251,f252,f253,f254,f269,f270,f271,f272,f273,f274,f275,f276,f265,f266,f289,f290,f294,f295&secid=1.{code}", code);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void HttpGet(string Url, string code, string postDataStr = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.Connection = "";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // 默认简单配置，输出至控制台
            //BasicConfigurator.Configure(repository);
            //ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");

            string a = "";
            string lastF170 = "";
            string lastF191 = "";
            yfjbContext yfjbContext = DatabaseHelper.GetDbInstance(_constr);
            while ((a = myStreamReader.ReadLine()) != null && runningTickets.Contains(code))
            {
                try
                {
                    if (a.Length > 5)
                    {
                        a = a.Substring(5);
                        var model = JsonConvert.DeserializeObject<TicksModel>(a);
                        if (model.data == null)
                        {
                            continue;
                        }
                        //插入数据库
                        if (model.data.f170 != null)
                        {
                            lastF170 = model.data.f170;
                        }
                        if (model.data.f191 != null)
                        {
                            lastF191 = model.data.f191;
                        }

                        if (model.data.f170 == null && model.data.f191 == null)
                        {
                            continue;
                        }

                        Ticksanalysis ticksanalysis = new Ticksanalysis()
                        {
                            Code = Convert.ToInt32(code),
                            Time = DateTime.Now,
                            WeiBi = Convert.ToSingle(lastF191),
                            UpDown = Convert.ToSingle(lastF170)
                        };

                        yfjbContext.Ticksanalysis.Add(ticksanalysis);
                        yfjbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    a = "";
                }
            }

            myStreamReader.Close();
            myResponseStream.Close();
        }
    }
}
