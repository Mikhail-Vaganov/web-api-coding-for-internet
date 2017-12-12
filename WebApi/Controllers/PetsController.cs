using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [RoutePrefix("game/v1/accounts/{accountId:int}/characters/{characterId:int}/pets")]
    public class PetsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Pets> GetAllPets(int characterId)
        {
            return DB.Pets.FindAllByCharacterId(characterId);
        }

        [HttpPost]
        [Route("")]
        public Pets AddPet(int characterId,[FromBody]Pets pet)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            pet.CharacterId = characterId;
            var entity = DB.Pets.Add(pet);
            return entity;
        }

        [HttpDelete]
        [Route("{petId:int}")]
        public void RemovePet(int petId)
        {
            var entity = DB.Pets.Find(petId);
            DB.Pets.Delete(entity);
        }


    }
}
