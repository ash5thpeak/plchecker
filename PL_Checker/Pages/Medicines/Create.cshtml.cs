using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PL_Checker.Data.Context;
using PL_Checker.Models;

namespace PL_Checker.Pages.Medicines
{
    public class CreateModel : PageModel
    {
        private readonly PL_Checker.Data.Context.PharmaDbContext _context;

        public CreateModel(PL_Checker.Data.Context.PharmaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Medicine Medicine { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Medicines == null || Medicine == null)
            {
                return Page();
            }

            _context.Medicines.Add(Medicine);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
