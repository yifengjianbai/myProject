using OpenAuth.Repository.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAuth.App
{
    public class DiaryApp
    {
        private yfjbContext _yfjbContext;
        public DiaryApp(yfjbContext yfjbContext)
        {
            if (yfjbContext == null)
            {
                this._yfjbContext = yfjbContext;
            }
        }

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
