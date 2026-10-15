using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Repository;

public class StudentRepository(StudentContext context) : IRepository
{
    public async Task<List<Student>> GetStudentList()
    {
        return await context.Students.ToListAsync();
    }

    public async Task<Student?> GetStudent(int id)
    {
        return await context.Students.FindAsync(id);
    }

    public async Task Create(Student c)
    {
        await context.Students.AddAsync(c);
    }

    public void Update(Student c)
    {
        context.Entry(c).State = EntityState.Modified;
    }

    public async Task Delete(int id)
    {
        Student? c = await context.Students.FindAsync(id);
        if (c != null)
            context.Students.Remove(c);
    }

    public async Task Save()
    {
        await context.SaveChangesAsync();
    }
}