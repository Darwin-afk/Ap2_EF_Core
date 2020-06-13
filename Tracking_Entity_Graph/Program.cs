using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Tracking_Entity_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student()
            {
                StudentId = 1,
                Name = "Bill",
                Address = new StudentAddress()
                {
                    StudentAddressId = 1,
                    City = "Seattle",
                    Country = "USA"
                },
                StudentCourses = new List<StudentCourse>() {
                    new StudentCourse(){  Course = new Course(){ CourseName="Machine Language" } },
                    new StudentCourse(){  Course = new Course(){  CourseId=2 } }
                }
            };

            var context = new SchoolContext();

            context.ChangeTracker.TrackGraph(student, e => {
                if (e.Entry.IsKeySet)
                {
                    e.Entry.State = EntityState.Unchanged;
                }
                else
                {
                    e.Entry.State = EntityState.Added;
                }
            });

            foreach (var entry in context.ChangeTracker.Entries())
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}," +
                    $"State: { entry.State.ToString()}" +
                    $"");
}
        }
    }
}
