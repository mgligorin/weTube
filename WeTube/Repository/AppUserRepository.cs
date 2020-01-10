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
    public class AppUserRepository : IAppUserRepository, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(AppUser appUser)
        {
            db.AppUser.Add(appUser);
            db.SaveChanges();
        }

        public void Delete(AppUser appUser)
        {
            db.AppUser.Remove(appUser);
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

        public IEnumerable<AppUser> GetAll()
        {
            //return db.AppUser.Include(u => u.User);
            return db.AppUser;
        }

        public AppUser GetById(int id)
        {
            //return db.AppUser.Include(u => u.User).FirstOrDefault(k => k.Id == id);
            return db.AppUser.FirstOrDefault(u => u.Id == id);
        }

        public void Update(AppUser appUser)
        {
            db.Entry(appUser).State = EntityState.Modified;

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