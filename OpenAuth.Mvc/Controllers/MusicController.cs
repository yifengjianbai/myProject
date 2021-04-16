using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OpenAuth.App;
using OpenAuth.App.Base;
using OpenAuth.Repository.dbContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OpenAuth.Mvc.Controllers
{
    public class MusicController : Controller
    {
        public IWebHostEnvironment environment;
        private readonly MusicApp MusicApp;
        public IOptions<AppSetting> AppConfiguration;
        public MusicController(MusicApp musicApp, IWebHostEnvironment hostingEnvironment, IOptions<AppSetting> appConfiguration)
        {
            environment = hostingEnvironment;
            MusicApp = musicApp;
            AppConfiguration = appConfiguration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult PlayMusic(int Id)
        {
            var music = MusicApp.GetMusicById(Id);
            ViewData["title"] = music.Title;
            ViewData["pic"] = formatUrl(music.Pic);
            ViewData["url"] = formatUrl(music.Url);
            return View();
        }

        public string formatUrl(string str)
        {
            return str.Replace("\\","/");
        }

        /// <summary>
        /// 添加/修改音乐
        /// </summary>
        /// <param name="music"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseReponse AddUptMusic([FromBody]Music music)
        {
            BaseReponse baseReponse = new BaseReponse
            {
                Code = MusicApp.AddUptMusic(music)
            };
            return baseReponse;
        }

        /// <summary>
        /// 下架音乐
        /// </summary>
        /// <param name="musics"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseReponse DownMusic([FromBody]List<Music> musics)
        {
            BaseReponse baseReponse = new BaseReponse
            {
                Code = MusicApp.DownMusic(musics)
            };
            return baseReponse;
        }

        /// <summary>
        /// 上架音乐
        /// </summary>
        /// <param name="musics"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseReponse UpMusic([FromBody]List<Music> musics)
        {
            BaseReponse baseReponse = new BaseReponse
            {
                Code = MusicApp.UpMusic(musics)
            };
            return baseReponse;
        }

        /// <summary>
        /// 查询音乐
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public PagingData<Music> GetMusicListAuthor(string condition, int pageIndex, int pageSize)
        {
            return MusicApp.GetMusicListAuthor(condition, pageIndex, pageSize);
        }

        [AllowAnonymous]
        public IActionResult MusicWeb()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public PagingData<Music> GetMusicList(string condition, int pageIndex, int pageSize)
        {
            return MusicApp.GetMusicList(condition, pageIndex, pageSize);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetEncrypstr(string str)
        {
            return Encryption.Encrypt(str);
        }

        [HttpPost]
        public BaseReponse Upload(IFormFile file)
        {
            BaseReponse respo = new BaseReponse();
            respo.Message = "";
            try
            {
                var path = environment.WebRootPath + @"/fileupload/";//获取应用程序的当前工作目录
                if (file != null)
                {
                    var fileDir = path;
                    if (!Directory.Exists(fileDir))
                    {
                        Directory.CreateDirectory(fileDir);
                    }
                    //文件名称
                    string projectFileName = file.FileName;
                    //string projectFileName = System.Web.HttpUtility.UrlEncode(file.FileName);
                    string str = DateTime.Now.ToString("yyyyMMddHHmmss");//用时间做唯一码
                                                                            //上传的文件的路径
                    string filePath = fileDir + str + projectFileName;
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }

                    respo.Message = AppConfiguration.Value.UrlAddress + @"/fileupload/" + str + projectFileName;//图片地址
                    respo.Code = 200;
                    respo.Other = filePath;
                }
                else
                {
                    respo.Code = 501;
                    respo.Message = "服务器没有收到上传文件";
                }
            }
            catch (Exception ex)
            {
                respo.Code = 500;
                respo.Message = ex.Message;
            }
            return respo;
        }
    }
}