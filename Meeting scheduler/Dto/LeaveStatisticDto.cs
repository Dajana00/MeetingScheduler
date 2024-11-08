using MeetingScheduler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Dto
{
    public class LeaveStatisticDto
    {
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration => (EndDate - StartDate).Days;
        public string Status { get; set; }

        public LeaveStatisticDto(Leave leave)
        {
            LeaveType = leave.GetType().Name;
            StartDate = leave.StartDate;
            EndDate = leave.EndDate;
            Status = leave.Status.ToString();
        }
    }
}
