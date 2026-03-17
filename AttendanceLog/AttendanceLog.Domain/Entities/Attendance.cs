using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLog.Domain.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int UserId { get; set; }
        public DateOnly Date { get; set; }
        public string Status { get; set; }
        public string Course { get; set; }
        public int RecordedBy { get; set; }

        //Navigations
        public User User { get; set; }
        public User RecordedUser {  get; set; }

    }
}
