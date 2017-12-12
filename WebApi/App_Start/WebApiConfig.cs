using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "game/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            InitializeDb();
        }

        private static void InitializeDb()
        {
            DB.Accounts.Add(new Account { Nickname = "Anakin", Roles = new List<string>(new string[] { "User" }) });
            DB.Accounts.Add(new Account { Nickname = "Emperor", Roles = new List<string>(new string[] { "Admin", "User" }) });
            DB.Accounts.Add(new Account { Nickname = "CrazyDestroyer1996", Roles = new List<string>(new string[] { "User" }) });

            DB.Characters.Add(new Character { Name = "Tankist78", Class = "Warrior", Experience = 0, Level = 1, AccountId=1 });
            DB.Characters.Add(new Character { Name = "Celestial", Class = "Prist", Experience = 30000, Level = 4, AccountId = 1 });
            DB.Characters.Add(new Character { Name = "Gendalf", Class = "Mage", Experience = 40000, Level = 5, AccountId = 1 });

            DB.Pets.Add(new Pets { Name = "Gosha", Role = "Support", Experience = 0, Level = 1, CharacterId = 1, Id = 1 });

        }
    }
}
