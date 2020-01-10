using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTube.Models;

namespace WeTube.Interfaces
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        void Delete(Comment comment);
        IEnumerable<Comment> GetAll();
        Comment GetById(int id);
        void Update(Comment comment);
    }
}
