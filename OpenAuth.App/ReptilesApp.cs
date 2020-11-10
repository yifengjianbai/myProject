using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using NSoup;
using log4net.Repository;
using log4net;
using log4net.Config;
using System.Threading;
using OpenAuth.Repository.dbContext;

namespace OpenAuth.App
{
    public static class ReptilesApp
    {
        private static bool IsBegin = false;
        private static ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
        public static void StopAnalysis()
        {
            IsBegin = false;
        }

        public static string GetWebContent(string url)
        {
            WebRequest wrequest = WebRequest.Create(url);
            WebResponse wresponse = wrequest.GetResponse();
            Stream resStream = wresponse.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, Encoding.Default);
            string content = sr.ReadToEnd();
            resStream.Close();
            sr.Close();
            return content;
        }

        private static void HttpGet(string Url, int code, string postDataStr = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.Connection = "";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // 默认简单配置，输出至控制台
            BasicConfigurator.Configure(repository);
            ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");
            string a = "";
            string lastF170 = "";
            string lastF191 = "";
            yfjbContext dbContext = DatabaseHelper.GetDbInstance();
            while ((a = myStreamReader.ReadLine()) != null && IsBegin)
            {
                Thread.Sleep(1000 * 5);
                log.Info(a);
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
                            Code = code,
                            Time = DateTime.Now,
                            WeiBi = Convert.ToSingle(lastF191),
                            UpDown = Convert.ToSingle(lastF170)
                        };
                        dbContext.Ticksanalysis.Add(ticksanalysis);
                        dbContext.SaveChanges();
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

        public static void AnalysisHtml()
        {
            try
            {
                IsBegin = true;
                HttpGet("http://51.push2.eastmoney.com/api/qt/stock/sse?ut=fa5fd1943c7b386f172d6893dbfba10b&fltt=2&fields=f120,f121,f122,f174,f175,f59,f163,f43,f57,f58,f169,f170,f46,f44,f51,f168,f47,f164,f116,f60,f45,f52,f50,f48,f167,f117,f71,f161,f49,f530,f135,f136,f137,f138,f139,f141,f142,f144,f145,f147,f148,f140,f143,f146,f149,f55,f62,f162,f92,f173,f104,f105,f84,f85,f183,f184,f185,f186,f187,f188,f189,f190,f191,f192,f107,f111,f86,f177,f78,f110,f262,f263,f264,f267,f268,f255,f256,f257,f258,f127,f199,f128,f198,f259,f260,f261,f171,f277,f278,f279,f288,f152,f250,f251,f252,f253,f254,f269,f270,f271,f272,f273,f274,f275,f276,f265,f266,f289,f290,f294,f295&secid=1.600764", 600764);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class TicksModel
    {
        public string rc;
        public string rt;
        public string svr;
        public string lt;
        public string full;
        public TicksData data;
    }

    public class TicksData
    {
        public string f43;
        public string f44;
        public string f45;
        public string f46;
        public string f47;
        public string f48;
        public string f49;
        public string f50;
        public string f51;
        public string f52;
        public string f55;
        public string f57;
        public string f58;
        public string f59;
        public string f60;
        public string f62;
        public string f71;
        public string f78;
        public string f84;
        public string f85;
        public string f86;
        public string f92;
        public string f104;
        public string f105;
        public string f107;
        public string f110;
        public string f111;
        public string f116;
        public string f117;
        public string f120;
        public string f121;
        public string f122;
        public string f127;
        public string f128;
        public string f135;
        public string f136;
        public string f137;
        public string f138;
        public string f139;
        public string f140;
        public string f141;
        public string f142;
        public string f143;
        public string f144;
        public string f145;
        public string f146;
        public string f147;
        public string f148;
        public string f149;
        public string f152;
        public string f161;
        public string f162;
        public string f163;
        public string f164;
        public string f167;
        public string f168;
        public string f169;
        public string f170;
        public string f171;
        public string f173;
        public string f174;
        public string f175;
        public string f177;
        public string f183;
        public string f184;
        public string f185;
        public string f186;
        public string f187;
        public string f188;
        public string f189;
        public string f190;
        public string f191;
        public string f192;
        public string f198;
        public string f199;
        public string f250;
        public string f251;
        public string f252;
        public string f253;
        public string f254;
        public string f255;
        public string f256;
        public string f257;
        public string f258;
        public string f259;
        public string f260;
        public string f261;
        public string f262;
        public string f263;
        public string f264;
        public string f265;
        public string f266;
        public string f267;
        public string f268;
        public string f269;
        public string f270;
        public string f271;
        public string f272;
        public string f273;
        public string f274;
        public string f275;
        public string f276;
        public string f277;
        public string f278;
        public string f279;
        public string f288;
        public string f289;
        public string f290;
        public string f294;
        public string f295;
        public string f31;
        public string f32;
        public string f33;
        public string f34;
        public string f35;
        public string f36;
        public string f37;
        public string f38;
        public string f39;
        public string f40;
        public string f19;
        public string f20;
        public string f17;
        public string f18;
        public string f15;
        public string f16;
        public string f13;
        public string f14;
        public string f11;
        public string f12;
    }

    //交易实时数据接口接口
    //http://51.push2.eastmoney.com/api/qt/stock/sse?ut=fa5fd1943c7b386f172d6893dbfba10b&fltt=2&fields=f120,f121,f122,f174,f175,f59,f163,f43,f57,f58,f169,f170,f46,f44,f51,f168,f47,f164,f116,f60,f45,f52,f50,f48,f167,f117,f71,f161,f49,f530,f135,f136,f137,f138,f139,f141,f142,f144,f145,f147,f148,f140,f143,f146,f149,f55,f62,f162,f92,f173,f104,f105,f84,f85,f183,f184,f185,f186,f187,f188,f189,f190,f191,f192,f107,f111,f86,f177,f78,f110,f262,f263,f264,f267,f268,f255,f256,f257,f258,f127,f199,f128,f198,f259,f260,f261,f171,f277,f278,f279,f288,f152,f250,f251,f252,f253,f254,f269,f270,f271,f272,f273,f274,f275,f276,f265,f266,f289,f290,f294,f295&secid=1.600764
    //f191委比
    //f170涨幅
}
