namespace IMDB.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public bool IsDeleted { get; set; }
    }
}
