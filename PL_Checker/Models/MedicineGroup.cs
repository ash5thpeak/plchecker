using System;
using System.ComponentModel.DataAnnotations;

namespace PL_Checker.Models
{
	public class MedicineGroup
	{
		public string? NameGroup { get; set; }

		public int MedicineCount { get; set; }
	}
}

