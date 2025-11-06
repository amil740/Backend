using InsuranceProject.Models;
using InsuranceProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        private readonly ICustomerService _customerService;

        public QuotesController(IQuoteService quoteService, ICustomerService customerService)
        {
            _quoteService = quoteService;
            _customerService = customerService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Agent")]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            var quotes = await _quoteService.GetAllQuotesAsync();
            return Ok(quotes);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            var quote = await _quoteService.GetQuoteByIdAsync(id);
            if (quote == null)
                return NotFound();

            return Ok(quote);
        }

        [HttpGet("customer/{customerId}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotesByCustomer(int customerId)
        {
            var quotes = await _quoteService.GetQuotesByCustomerIdAsync(customerId);
            return Ok(quotes);
        }

        [HttpPost]
        public async Task<ActionResult<Quote>> CreateQuote(Quote quote)
        {
            try
            {
                var createdQuote = await _quoteService.CreateQuoteAsync(quote);
                return CreatedAtAction(nameof(GetQuote), new { id = createdQuote.Id }, createdQuote);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("calculate")]
        public async Task<ActionResult<decimal>> CalculatePremium([FromBody] PremiumCalculationRequest request)
        {
            var customer = await _customerService.GetCustomerByIdAsync(request.CustomerId);
            if (customer == null)
                return NotFound("Customer not found");

            var premium = await _quoteService.CalculatePremiumAsync(request.PolicyType, request.CoverageAmount, customer);
            return Ok(premium);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Agent")]
        public async Task<ActionResult<Quote>> UpdateQuote(int id, Quote quote)
        {
            var updatedQuote = await _quoteService.UpdateQuoteAsync(id, quote);
            if (updatedQuote == null)
                return NotFound();

            return Ok(updatedQuote);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Agent")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            var success = await _quoteService.DeleteQuoteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }

    public class PremiumCalculationRequest
    {
        public int CustomerId { get; set; }
        public PolicyType PolicyType { get; set; }
        public decimal CoverageAmount { get; set; }
    }
}