﻿using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Department
    {
        //public Department()
        //{
        //    Students = new HashSet<Student>();
        //    DepartmentSubjects = new HashSet<DepartmetSubject>();
        //}

        [Key]
        public int DID { get; set; }
        [StringLength(500)]
        public string DName { get; set; } = string.Empty;
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmetSubject>();
    }
}
