using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTube.Models;

namespace WeTube.Interfaces
{
    public interface IAppUserRepository
    {
        void Add(AppUser appUser);
        void Delete(AppUser appUser);
        IEnumerable<AppUser> GetAll();
        AppUser GetById(int id);
        void Update(AppUser appUser);
    }
}
