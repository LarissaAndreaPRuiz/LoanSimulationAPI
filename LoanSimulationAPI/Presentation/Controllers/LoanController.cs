using LoanSimulationAPI.Application.Services;
using LoanSimulationAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LoanSimulationAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoanController : ControllerBase
    {
        private readonly LoanService _service;

        public LoanController(LoanService service)
        {
            _service = service;
        }

        [HttpPost("simulate")]
        public async Task<IActionResult> Simulate([FromBody] Proposta proposta)
        {
            var (monthlyPayment, totalInterest, totalPayment, schedule) = await _service.SimulateLoanAsync(proposta);
            return Ok(new { monthlyPayment, totalInterest, totalPayment, paymentSchedule = schedule });
        }
    }
}
