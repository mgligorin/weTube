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
    public class LikeRatioRepository : ILikeRatioRepository, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(LikeRatio likeRatio)
        {
            db.LikeRatio.Add(likeRatio);
            db.SaveChanges();
        }

        public void Delete(LikeRatio likeRatio)
        {
            db.LikeRatio.Remove(likeRatio);
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

        public IEnumerable<LikeRatio> GetAll()
        {
            //return db.LikeRatio.Include(u => u.User);
            return db.LikeRatio;
        }

        public LikeRatio GetById(int id)
        {
            //return db.LikeRatio.Include(u => u.User).FirstOrDefault(k => k.Id == id);
            return db.LikeRatio.FirstOrDefault(u => u.Id == id);
        }

        public void Update(LikeRatio likeRatio)
        {
            db.Entry(likeRatio).State = EntityState.Modified;

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
