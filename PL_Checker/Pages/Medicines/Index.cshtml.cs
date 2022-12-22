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
    public class IndexModel : PageModel
    {
        private readonly PL_Checker.Data.Context.PharmaDbContext _context;

        public IndexModel(PL_Checker.Data.Context.PharmaDbContext context)
        {
            _context = context;
        }

        public IList<Medicine> Medicine { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Medicines != null)
            {
                Medicine = await _context.Medicines.ToListAsync();
            }
        }
    }
}
