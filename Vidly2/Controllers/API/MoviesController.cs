using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly2.Dtos;
using Vidly2.Models;


namespace Vidly2.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Get all movies in database
        //GET api/movies/
        public IHttpActionResult GetMovies(string query=null)
        {
            var movieQuery = _context.Movies.Include(c => c.Genre).Where(m=>m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                movieQuery = movieQuery.Where(c => c.Name.Contains(query));
            }

            var moviesDtos = movieQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDtos);
        }

        //GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }

        //POST api/movies/
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]

        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            movieDto.DateAdded = DateTime.Now;
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;


            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //DELETE api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);

        }
    }
}
