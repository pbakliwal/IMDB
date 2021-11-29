using IMDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IMDB.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieDetailService  _MovieDetailService;
        private readonly IMovieService _MovieService;
        private readonly IProducerService _ProducerService;
        private readonly IActorService _ActorService;
        
        public MovieController()
        {
            _MovieDetailService = new MovieDetailService();
            _MovieService = new MovieServices();
              _ProducerService = new ProducerService();
            _ActorService = new ActorService();
        }    
        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<MovieDetail> Get()
        {
            var movieDetailLIst = _MovieDetailService.GetMovieDetails();
            return movieDetailLIst;
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public ActionResult<MovieDetail> Get(int id)
        {
            var movie = _MovieService.GetMovie(id.ToString());
            if (movie == null)
                return NotFound();
            var movieDetail = _MovieDetailService.GetMovieDetail(movie);
            
            return Ok(movieDetail);
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
