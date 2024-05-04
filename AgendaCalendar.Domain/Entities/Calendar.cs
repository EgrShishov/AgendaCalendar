﻿
namespace AgendaCalendar.Domain.Entities
{
    public class Calendar : Entity
    {
        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string CalendarDescription { get; set; }

        public string CalendarColor { get; set; }

        public List<Event> Events { get; set; } = new();

        public List<Reminder> Reminders { get; set; } = new();

        public List<int> SubscribersId { get; set; } = new();
    }
}