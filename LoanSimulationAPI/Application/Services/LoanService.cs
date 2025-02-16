using LoanSimulationAPI.Domain.Entities;
using LoanSimulationAPI.Domain.Interfaces;

namespace LoanSimulationAPI.Application.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _repository;

        public LoanService(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<(decimal, decimal, decimal, List<PaymentFlowSummary>)> SimulateLoanAsync(Proposta proposta)
        {
            decimal monthlyInterestRate = proposta.AnnualInterestRate / 12;
            decimal monthlyPayment = (proposta.LoanAmount * monthlyInterestRate) /
                                     (1 - (decimal)Math.Pow(1 + (double)monthlyInterestRate, -proposta.NumberOfMonths));

            decimal totalPayment = monthlyPayment * proposta.NumberOfMonths;
            decimal totalInterest = totalPayment - proposta.LoanAmount;

            List<PaymentFlowSummary> schedule = new();
            decimal balance = proposta.LoanAmount;

            for (int month = 1; month <= proposta.NumberOfMonths; month++)
            {
                decimal interest = balance * monthlyInterestRate;
                decimal principal = monthlyPayment - interest;
                balance -= principal;

                schedule.Add(new PaymentFlowSummary
                {
                    PropostaId = proposta.Id,
                    Month = month,
                    Principal = principal,
                    Interest = interest,
                    Balance = balance
                });
            }

            proposta.Id = await _repository.SavePropostaAsync(proposta);
            await _repository.SavePaymentScheduleAsync(schedule);

            return (monthlyPayment, totalInterest, totalPayment, schedule);
        }
    }
}
