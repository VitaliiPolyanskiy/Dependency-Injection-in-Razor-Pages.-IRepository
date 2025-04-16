using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;
using RazorPagesApp.Repository;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync([FromServices] IRepository repo)
        {
            Student = await repo.GetStudentList();
        }
    }
}
