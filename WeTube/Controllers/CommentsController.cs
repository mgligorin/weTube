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
    public class CommentsController : ApiController
    {
        ICommentRepository _repository { get; set; }

        public CommentsController(ICommentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Comment> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var comment = _repository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        public IHttpActionResult Post(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(comment);
            comment = _repository.GetById(comment.Id);
            return CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
        }

        [Authorize]
        public IHttpActionResult Put(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(comment);
                comment = _repository.GetById(comment.Id);
            }
            catch
            {
                throw;
            }

            return Ok(comment);
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var comment = _repository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            _repository.Delete(comment);
            return Ok();
        }
    }
}
