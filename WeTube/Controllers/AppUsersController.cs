using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeTube.Interfaces;
using WeTube.Models;

namespace WeTube.Controllers
{
    public class AppUsersController : ApiController
    {
        IAppUserRepository _repository { get; set; }

        public AppUsersController(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AppUser> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var appUser = _repository.GetById(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return Ok(appUser);
        }

        public IHttpActionResult Post(AppUser appUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(appUser);
            appUser = _repository.GetById(appUser.Id);
            return CreatedAtRoute("DefaultApi", new { id = appUser.Id }, appUser);
        }

        [Authorize]
        public IHttpActionResult Put(int id, AppUser appUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appUser.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(appUser);
                appUser = _repository.GetById(appUser.Id);
            }
            catch
            {
                throw;
            }

            return Ok(appUser);
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var appUser = _repository.GetById(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _repository.Delete(appUser);
            return Ok();
        }
    }
}
