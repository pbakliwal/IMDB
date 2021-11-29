using IMDB.DataAccess;
using IMDB.Models;
using System.Collections.Generic;

namespace IMDB.Services
{
    public class ProducerService : IProducerService
    {
        public string AddProducer(Producer producer)
        {
            Access access = new Access();
            if (access.InsertObject(producer))
                return "Producer Added";
            else
                return "Error";
        }

        public Producer GetProducer(string id)
        {
            Access access = new Access();
            var Producers = access.GetObjectByParam<Producer>("id", id);
            return Producers[0];
        }

        public IEnumerable<Producer> GetProducers()
        {
            Access access = new Access();
            IEnumerable<Producer> producers = access.GetAllData<Producer>();
            return producers;
        }

        public string RemoveProducer(int id)
        {
            Access access = new Access();
            if (access.DeleteObjectByID<Producer>(id))
                return "Success";
            else
                return null;
        }

        public string UpdateProducer(Producer producer)
        {
            Access access = new Access();
            return access.UpdateObject(producer);
        }
    }
}
