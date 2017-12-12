using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Repositories
{
    public class PetsRepository : Repository<Pets>
    {
        public IEnumerable<Pets> FindAllByCharacterId(int characterId)
        {
            var entitiesFromDb = this.FindAllBy(c => { return c.CharacterId == characterId; });
            return entitiesFromDb;
        }

    }
}