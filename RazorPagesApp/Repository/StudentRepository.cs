using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Repository
{
    public class StudentRepository : IRepository
    {
        private readonly StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetStudentList()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task Create(Student c)
        {
            await _context.Students.AddAsync(c);
        }

        public void Update(Student c)
        {
            _context.Entry(c).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Student? c = await _context.Students.FindAsync(id);
            if (c != null)
                _context.Students.Remove(c);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }       
    }
}