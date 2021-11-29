using IMDB.Models;
using System.Collections.Generic;
using IMDB.DataAccess;

namespace IMDB.Services
{
    public class ActorService : IActorService
    {
        public string AddActor(Actor actor)
        {
            Access access = new Access();
            if (access.InsertObject(actor))
                return "Actor Added";
            else
                return "Error";
        }

        public Actor GetActor(string id)
        {
            Access access = new Access();
            var Actors = access.GetObjectByParam<Actor>("id", id);
            return Actors[0];
        }

        public IEnumerable<Actor> GetActors()
        {
            Access access = new Access();
            IEnumerable<Actor> actors = access.GetAllData<Actor>();
            return actors;
        }

        public string RemoveActor(int id)
        {
            Access access = new Access();
            if (access.DeleteObjectByID<Actor>(id))
                return "Success";
            else
                return null;
        }

        public string UpdateActor(Actor actor)
        {
            Access access = new Access();
            return access.UpdateObject(actor);
        }
    }
}
