using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeTube.Interfaces;
using WeTube.Models;

namespace WeTube.Controllers
{
    public class LikeRatiosController : ApiController
    {
        ILikeRatioRepository _repository { get; set; }

        public LikeRatiosController(ILikeRatioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LikeRatio> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var likeRatio = _repository.GetById(id);
            if (likeRatio == null)
            {
                return NotFound();
            }
            return Ok(likeRatio);
        }

        public IHttpActionResult Post(LikeRatio likeRatio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(likeRatio);
            likeRatio = _repository.GetById(likeRatio.Id);
            return CreatedAtRoute("DefaultApi", new { id = likeRatio.Id }, likeRatio);
        }

        [Authorize]
        public IHttpActionResult Put(int id, LikeRatio likeRatio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != likeRatio.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(likeRatio);
                likeRatio = _repository.GetById(likeRatio.Id);
            }
            catch
            {
                throw;
            }

            return Ok(likeRatio);
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var likeRatio = _repository.GetById(id);
            if (likeRatio == null)
            {
                return NotFound();
            }

            _repository.Delete(likeRatio);
            return Ok();
        }
    }
}
