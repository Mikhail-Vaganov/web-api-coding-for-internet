using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("game/v1/accounts/{accountId:int}/characters/{characterId:int}/achievements")]
    public class AchievementsController : ApiController
    {
        
        [HttpGet]
        [Route("")]
        public IEnumerable<Achievements> GetAllAchievements( int characterId)
        {
            return DB.Achievements.FindAllByCharacterId(characterId);
        }


        [HttpPost]
        [Route("")]
        public Achievements AddAchievements(int characterId, [FromBody]Achievements achievement)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            achievement.CharacterId = characterId;

            var entity = DB.Achievements.Add(achievement);
            return entity;

        }

        /*[HttpGet]
        [Route("{achievementId:int}")]
        public Achievements GetAchievement(int achievementId)
        {
            var achievement = DB.Achievements.Find(achievementId);
            return achievement;
        }*/

        [HttpPut]
        [Route("{achievementId:int}")]
        public Achievements UpdateAchievements(int achievementId, int characterId, [FromBody]Achievements achievement)
        {
            achievement.Id = achievementId;
            achievement.CharacterId = characterId;
            DB.Achievements.Update(achievement);

            var updateAchievement = DB.Achievements.Find(achievementId);
            return updateAchievement;
        }

        [HttpDelete]
        [Route("{achievementId:int}")]
        public void RemoveAchievement(int achievementId)
        {
            var entity = DB.Achievements.Find(achievementId);
            DB.Achievements.Delete(entity);
        }
    }
}