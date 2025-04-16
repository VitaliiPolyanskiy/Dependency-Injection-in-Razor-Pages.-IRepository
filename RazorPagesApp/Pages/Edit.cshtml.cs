using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;
using RazorPagesApp.Repository;

namespace RazorPagesApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRepository repo;

        public EditModel(IRepository r)
        {
            repo = r;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await repo.GetStudentList() == null)
            {
                return NotFound();
            }
            Student = await repo.GetStudent((int)id);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.Update(Student);
                    await repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StudentExists(Student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToPage("./Index");
            }
            return Page();
        }

        private async Task<bool> StudentExists(int id)
        {
            List<Student> list = await repo.GetStudentList();
            return (list?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
