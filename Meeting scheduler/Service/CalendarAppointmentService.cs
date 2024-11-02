using MeetingScheduler.Domain.Model;
using MeetingScheduler.Dto;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Service
{
    public class CalendarAppointmentService
    {

        private readonly MeetingService _meetingService;
        private readonly LeaveService _leaveService;
        public ObservableCollection<CustomScheduleAppointment> Appointments { get; set; }  
        public CalendarAppointmentService(ObservableCollection<CustomScheduleAppointment> appointments) 
        { 
            _meetingService = new MeetingService();
            _leaveService = new LeaveService();
            Appointments = appointments;
        }

        public void EditAppointment(CustomScheduleAppointment appointment,ObservableCollection<Meeting> meetings, ObservableCollection<Leave> leaves)
        {
            if (appointment.EventType == "Meeting")
            {
                var meeting = meetings.FirstOrDefault(m => m.StartTime == appointment.StartTime && m.EndTime == appointment.EndTime && m.Location == appointment.Location);
                if (meeting != null)
                {
                    meeting.StartTime = appointment.StartTime;
                    meeting.EndTime = appointment.EndTime;
                    meeting.Location = appointment.Location;
                    _meetingService.Update(meeting);
                }
            }
            else if (appointment.EventType == "Leave")
            {
                var leave = leaves.FirstOrDefault(l => l.StartDate == appointment.StartTime && l.EndDate == appointment.EndTime);
                if (leave != null)
                {
                    leave.StartDate = appointment.StartTime;
                    leave.EndDate = appointment.EndTime;
                    _leaveService.Update(leave);
                }
            }
        }


        public void DeleteAppointment(CustomScheduleAppointment appointment, ObservableCollection<Meeting> meetings, ObservableCollection<Leave> leaves)
        {
            if (appointment.EventType == "Meeting")
            {
                // Logika za brisanje sastanka
                var meeting = meetings.FirstOrDefault(m => m.StartTime == appointment.StartTime);
                if (meeting != null)
                {
                    _meetingService.Delete(meeting.Id);
                    meetings.Remove(meeting);
                    Appointments.Remove(appointment);
                }
            }
            else if (appointment.EventType == "Leave")
            {
                // Logika za brisanje godišnjeg odmora
                var leave = leaves.FirstOrDefault(l => l.StartDate == appointment.StartTime);
                if (leave != null)
                {
                    _leaveService.Remove(leave);
                    leaves.Remove(leave);
                    Appointments.Remove(appointment);
                }
            }
        }


    }
}
