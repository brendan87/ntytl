using System;
using Microsoft.EntityFrameworkCore;

namespace NTytL.Data
{
    public static class Init
    {
        public static void DbInit(ApplicationDbContext context)
        {
            Console.WriteLine("Applying database migrations...");
            context.Database.Migrate();
            Console.WriteLine("Migrations applied.");
        }
    }
}
