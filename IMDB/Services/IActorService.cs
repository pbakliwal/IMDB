using System;
using System.Collections.Generic;
using IMDB.Models;

namespace IMDB.Services
{
    public interface IActorService
    {
        IEnumerable<Actor> GetActors();
        Actor GetActor(string id);
        string AddActor(Actor actor);
        string RemoveActor(int id);
        string UpdateActor(Actor actor);
    }
}
