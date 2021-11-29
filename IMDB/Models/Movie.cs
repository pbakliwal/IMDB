using System;
using System.Collections.Generic;
namespace IMDB.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string DOR { get; set; }
        public int ProdcerID { get; set; }
        public string PosterURL { get; set; }
        public bool IsDeleted { get; set; }

    }

    public struct MovieDetail
    {
        public Movie Movie { get; set; }
        public Producer Producer { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    } 
}
