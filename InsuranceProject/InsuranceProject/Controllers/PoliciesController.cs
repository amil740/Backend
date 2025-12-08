using InsuranceProject.Models;
using InsuranceProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies()
        {
            var policies = await _policyService.GetAllPoliciesAsync();
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            var policy = await _policyService.GetPolicyByIdAsync(id);
            if (policy == null)
                return NotFound();

            return Ok(policy);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPoliciesByCustomer(int customerId)
        {
            var policies = await _policyService.GetPoliciesByCustomerIdAsync(customerId);
            return Ok(policies);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Agent")]
        public async Task<ActionResult<Policy>> CreatePolicy(Policy policy)
        {
            try
            {
                var createdPolicy = await _policyService.CreatePolicyAsync(policy);
                return CreatedAtAction(nameof(GetPolicy), new { id = createdPolicy.Id }, createdPolicy);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Agent")]
        public async Task<ActionResult<Policy>> UpdatePolicy(int id, Policy policy)
        {
            var updatedPolicy = await _policyService.UpdatePolicyAsync(id, policy);
            if (updatedPolicy == null)
                return NotFound();

            return Ok(updatedPolicy);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var success = await _policyService.DeletePolicyAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}