﻿using PL_Checker.Data.Context;
using PL_Checker.Models;

namespace PL_Checker.Data.SeedData
{
    public static class SeedData_Pharma
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            // Wrap the initialisation, user population and commit neatly
            using (var context = serviceProvider.GetRequiredService<PharmaDbContext>())
            {
                if (context == null || context.Medicines == null)
                    throw new ArgumentNullException("Null DbContext: Database of medicines does not exist");

                // Check to see if medicines exist in the current context
                if (context.Medicines.Any())
                    return;

                // Seed the database with new medicines
                context.Medicines.AddRange(
                    new Medicine
                    {
                        //Id = 1,
                        Name = "Anadin Extra",
                        PL_Number = "PL12345/6789",
                        ImageUrl = ""
                    },
                    new Medicine
                    {
                        //Id = 2,
                        Name = "Anadin Extra",
                        PL_Number = "PL12345/6789",
                        ImageUrl = ""
                    },
                    new Medicine
                    {
                        //Id = 3,
                        Name = "Anadin Extra",
                        PL_Number = "PL12345/6789",
                        ImageUrl = ""
                    },
                    new Medicine
                    {
                        //Id = 4,
                        Name = "Anadin Extra",
                        PL_Number = "PL12345/6789",
                        ImageUrl = ""
                    },
                    new Medicine
                    {
                        //Id = 5,
                        Name = "Anadin Extra",
                        PL_Number = "PL12345/6789",
                        ImageUrl = ""
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

