using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IMDB.Models;
using IMDB.Services;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorController()
        {
            _actorService = new ActorService();
        }
        // GET: api/<ActorController>
        [HttpGet]
        public IEnumerable<Actor> Get()
        {
            var Actors = _actorService.GetActors();
            return Actors;
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public ActionResult<Actor> Get(int id)
        {
            var Actor = _actorService.GetActor(id.ToString());
            if(Actor == null)
                return NotFound();
            return Actor;
        }

        // POST api/<ActorController>
        [HttpPost]
        public ActionResult<Actor> Post(Actor actor)
        {
            _actorService.AddActor(actor);
            return  CreatedAtAction(nameof(Get), actor.Name);
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public ActionResult<Actor> Put(int id, Actor actor)
        {
            var actorToUpdate = _actorService.GetActor(actor.Id.ToString());
            if (id != actor.Id)
            {
                return BadRequest();
            }
            if (actorToUpdate == null)
                return NotFound();
            try
            {
            _actorService.UpdateActor(actor);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public ActionResult<Actor> Delete(int id)
        {
            var actorToUpdate = _actorService.GetActor(id.ToString());
            if (actorToUpdate == null)
                return NotFound();
            try
            {
                actorToUpdate.IsDeleted = true;
                _actorService.RemoveActor(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }
    }
}
