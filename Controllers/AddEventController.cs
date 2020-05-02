using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Unite.Models;

namespace Unite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddEventController : ControllerBase
    {
        private static List<Event> events = new List<Event>
        {
            new Event
            {
                Name = "Glenarm paddle",
                Type = EventType.Sport,
                DateTime = DateTime.Now.AddDays(2),
                Location = "Glenarm, County Antrim"
            },
            new Event
            {
                Name = "Glendun paddle",
                Type = EventType.Sport,
                DateTime = DateTime.Now.AddDays(10),
                Location = "Glendun, County Antrim"
            }
        };

        public ActionResult<List<Event>> Get()
        {
            return Ok(events);
        }
    }
}