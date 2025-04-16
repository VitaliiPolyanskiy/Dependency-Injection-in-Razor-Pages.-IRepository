using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp.Repository;

namespace RazorPagesApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository repo;

        public DeleteModel(IRepository r)
        {
            repo = r;
        }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (await repo.GetStudentList() == null)
            {
                return NotFound();
            }
            Student = await repo.GetStudent((int)id);
            if (Student != null)
            {
                await repo.Delete((int)id); 
                await repo.Save();
            }
            return RedirectToPage("./Index");
        }
    }
}
