using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DigiMovei.Dtos;
using AutoMapper;
using System.Data.Entity;
using DigiMovei.Models;

namespace DigiMovei.Controllers.Api
{
    public class MoviesController : ApiController
    {


        private ApplicationDbContext db;
        private IMapper mapper;

        public MoviesController()
        {
            db = new ApplicationDbContext();
            mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<Movie, MoveiDto>();
                c.CreateMap<MoveiDto, Movie>();
            }).CreateMapper();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        //GET /api/Movies
        [HttpGet]
        public IEnumerable<MoveiDto> GetMovies(string query = null)
        {
            return db.Movies.ToList().Select(mapper.Map<Movie, MoveiDto>);
        }

        //GET /api/Movies/1
        [HttpGet]
        public MoveiDto GetMovie(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return mapper.Map<Movie, MoveiDto>(movie);
        }

        //POST /api/Movies/
        [HttpPost]
        public MoveiDto PostMovie(MoveiDto MoveiDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var movie = mapper.Map<MoveiDto, Movie>(MoveiDto);
            db.Movies.Add(movie);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            MoveiDto.Id = movie.Id;
            return MoveiDto;
        }

        //PUT /api/Movies/1
        [HttpPut]
        public void PutMovie(int id, MoveiDto MoveiDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = mapper.Map<MoveiDto, Movie>(MoveiDto);

            if (id != movie.Id)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            db.Entry(movie).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        //DELETE /api/Movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            db.Movies.Remove(movie);
            db.SaveChanges();
        }
    }


}
