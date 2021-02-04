using Microsoft.AspNetCore.Mvc;
using OpenAuth.App.Base;
using OpenAuth.Repository.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAuth.App
{
    /// <summary>
    /// music业务领域
    /// </summary>
    public class MusicApp
    {
        private yfjbContext yfjbContext;
        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="dbContext"></param>
        public MusicApp(yfjbContext dbContext)
        {
            yfjbContext = dbContext;
        }

        /// <summary>
        /// 添加/修改音乐
        /// </summary>
        /// <param name="id">标题</param>
        /// <param name="title">标题</param>
        /// <param name="album">专辑</param>
        /// <param name="singer">歌手</param>
        /// <param name="tag">标签</param>
        /// <param name="url">音乐路径</param>
        /// <param name="pic">图片路径</param>
        /// <param name="pubTime">发布时间</param>
        public void AddUptMusic(int id, string title, string album, string singer, string tag, string url, string pic, DateTime pubTime)
        {
            var music1 = yfjbContext.Music.FirstOrDefault(m => m.Id == id);
            //添加
            if (music1 != null)
            {
                Music music = new Music()
                {
                    Album = album,//专辑
                    Pic = pic,//图片路径
                    Singer = singer,//歌手
                    Tag = tag,//标签
                    Title = title,//标题
                    Url = url,//音乐路径
                    PubTime = pubTime,//发布时间
                    Status = 1
                };
                yfjbContext.Music.Add(music);
            }
            else//修改
            {
                music1.Album = album;
                music1.Pic = pic;
                music1.Singer = singer;
                music1.Tag = tag;
                music1.Title = title;
                music1.Url = url;
                music1.PubTime = pubTime;
            }
            yfjbContext.SaveChanges();
        }

        /// <summary>
        /// 添加/修改音乐
        /// </summary>
        /// <param name="music"></param>
        public int AddUptMusic(Music music)
        {
            try
            {
                var music1 = yfjbContext.Music.FirstOrDefault(m => m.Id == music.Id);
                //添加
                if (music1 == null)
                {
                    music.Status = 1;
                    yfjbContext.Music.Add(music);
                }
                else//修改
                {
                    music1.Album = music.Album;
                    music1.Pic = music.Pic;
                    music1.Singer = music.Singer;
                    music1.Tag = music.Tag;
                    music1.Title = music.Title;
                    music1.Url = music.Url;
                    music1.PubTime = music.PubTime;
                }
                if (yfjbContext.SaveChanges() > -1)
                {
                    return 200;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return -1;
        }

        /// <summary>
        /// 删除音乐
        /// </summary>
        /// <param name="musics"></param>
        public int RemoveMusic(List<Music> musics)
        {
            foreach (var music in musics)
            {
                var mus = yfjbContext.Music.FirstOrDefault(m => m.Id == music.Id);
                if (mus != null)
                {
                    mus.Status = -1;
                }
            }
            if (yfjbContext.SaveChanges() > -1)
            {
                return 200;
            }
            return -1;
        }

        /// <summary>
        /// 获取音乐
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Music GetMusicById(int id)
        {
            var music = yfjbContext.Music.FirstOrDefault(m => m.Id == id);
            return music;
        }

        /// <summary>
        /// 查询音乐，模糊查询
        /// </summary>
        /// <param name="condition">条件筛选，歌手，标题，标签，专辑</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagingData<Music> GetMusicList(string condition, int pageIndex, int pageSize)
        {
            var rsp = new PagingData<Music>();
            if (string.IsNullOrEmpty(condition))
            {
                rsp.Countnum = yfjbContext.Music.Where(m => m.Status == 1).Count();
                rsp.Data = yfjbContext.Music.Where(m => m.Status == 1).OrderByDescending(m => m.Id)
                    .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                rsp.Countnum = yfjbContext.Music.Where(m => m.Singer.Contains(condition)
                                                        || m.Title.Contains(condition)
                                                        || m.Tag.Contains(condition)
                                                        || m.Album.Contains(condition)).Count();
                rsp.Data = yfjbContext.Music.Where(m => m.Singer.Contains(condition)
                                                        || m.Title.Contains(condition)
                                                        || m.Tag.Contains(condition)
                                                        || m.Album.Contains(condition))
                                            .OrderByDescending(m => m.Id)
                                            .Skip((pageIndex - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();
            }
            return rsp;
        }
    }
}
