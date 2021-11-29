using IMDB.Models;
using System.Collections.Generic;
namespace IMDB.Services
{
    public interface IMovieDetailService
    {
        IEnumerable<MovieDetail> GetMovieDetails();
        MovieDetail GetMovieDetail(Movie movie);
        string AddMovieDetail(MovieDetail movieDetail);
        string RemoveMovieDetail(int id);
        string UpdateMovieDetail(MovieDetail movieDetail);
    }
}
