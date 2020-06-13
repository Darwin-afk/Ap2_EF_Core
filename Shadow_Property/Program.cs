using System;

namespace Shadow_Property
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                var std = new Student() { StudentName = "Bill" };

                context.Entry(std).Property("CreatedDate").CurrentValue = DateTime.Now;

                var createdDate = context.Entry(std).Property("CreatedDate").CurrentValue;
            }

            using (var context = new SchoolContext())
            {
                var std = new Student() { StudentName = "Bill" };
                context.Add(std);
                context.SaveChanges();
            }
        }
    }
}
