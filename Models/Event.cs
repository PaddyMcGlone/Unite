using System;

namespace Unite.Models
{
    public class Event
    {
        public Guid EntityId { get; set; }

        public EventType Type { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime DateTime { get; set; }

        public string Notes { get; set; }
    }
}