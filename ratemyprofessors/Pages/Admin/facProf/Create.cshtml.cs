﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ratemyprofessors.Models;

namespace ratemyprofessors.Pages.Admin.facProf
{
    public class CreateModel : PageModel
    {
        private readonly ratemyprofessors.Models.DataBaseContext _context;

        public CreateModel(ratemyprofessors.Models.DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FacultyID"] = new SelectList(_context.Faculties, "ID", "Name");
        ViewData["ProfessorID"] = new SelectList(_context.Professors.OrderBy(x=>x.FullName), "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public ProfFac ProfFac { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProfFacs.Add(ProfFac);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}