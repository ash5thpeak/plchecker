using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PL_Checker.Class.DataHandling;
using PL_Checker.Class.Logging;
using PL_Checker.Data.Context;
using PL_Checker.Models;

namespace PL_Checker.Pages.Medicines
{
    public class IndexModel : PageModel
    {
        private readonly PL_Checker.Data.Context.PharmaDbContext _context;
        private readonly ILogger _logger;
        private readonly IConfiguration Configuration;

        public IndexModel(PL_Checker.Data.Context.PharmaDbContext context, ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            Configuration = configuration;
        }

        //public IList<Medicine> Medicines { get;set; } = default!;
        //[BindProperty(SupportsGet = true)]
        //public string? SearchString { get; set; }
        public SelectList? MedicineCat { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Cat { get; set; }

        public string NameSort { get; set; }
        public string PLSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Medicine> Medicines { get; set; }

        /* public async Task OnGetAsync()
        {
            _logger.LogInformation("Medicine entry created at {DT}", DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm"));

            var medicines = from c in _context.Medicines
                            select c;

            if (!string.IsNullOrEmpty(SearchString))
            {
                medicines = medicines.Where(x => x.Name.ToLower().Contains(SearchString.ToLower()));
            }

            Medicine = await medicines.ToListAsync();

        }*/

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            _logger.LogInformation(AppLoggingEvents.ListMedicines, "All medicines view created at {DT}", DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm"));

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PLSort = sortOrder == "pl" ? "pl_desc" : "pl";

            if (searchString != null)
                pageIndex = 1;
            else
                searchString = currentFilter;

            CurrentFilter = searchString;

            IQueryable<Medicine> medicinesData = from m in _context.Medicines
                                                 select m;

            //* If we wanted a bit more info joined to each row we can add 'Include'
            //IQueryable<Medicine> medicinesData = from m in _context.Medicines.Include(x => x.MedicineAttributions)
            //                                     select m;

            if (!String.IsNullOrEmpty(searchString))
                medicinesData = medicinesData.Where(m => m.Name.ToUpper().Contains(searchString.ToUpper()));

            switch (sortOrder)
            {
                case "name_desc":
                    medicinesData = medicinesData.OrderByDescending(m => m.Name);
                    break;
                case "pl":
                    medicinesData = medicinesData.OrderBy(m => m.PL_Number);
                    break;
                case "pl_desc":
                    medicinesData = medicinesData.OrderByDescending(m => m.PL_Number);
                    break;
                default:
                    medicinesData = medicinesData.OrderBy(m => m.Name);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 3);

            Medicines = await PaginatedList<Medicine>.CreateAsync(medicinesData.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
