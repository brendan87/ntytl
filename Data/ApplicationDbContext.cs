using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NTytL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var Configuration = Environment.GetEnvironmentVariables();
            options.UseMySql($"server={Configuration["DBHOST"] ?? "localhost"};userid=root;pwd={Configuration["DBPASSWORD"] ?? "mysecret"};port={Configuration["DBPORT"] ?? "3306"}");
        }
    }
}
