﻿using System;
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
    [RoutePrefix("game/v1/accounts/{accountId:int}/characters")]
    public class CharactersController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Character> GetAllCharacters(int accountId)
        {
            return DB.Characters.FindAllByAccountId(accountId);
        }

        [HttpPost]
        [Route("")]
        public Character AddCharacter(int accountId, [FromBody]Character character)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            character.AccountId = accountId;
            var entity = DB.Characters.Add(character);
            DB.Inventories.Add(new Inventory() { CharacterId = entity.Id, Capacity = 100 });
            return entity;
        }

        [HttpGet]
        [Route("{characterId:int}")]
        public Character GetCharacter(int characterId)
        {
            var character = DB.Characters.Find(characterId);
            return character;
        }

        [HttpPut]
        [Route("{characterId:int}")]
        public Character UpdateCharacter(int accountId, int characterId, [FromBody]Character character)
        {
            character.Id = characterId;
            character.AccountId = accountId;
            DB.Characters.Update(character);

            var updatedCharacter = DB.Characters.Find(characterId);
            return updatedCharacter;
        }

        [HttpDelete]
        [Route("{characterId:int}")]
        public void RemoveCharacter(int characterId)
        {
            var entity = DB.Characters.Find(characterId);
            DB.Characters.Delete(entity);
        }

        [HttpGet]
        [Route("{characterId:int}/inventory")]
        public Inventory GetInventory(int characterId)
        {
            var inventory = DB.Inventories.FindByCharacterId(characterId);
            return inventory;
        }
    }
}
