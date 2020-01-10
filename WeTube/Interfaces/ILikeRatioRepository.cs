using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTube.Models;

namespace WeTube.Interfaces
{
    public interface ILikeRatioRepository
    {
        void Add(LikeRatio likeRatio);
        void Delete(LikeRatio likeRatio);
        IEnumerable<LikeRatio> GetAll();
        LikeRatio GetById(int id);
        void Update(LikeRatio likeRatio);
    }
}
