﻿using AgendaCalendar.Application.Common.Interfaces;

namespace AgendaCalendar.Application.Meetings.Commands
{
    public sealed record InviteUserToMeetingCommand(int meetingId, int userId) : IRequest<ErrorOr<Meeting>> { }

    public class InviteUserToMeetingCommandHandler(IUnitOfWork unitOfWork, IEmailSender emailSender) 
        : IRequestHandler<InviteUserToMeetingCommand, ErrorOr<Meeting>>
    {
        public async Task<ErrorOr<Meeting>> Handle(InviteUserToMeetingCommand request, CancellationToken cancellationToken)
        {
            var meeting = await unitOfWork.MeetingRepository.GetByIdAsync(request.meetingId);
            var user = await unitOfWork.UserRepository.GetByIdAsync(request.userId);

            if (meeting == null)
            {
                return Errors.Meetings.NotFound;
            }

            if (user == null)
            {
                return Errors.User.NotFound;
            }

            var existingInvitations = await unitOfWork.InvitationRepository
                .ListAsync(i => i.MeetingId == request.meetingId && i.UserId == request.userId);

            Invitation existingInvitation = null;
            if (existingInvitations.Any())
            {
                existingInvitation = existingInvitations.First();
            }

            if (existingInvitation != null)
            {
                return Errors.Meetings.AlreadyInvited;
            }

            var invitation = new Invitation
            {
                MeetingId = request.meetingId,
                UserId = request.userId,
                Status = InvitationStatus.Pending
            };

            //tokens?
            string yourDomain = "https://localhost:7127";
            string subject = $"Meeting scheduled: {meeting.Title} ({user.UserName}) - {meeting.StartTime} - {meeting.EndTime}";
            string body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f6f6f6;
                            color: #333333;
                            margin: 0;
                            padding: 0;
                        }}
                        .container {{
                            width: 100%;
                            max-width: 600px;
                            margin: 0 auto;
                            background-color: #ffffff;
                            border: 1px solid #dddddd;
                            padding: 20px;
                        }}
                        .header {{
                            background-color: #ff9800;
                            color: #ffffff;
                            padding: 10px 20px;
                            text-align: center;
                        }}
                        .content {{
                            margin: 20px 0;
                        }}
                        .content p {{
                            line-height: 1.6;
                        }}
                        .button {{
                            display: inline-block;
                            padding: 10px 20px;
                            margin: 10px 0;
                            text-align: center;
                            text-decoration: none;
                            color: #ffffff;
                            background-color: #ff9800;
                            border-radius: 5px;
                            border: 2px solid #ff9800;
                            font-weight: bold;
                        }}
                        .button:hover {{
                            background-color: #ffffff;
                            color: #ff9800;
                        }}
                        .footer {{
                            margin-top: 20px;
                            text-align: center;
                            font-size: 12px;
                            color: #777777;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Meeting Invitation</h1>
                        </div>
                        <div class='content'>
                            <p>Dear {user.UserName},</p>
                            <p>I would like to invite you to a meeting with the following details:</p>
                            <p><strong>Title:</strong> {meeting.Title}</p>
                            <p><strong>Description:</strong> {meeting.Description}</p>
                            <p><strong>Start Time:</strong> {meeting.StartTime.ToString("dddd, MMMM d, yyyy h:mm tt")}</p>
                            <p><strong>End Time:</strong> {meeting.EndTime.ToString("dddd, MMMM d, yyyy h:mm tt")}</p>
                            <p>
                                <form action='{yourDomain}/api/meetings/accept' method='post' style='display:inline;'>
                                    <input type='hidden' name='meetingId' value='{meeting.Id}' />
                                    <button type='submit' class='button'>Accept Meeting</button>
                                </form>
                                <form action='{yourDomain}/api/meetings/decline' method='post' style='display:inline;'>
                                    <input type='hidden' name='meetingId' value='{meeting.Id}' />
                                    <button type='submit' class='button'>Decline Meeting</button>
                                </form>
                            </p>
                        </div>
                        <div class='footer'>
                            <p>&copy; 2024 AgendaCalendar. All rights reserved.</p>
                        </div>
                    </div>
                </body>
                </html>";

            await emailSender.SendMessageAsync(user.Email, subject, body); 

            await unitOfWork.InvitationRepository.AddAsync(invitation);
            await unitOfWork.SaveAllAsync();

            return meeting;
        }
    }

}
