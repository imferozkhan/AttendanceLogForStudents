using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLog.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        //Navigations
        public ICollection<User> Users { get; set; }
    }
}
