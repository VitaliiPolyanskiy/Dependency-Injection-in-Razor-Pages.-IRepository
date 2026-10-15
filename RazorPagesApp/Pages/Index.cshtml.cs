using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp.Repository;

namespace RazorPagesApp.Pages;

public class IndexModel : PageModel
{
    public IList<Student> Students { get; set; } = [];

    public async Task OnGetAsync([FromServices] IRepository repo)
    {
        Students = await repo.GetStudentList();
    }
}