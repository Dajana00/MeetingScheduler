using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain.Model
{
    public class MeetingUser
    {
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public MeetingUser() { }
    }
}
