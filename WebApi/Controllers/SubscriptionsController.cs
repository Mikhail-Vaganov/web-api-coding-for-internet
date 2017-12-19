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
    [RoutePrefix("game/v1/accounts/{accountId:int}/subscriptions")]
    public class SubscriptionsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Subscription> GetAllSubscription()
        {
            return DB.Subscription.FindAll();
        }

        [HttpPost]
        [Route("")]
        public Subscription AddSubscription(int accountId,[FromBody]Subscription subscription)
        {
            subscription.AccountId = accountId;
           
            var entity = DB.Subscription.Add(subscription);
            return entity;
        }

        [HttpPut]
        [Route("{subscriptionId:int}")]
        public Subscription UpdateSubscription(int subscriptionId, [FromBody]Subscription subscription)
        {
            subscription.Id = subscriptionId;
            DB.Subscription.Update(subscription);

            var updateSubscription = DB.Subscription.Find(subscriptionId);
            return updateSubscription;
        }

        [HttpDelete]
        [Route("{subscriptionId:int}")]
        public void RemoveSubscription(int subscriptionId)
        {
            var subscription = DB.Subscription.Find(subscriptionId);
            DB.Subscription.Delete(subscription);
        }
    }
}
