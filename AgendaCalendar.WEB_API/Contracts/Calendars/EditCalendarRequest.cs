﻿namespace AgendaCalendar.WEB_API.Contracts.Calendars
{
    public record EditCalendarRequest(
        string Title,
        string CalendarDescription);
}