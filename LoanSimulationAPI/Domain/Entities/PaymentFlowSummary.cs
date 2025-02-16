namespace LoanSimulationAPI.Domain.Entities
{
    public class PaymentFlowSummary
    {
        public int Id { get; set; }
        public int PropostaId { get; set; }
        public int Month { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }
    }
}
