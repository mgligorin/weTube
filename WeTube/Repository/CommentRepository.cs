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
    public class CommentRepository : ICommentRepository, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(Comment comment)
        {
            db.Comment.Add(comment);
            db.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            db.Comment.Remove(comment);
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

        public IEnumerable<Comment> GetAll()
        {
            //return db.Comment.Include(u => u.User);
            return db.Comment;
        }

        public Comment GetById(int id)
        {
            //return db.Comment.Include(u => u.User).FirstOrDefault(k => k.Id == id);
            return db.Comment.FirstOrDefault(u => u.Id == id);
        }

        public void Update(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;

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
