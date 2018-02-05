using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    /// <summary>
    /// 学生表
    /// </summary>
    public class Student
    {
        public int ID { get; set; }
        [StringLength(50)]
        [DisplayName("学生姓名")]
        public string LastName { get; set; }
        [DisplayName("注册时间")]
        public DateTime EnrollmentDate { get; set; }
        [DisplayName("登记信息")]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}