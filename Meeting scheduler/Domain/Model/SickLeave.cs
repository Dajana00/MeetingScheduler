using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain.Model
{
    public class SickLeave : Leave
    {
        public string MedicalCertificate { get; set; }

        public SickLeave()
        {
            ColorHex = "#AFD700";
        }
        public SickLeave(User user, DateTime startDate, DateTime endDate, Status status, string medicalCertificate)
        {
            MedicalCertificate = medicalCertificate;
            StartDate = startDate;
            User = user;
            EndDate = endDate;
            Status = status;
            ColorHex = "#AFD700";
        }   
    }

}
