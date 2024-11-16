using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.infrastructure
{
    public class MyFinanceDbContext : DbContext 
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }

        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=DESKTOP-5MIGC83;Database=myfinance;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}