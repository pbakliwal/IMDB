using IMDB.DataAccess;
using IMDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Services
{
    public class MovieDetailService : IMovieDetailService
    {
        public string AddMovieDetail(MovieDetail movieDetail)
        {
            throw new System.NotImplementedException();
        }

        public MovieDetail GetMovieDetail(Movie movie)
        {
            Access access = new Access();
            var movieDetail = new MovieDetail();
            movieDetail.Movie = movie;
            movieDetail.Producer = access.GetObjectByParam<Producer>("id", movie.ProdcerID.ToString())[0];
            var actorList = access.GetObjectByParam<MovieActorList>("MovieID", movie.ID.ToString());
            var actors = new List<Actor>();
            foreach (var actor in actorList)
                actors.Add(access.GetObjectByParam<Actor>("ID", actor.ID.ToString())[0]);
            movieDetail.Actors = actors;
            return movieDetail;
        }

        public IEnumerable<MovieDetail> GetMovieDetails()
        {
            Access access = new Access();
            var MovieList = access.GetAllData<Movie>();
            List<MovieDetail> movieDetailList = new List<MovieDetail>();
            foreach (var movie in MovieList)
            {
                var movieDetail = GetMovieDetail(movie);
                movieDetailList.Add(movieDetail);
            }
            return movieDetailList;
        }

        public string RemoveMovieDetail(int id)
        {
            throw new System.NotImplementedException();
        }

        public string UpdateMovieDetail(MovieDetail movieDetail)
        {
            Access access = new Access();
            access.UpdateObject(movieDetail.Movie);
            var actorList = access.GetObjectByParam<MovieActorList>("MovieID", movieDetail.Movie.ID.ToString());
            access.DeleteMovieLisT(movieDetail.Movie.ID);
            if (movieDetail.Actors != null)
            {
                foreach (var item in movieDetail.Actors)
                {
                        access.InsertObject(new MovieActorList() { ActorID=item.Id,MovieID=movieDetail.Movie.ID});
                }

            }
            return "Success";
        }
    }
}
