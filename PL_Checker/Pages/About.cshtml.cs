using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PL_Checker.Data.Context;
using PL_Checker.Models;

namespace PL_Checker.Pages
{
	public class AboutModel : PageModel
    {
        private readonly PharmaDbContext _context;
        private readonly ILogger _logger;

        public AboutModel(PharmaDbContext context, ILogger<AboutModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<MedicineGroup> MedicineGroups { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<MedicineGroup> data = from medicine in _context.Medicines
                                             group medicine by medicine.Name into nameGrouping
                                             select new MedicineGroup()
                                             {
                                                 NameGroup = nameGrouping.Key,
                                                 MedicineCount = nameGrouping.Count()
                                             };

            MedicineGroups = await data.AsNoTracking().ToListAsync();       // Don't need to track as not updating
        }
    }
}
