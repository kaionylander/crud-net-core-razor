using CrudNetCoreRazor.Data;
using CrudNetCoreRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CrudNetCoreRazor.Pages.ListaCursos
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Curso Curso{ get; set; }

        public async Task OnGet(int id)
        {
            Curso = await _db.Curso.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoDb = await _db.Curso.FindAsync(Curso.Id);
                CursoDb.Nome = Curso.Nome;
                CursoDb.QuantidadeClasses = Curso.QuantidadeClasses;
                CursoDb.Preco = Curso.Preco;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return RedirectToPage();
           
        }
    }
}