using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTube.Models;

namespace WeTube.Interfaces
{
    public interface IVideoRepository
    {
        void Add(Video video);
        void Delete(Video video);
        IEnumerable<Video> GetAll();
        Video GetById(int id);
        void Update(Video video);
    }
}
