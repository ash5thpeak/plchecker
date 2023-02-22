using System;
using System.Collections.Generic;
using PL_Checker.Models;

namespace PL_Checker.Interfaces
{
    /// <summary>
    /// Provides us with a cleaner, simpler way of 'interfacing' with the controllers as opposed to going directly to them
    /// </summary>
    public interface IMedicineFilterService
	{
        IQueryable<Medicine> GetByPl(string plNumber);
        Medicine GetById(long id);
	}
}

