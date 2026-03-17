using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLog.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId {  get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        // Navigations
        public Role Role { get; set; }
        public UserDetails UserDetails { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Attendance> RecordedAttendances { get; set; }

    }
}
