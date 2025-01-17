﻿using System.ComponentModel.DataAnnotations;

namespace MVCStudentClassAssignment.Model.Model
{
    public class StudentClass
    {
        [Key]
        public int Id { get; set; }
        public virtual SchoolClass Class { get; set; }
        public virtual User Student { get; set; }
    }
}
