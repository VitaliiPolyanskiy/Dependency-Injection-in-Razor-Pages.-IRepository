using Microsoft.EntityFrameworkCore;

namespace RazorPagesApp.Models;

// Щоб підключитися до бази даних через Entity Framework, необхідний контекст даних. 
// Контекст даних являє собою клас, похідний від класу DbContext.
public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {
        if (Database.EnsureCreated())
        {
            Students.Add(new Student { Name = "Іван", Surname = "Іваненко", Age = 27, GPA = 10.5 });
            Students.Add(new Student { Name = "Сергій", Surname = "Сергієнко", Age = 23, GPA = 11.5 });
            Students.Add(new Student { Name = "Петро", Surname = "Петренко", Age = 21, GPA = 12 });
            SaveChanges();
        }
    }
}