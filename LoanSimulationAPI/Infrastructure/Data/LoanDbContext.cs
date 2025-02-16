using LoanSimulationAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanSimulationAPI.Infrastructure.Data
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options) { }

        public DbSet<Proposta> Propostas { get; set; }
        public DbSet<PaymentFlowSummary> PaymentFlowSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposta>().ToTable("Proposta");
            modelBuilder.Entity<PaymentFlowSummary>().ToTable("PaymentFlowSummary");
        }
    }
}
