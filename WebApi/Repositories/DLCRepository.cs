using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class DLCRepository:Repository<DLC>
    {
        public IEnumerable<DLC> FindAllByAccountId(int accountId)
        {
            var entitiesFromDb = this.FindAllBy(c => { return c.AccountId == accountId; });
            return entitiesFromDb;
        }
    }
}