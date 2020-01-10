using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WeTube.Interfaces;
using WeTube.Models;

namespace WeTube.Repository
{
    public class VideoRepository : IVideoRepository, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(Video video)
        {
            db.Video.Add(video);
            db.SaveChanges();
        }

        public void Delete(Video video)
        {
            db.Video.Remove(video);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Video> GetAll()
        {
            //return db.Video.Include(u => u.User);
            return db.Video;
        }

        public Video GetById(int id)
        {
            //return db.Video.Include(u => u.User).FirstOrDefault(v => v.Id == id);
            return db.Video.FirstOrDefault(v => v.Id == id);
        }

        public void Update(Video video)
        {
            db.Entry(video).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
