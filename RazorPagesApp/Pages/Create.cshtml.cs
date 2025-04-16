using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp.Repository;

namespace RazorPagesApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IRepository repo;

        public CreateModel(IRepository r)
        {
            repo = r;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await repo.Create(Student);
                await repo.Save();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
