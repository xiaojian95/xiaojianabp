using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XJ.School.Application.enumType;

namespace XJ.School.EntityFramework.Data
{
    public class DataInitializer
    {
        public static void Initializer(SchoolDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            
            //检查是否有学生信息
            if (dbContext.Studens.Any())
            {
                return;
            }
            var students = new Student[] {
                new Student{LastName="晟哥",EnrollmentDate=DateTime.Parse("2014-09-01")},
                new Student{LastName="一哥",EnrollmentDate=DateTime.Parse("2015-09-01")},
                new Student{LastName="柏义",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{LastName="司徒",EnrollmentDate=DateTime.Parse("2017-09-01")},
            };
            foreach (Student item in students)
            {
                dbContext.Studens.Add(item);
            }
            var courses = new Course[] {
                new Course{ CourseID=1050,Title="数学",Credits=3 },
                 new Course{ CourseID=4022,Title="政治",Credits=3 },
                  new Course{ CourseID=4041,Title="物理",Credits=3 },
                   new Course{ CourseID=1045,Title="化学",Credits=4 },
                    new Course{ CourseID=3141,Title="生物",Credits=4 },
                     new Course{ CourseID=2021,Title="英语",Credits=3 },
                     new Course{ CourseID=2042,Title="历史",Credits=4 }
            };
            foreach (var item in courses)
            {
                dbContext.Courses.Add(item);
            }
            var enrollments = new Enrollment[] {
                new Enrollment{ StudentID=1,CourseID=1050,Grade=CourseGrade.A },
                new Enrollment{ StudentID=1,CourseID=4022,Grade=CourseGrade.C },
                new Enrollment{ StudentID=1,CourseID=4041,Grade=CourseGrade.B },
                new Enrollment{ StudentID=2,CourseID=1045,Grade=CourseGrade.B },
                new Enrollment{ StudentID=2,CourseID=3141,Grade=CourseGrade.F },
                new Enrollment{ StudentID=2,CourseID=2021,Grade=CourseGrade.F },
                new Enrollment{ StudentID=3,CourseID=1050},
                new Enrollment{ StudentID=4,CourseID=1050},
                new Enrollment{ StudentID=4,CourseID=4022,Grade=CourseGrade.F},
                new Enrollment{ StudentID=4,CourseID=4041,Grade=CourseGrade.C},
                new Enrollment{ StudentID=4,CourseID=1045},
                new Enrollment{ StudentID=4,CourseID=3141,Grade=CourseGrade.A}
            };
            foreach (var item in enrollments)
            {
                dbContext.Enrollments.Add(item);
            }
            dbContext.SaveChanges();
        }
    }
}
