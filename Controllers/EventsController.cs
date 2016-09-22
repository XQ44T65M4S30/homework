using EventsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace EventsApp.Controllers
{
    public class EventsController : ApiController
    {
        private EventAppContext dbCtx = new EventAppContext();
        
      /*  Event myEvent = new Event(){
        Name = "Breakfast",
        Descripton = "The most imporatnt meal of the day.",
        Location = "IHOP",
        StartTime = Convert.ToDateTime("10/01/2016 07:00:00"),
        EndTime = Convert.ToDateTime("10/01/2016 08:00:00")
        };
        */


        [HttpGet]
        [Route("api/Events")]
        public IEnumerable<Event> GetAllEvents()
        {
            var myEvents = (from Events in dbCtx.Events select Events);
            return myEvents;
        }

        // GET: api/Events/{id}
        // SUMMARY: foo ba
        [HttpGet]
        [Route("api/Events/{id:int}")]
        public IHttpActionResult GetEvent(int id)
        {
            var myEvent = (from Events in dbCtx.Events
                          where Events.Id == id
                          select Events).FirstOrDefault();
            if (myEvent == null)
            {
                return NotFound();
            }
            return Ok(myEvent);
        }

        // PUT: api/Events/5
        [HttpPut]
        [Route("api/Events/{id:int}", Name="PUT")]
        public async Task<HttpResponseMessage> PutEvent(int id, HttpRequestMessage request)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
            Event myEvent = new Event();
            try
            {
                myEvent = JsonConvert.DeserializeObject<Event>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            if (id != myEvent.Id)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            dbCtx.Entry(myEvent).State = EntityState.Modified;

            try
            {
                await dbCtx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemExists(id))
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                else
                {
                    throw;
                }
            }

             return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // POST: api/Events
        [HttpPost]
        [Route("api/Events/", Name = "POST")]
        public async Task<HttpResponseMessage> PostEvent(HttpRequestMessage request)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
      

            try 
            {
                Event myEvent = JsonConvert.DeserializeObject<Event>(jsonString);
                dbCtx.Events.Add(myEvent);
                await dbCtx.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE: api/Events/5
        [HttpDelete]
        [Route("api/Events/{id:int}", Name = "Delete")]
        public async Task<HttpResponseMessage> DeleteEvent(int id)
        {
            Event myEvent = await dbCtx.Events.FindAsync(id);
            if (myEvent == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            dbCtx.Events.Remove(myEvent);
            await dbCtx.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbCtx.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool itemExists(int id)
        {
            return dbCtx.Events.Count(e => e.Id == id) > 0;
        }
    }
}
