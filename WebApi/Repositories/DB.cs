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

        private static AchievementsRepository achievementsRepository = new AchievementsRepository();
        public static AchievementsRepository Achievements { get { return achievementsRepository; } }

        private static SubscriptionsRepository subscriptionsRepository = new SubscriptionsRepository();
        public static SubscriptionsRepository Subscription { get { return subscriptionsRepository; } }

        private static DLCRepository dLCRepository = new DLCRepository();
        public static DLCRepository DLC { get { return dLCRepository; } }
    }
}