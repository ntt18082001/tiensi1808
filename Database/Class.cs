using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Database
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public int SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
