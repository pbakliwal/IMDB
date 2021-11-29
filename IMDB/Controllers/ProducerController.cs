using IMDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IMDB.Services;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducerController()
        {
            _producerService = new ProducerService();
        }
        // GET: api/<ProducerController>
        [HttpGet]
        public IEnumerable<Producer> Get()
        {
            var Producers = _producerService.GetProducers();
            return Producers;
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public ActionResult<Producer> Get(int id)
        {
            var producer = _producerService.GetProducer(id.ToString());
            if(producer == null)
                return NotFound();
            return Ok(producer);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public ActionResult<Producer> Post(Producer producer)
        {
            _producerService.AddProducer(producer);
            return CreatedAtAction(nameof(Get), producer);
        }

        // PUT api/<ProducerController>/5
        [HttpPut("{id}")]
        public ActionResult<Producer> Put(int id, Producer producer)
        {

            var actorToUpdate = _producerService.GetProducer(producer.ID.ToString());
            if (id != producer.ID)
            {
                return BadRequest();
            }
            if (actorToUpdate == null)
                return NotFound();
            try
            {
                _producerService.UpdateProducer(producer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Producer> Delete(int id)
        {
            var actorToUpdate = _producerService.GetProducer(id.ToString());
            if (actorToUpdate == null)
                return NotFound();
            try
            {
                actorToUpdate.IsDeleted = true;
                _producerService.RemoveProducer(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }
    }
}
