using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PL_Checker.Data.Context;
using PL_Checker.Models;

namespace PL_Checker.Pages.Medicines
{
    public class DetailsModel : PageModel
    {
        private readonly PL_Checker.Data.Context.PharmaDbContext _context;

        public DetailsModel(PL_Checker.Data.Context.PharmaDbContext context)
        {
            _context = context;
        }

      public Medicine Medicine { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Medicines == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines.FirstOrDefaultAsync(m => m.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }
            else 
            {
                Medicine = medicine;
            }
            return Page();
        }
    }
}
