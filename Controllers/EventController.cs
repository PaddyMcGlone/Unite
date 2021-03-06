using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unite.Models;

namespace Unite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private static List<Event> list = new List<Event>
        {
            new Event
            {
                EntityId = Guid.NewGuid(),
                Name     = "Glenarm paddle",
                Type     = EventType.Sport,
                DateTime = DateTime.Now.AddDays(2),
                Location = "Glenarm, County Antrim"
            },
            new Event
            {
                EntityId = Guid.NewGuid(),
                Name     = "Glendun paddle",
                Type     = EventType.Sport,
                DateTime = DateTime.Now.AddDays(10),
                Location = "Glendun, County Antrim"
            }
        };

        internal static List<Event> List { get => list; set => list = value; }

        [HttpGet]
        public IActionResult Get()
        {
            var upcomingEvents = List.Where(e => e.DateTime >= DateTime.Today);

            if (upcomingEvents == null)
                return NotFound();

            return Ok(upcomingEvents);
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            name = name.ToLower();
            var result = List.Where(e => e.Name.ToLower().StartsWith(name));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Event model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            bool hasEvent = List.Any(e => e.Name == model.Name);

            if (hasEvent)
                return Conflict("There is already an existing event");

            List.Add(model);

            var resourceUrl = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(model.Name));
            return Created(resourceUrl, model);
        }
    }
}