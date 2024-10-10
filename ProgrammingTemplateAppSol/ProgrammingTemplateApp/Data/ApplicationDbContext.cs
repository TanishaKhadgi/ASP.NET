using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingTemplateApp.Models;

namespace ProgrammingTemplateApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProgrammingTemplate> ProgrammingTemplates { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
