using IMDB.Models;
using System.Collections.Generic;
namespace IMDB.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovie(string id);
        string AddMovie(Movie Movie);
        string RemoveMovie(int id);
        string UpdateMovie(Movie Movie);
    }
}
