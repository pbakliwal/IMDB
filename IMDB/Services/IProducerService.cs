using IMDB.Models;
using System.Collections.Generic;
namespace IMDB.Services
{
    public interface IProducerService
    {
        IEnumerable<Producer> GetProducers();
        Producer GetProducer(string id);
        string AddProducer(Producer producer);
        string RemoveProducer(int id);
        string UpdateProducer(Producer producer);
    }
}
