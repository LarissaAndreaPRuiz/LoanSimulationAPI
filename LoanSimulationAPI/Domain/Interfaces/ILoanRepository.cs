using LoanSimulationAPI.Domain.Entities;

namespace LoanSimulationAPI.Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task<int> SavePropostaAsync(Proposta proposta);
        Task SavePaymentScheduleAsync(List<PaymentFlowSummary> payments);
    }
}
