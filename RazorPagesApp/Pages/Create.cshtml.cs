using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp.Repository;

namespace RazorPagesApp.Pages;

public class CreateModel(IRepository repo) : PageModel
{
    public IActionResult OnGet() => Page();

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