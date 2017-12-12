using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Repositories
{
    static public class DB
    {
        private static CredentialsRepository credentialsRepository = new CredentialsRepository();
        public static CredentialsRepository Credentials { get { return credentialsRepository; } }

        private static AccountsRepository accountsRepository = new AccountsRepository();
        public static AccountsRepository Accounts { get { return accountsRepository; } }

        private static CharactersRepository charactersRepository = new CharactersRepository();
        public static CharactersRepository Characters { get { return charactersRepository; } }

        private static InventoriesRepository inventoriesRepository = new InventoriesRepository();
        public static InventoriesRepository Inventories { get { return inventoriesRepository; } }

        private static ItemsRepository itemsRepository = new ItemsRepository();
        public static ItemsRepository Items { get { return itemsRepository; } }

        private static PetsRepository petsRepository = new PetsRepository();
        public static PetsRepository Pets { get { return petsRepository; } }
    }
}