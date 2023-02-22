using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL_Checker.Interfaces;
using PL_Checker.Data.Context;
using PL_Checker.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL_Checker.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MedicineFilterController : ControllerBase
    {
        private IMedicineFilterService _medicineFilterService;
        private readonly PharmaDbContext _context;
        private readonly ILogger _logger;

        //** ADD SWAGGER MODULE TO FIND API PATHWAY **

        public MedicineFilterController(IMedicineFilterService medicineFilterService, PharmaDbContext context, ILogger<MedicineFilterController> logger)
        {
            _medicineFilterService = medicineFilterService;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("pl/{plNumber}")]
        public async Task<ActionResult<IList<Medicine>>> GetByPl(string plNumber)
        {
            /*IQueryable<Medicine> medicinesData = from medicine in _context.Medicines
                                                 where medicine.Name.ToUpper().Contains(pl_number.ToUpper())
                                                 select medicine;
            */

            IQueryable<Medicine> medicinesData = _medicineFilterService.GetByPl(plNumber);

            return await medicinesData.AsNoTracking().ToListAsync();
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("Id/{Id}")]
        public IActionResult GetById(long Id)
        {
            Medicine medicine = _medicineFilterService.GetById(Id);
            return Ok(medicine);
        }
    }

}