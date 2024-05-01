﻿using AgendaCalendar.Application.Events.Commands;
using AgendaCalendar.Application.Events.Queries;
using AgendaCalendar.Domain.Common.Errors;
using AgendaCalendar.Domain.Entities;
using AgendaCalendar.WEB_API.Contracts.Events;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaCalendar.WEB_API.Controllers
{
    [Route("api/events")]
    public class EventController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EventController(IMediator mediator, IMapper mapper) 
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateEventRequest request, int calendarId, int authorId)
        {
            var command = _mapper.Map<AddEventCommand>((request, calendarId, authorId));

            var createEventResult = await _mediator.Send(command);

            return Ok(_mapper.Map<EventResponse>(createEventResult));
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(EditEventRequest request, int eventId, int authorId)
        {
            var command = _mapper.Map<UpdateEventCommand>((request, eventId, authorId));

            var editEventResult = await _mediator.Send(command);

            return Ok(_mapper.Map<EventResponse>(editEventResult));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteEventResult = await _mediator.Send(new DeleteEventCommand(id));

            return deleteEventResult.Match(
                deleteEventResult => Ok(_mapper.Map<EventResponse>(deleteEventResult)),
                errors => Problem(errors));
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> UpcomingEvents(int calendarId)
        {
            var upcomingEventsResult = await _mediator.Send(new EventListQuery(calendarId));

            return upcomingEventsResult.Match(
                upcomingEventsResult => Ok(_mapper.Map<List<EventResponse>>(upcomingEventsResult.Take(5))),
                errors => Problem(errors));
        }
    }
}