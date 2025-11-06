using InsuranceProject.Models;
using InsuranceProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimsController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Agent")]
        public async Task<ActionResult<IEnumerable<Claim>>> GetClaims()
        {
            var claims = await _claimService.GetAllClaimsAsync();
            return Ok(claims);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Claim>> GetClaim(int id)
        {
            var claim = await _claimService.GetClaimByIdAsync(id);
            if (claim == null)
                return NotFound();

            return Ok(claim);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Claim>>> GetClaimsByCustomer(int customerId)
        {
            var claims = await _claimService.GetClaimsByCustomerIdAsync(customerId);
            return Ok(claims);
        }

        [HttpPost]
        public async Task<ActionResult<Claim>> CreateClaim(Claim claim)
        {
            try
            {
                var createdClaim = await _claimService.CreateClaimAsync(claim);
                return CreatedAtAction(nameof(GetClaim), new { id = createdClaim.Id }, createdClaim);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Agent")]
        public async Task<ActionResult<Claim>> UpdateClaim(int id, Claim claim)
        {
            var updatedClaim = await _claimService.UpdateClaimAsync(id, claim);
            if (updatedClaim == null)
                return NotFound();

            return Ok(updatedClaim);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteClaim(int id)
        {
            var success = await _claimService.DeleteClaimAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}