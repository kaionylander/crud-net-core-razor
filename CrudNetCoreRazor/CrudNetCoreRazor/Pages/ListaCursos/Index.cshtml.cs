﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CrudNetCoreRazor.Data;
using CrudNetCoreRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudNetCoreRazor.Pages.ListaCursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Curso> Cursos { get; set; }

        [TempData]
        public string Mensagem { get; set; }

        public async Task OnGet()
        {
            Cursos = await _db.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {

            var curso = await _db.Curso.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            _db.Curso.Remove(curso);
            await _db.SaveChangesAsync();

            Mensagem = "Curso apagado corretamente";

            return RedirectToPage("Index");

        }
    }
}