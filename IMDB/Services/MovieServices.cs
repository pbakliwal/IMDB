using IMDB.DataAccess;
using IMDB.Models;
using System.Collections.Generic;

namespace IMDB.Services
{
    public class MovieServices : IMovieService
    {
        public string AddMovie(Movie Movie)
        {
            Access access = new Access();
            if (access.InsertObject(Movie))
                return "Actor Added";
            else
                return "Error";
        }

        public Movie GetMovie(string id)
        {
            Access access = new Access();
            var Movies = access.GetObjectByParam<Movie>("id", id);
            return Movies[0];
        }

        public IEnumerable<Movie> GetMovies()
        {
            Access access = new Access();
            IEnumerable<Movie> movies = access.GetAllData<Movie>();
            return movies;
        }

        public string RemoveMovie(int id)
        {
            Access access = new Access();
            if (access.DeleteObjectByID<Movie>(id))
                return "Success";
            else
                return null;
        }

        public string UpdateMovie(Movie Movie)
        {
            Access access = new Access();
            return access.UpdateObject(Movie);
        }
    }
}
