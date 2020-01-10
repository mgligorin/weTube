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
    public class VideoController : ApiController
    {
        IVideoRepository _repository { get; set; }

        public VideoController(IVideoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Video> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var video = _repository.GetById(id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        public IHttpActionResult Post(Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(video);
            video = _repository.GetById(video.Id);
            return CreatedAtRoute("DefaultApi", new { id = video.Id }, video);
        }

        [Authorize]
        public IHttpActionResult Put(int id, Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != video.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(video);
                video = _repository.GetById(video.Id);
            }
            catch
            {
                throw;
            }

            return Ok(video);
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var video = _repository.GetById(id);
            if (video == null)
            {
                return NotFound();
            }

            _repository.Delete(video);
            return Ok();
        }
    }
}
