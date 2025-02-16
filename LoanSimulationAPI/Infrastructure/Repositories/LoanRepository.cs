using LoanSimulationAPI.Domain.Entities;
using LoanSimulationAPI.Domain.Interfaces;
using LoanSimulationAPI.Infrastructure.Data;

namespace LoanSimulationAPI.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanDbContext _context;

        public LoanRepository(LoanDbContext context)
        {
            _context = context;
        }

        public async Task<int> SavePropostaAsync(Proposta proposta)
        {
            _context.Propostas.Add(proposta);
            await _context.SaveChangesAsync();
            return proposta.Id;
        }

        public async Task SavePaymentScheduleAsync(List<PaymentFlowSummary> payments)
        {
            _context.PaymentFlowSummaries.AddRange(payments);
            await _context.SaveChangesAsync();
        }
    }
}
