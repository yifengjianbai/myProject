using OpenAuth.Repository.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAuth.App
{
    /// <summary>
    /// 日记服务类
    /// </summary>
    public class DiaryApp
    {
        private yfjbContext _yfjbContext;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="yfjbContext"></param>
        public DiaryApp(yfjbContext yfjbContext)
        {
            if (yfjbContext == null)
            {
                this._yfjbContext = yfjbContext;
            }
        }

        /// <summary>
        /// 添加日记
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="type"></param>
        /// <param name="content"></param>
        public void AddDiary(string title, string author, string type, string content)
        {
            TableDiary tableDiary = new TableDiary()
            {
                Title = title,
                Author = author,
                Type = type,
                Content = content,
                CreateTime = DateTime.Now
            };
            _yfjbContext.Add(tableDiary);
            _yfjbContext.SaveChanges();
        }

        /// <summary>
        /// 删除日记
        /// </summary>
        /// <param name="id"></param>
        public void DropDiary(int id)
        {
            var diary = _yfjbContext.TableDiary.FirstOrDefault(d => d.Id == id);
            if (diary != null)
            {
                _yfjbContext.TableDiary.Remove(diary);
                _yfjbContext.SaveChanges();
            }
        }
    }
}
