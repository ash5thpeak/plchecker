using System;
using PL_Checker.Data.Context;
using PL_Checker.Interfaces;
using PL_Checker.Models;

namespace PL_Checker.Services.Search
{
	public class MedicineFilterService : IMedicineFilterService
	{
        private readonly PharmaDbContext _context;

        //private readonly 
        public MedicineFilterService(PharmaDbContext context)
		{
			_context = context;
		}

		public Medicine? GetById(long id)
		{
			return _context.Medicines.FirstOrDefault(x => x.Id == id);
		}

		public IQueryable<Medicine> GetByPl(string plNumber)
		{
            IQueryable<Medicine> medicinesData = from medicine in _context.Medicines
                                                 //where medicine.Name.ToUpper().Contains(plNumber.ToUpper())
												 where medicine.PL_Number.ToUpper().Contains(plNumber.ToUpper())
                                                 select medicine;
			return medicinesData;
        }
	}
}

