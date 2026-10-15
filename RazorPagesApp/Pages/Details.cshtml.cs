using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp.Repository;

namespace RazorPagesApp.Pages;

public class DetailsModel(IRepository repo) : PageModel
{
    public Student Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || await repo.GetStudentList() == null) return NotFound();

        var student = await repo.GetStudent((int)id);

        if (student == null) return NotFound();

        Student = student;
        return Page();
    }
}