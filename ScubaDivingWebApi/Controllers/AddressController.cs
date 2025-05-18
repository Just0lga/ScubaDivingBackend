using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ScubaDivingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: api/address/all/{userId}
        [HttpGet("all/{userId}")]
        public async Task<ActionResult<IReadOnlyList<Address>>> GetAllAddresses(string userId)
        {
            var addresses = await _addressRepository.GetAllAddresses(userId);
            return Ok(addresses);
        }

        // GET: api/address/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<Address>> GetAddress(string userId)
        {
            var address = await _addressRepository.GetAddresses(userId);
            if (address == null) return NotFound();
            return Ok(address);
        }

        // POST: api/address
        [HttpPost]
        public async Task<ActionResult> CreateAddress([FromBody] Address newAddress)
        {
            if (newAddress == null) return BadRequest("Address data cannot be null.");

            await _addressRepository.CreateAddress(newAddress);
            return CreatedAtAction(nameof(GetAddress), new { userId = newAddress.UserId }, newAddress);
        }

        // PUT: api/address/{userId}
        [HttpPut("{userId}/{oldAddressId")]
        public async Task<ActionResult> UpdateAddress(string userId, int oldAddressId, [FromBody] Address newAddress)
        {
            if (newAddress == null) return BadRequest("Address data cannot be null.");

            var oldAddress = await _addressRepository.GetAddressesById(userId);
            if (oldAddress == null) return NotFound("Address not found");

            oldAddress.Title = newAddress.Title;
            oldAddress.FullAddress = newAddress.FullAddress;
            oldAddress.City = newAddress.City;
            oldAddress.State = newAddress.State;
            oldAddress.Zipcode = newAddress.Zipcode;
            oldAddress.Country = newAddress.Country;
            oldAddress.IsDefault = newAddress.IsDefault;

            await _addressRepository.UpdateAddress(oldAddress);
            return Ok();
        }

        // DELETE: api/address/{userId}
        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteAddress(string userId)
        {
            var address = await _addressRepository.GetAddresses(userId);
            if (address == null) return NotFound("Address not found");

            await _addressRepository.DeleteAddress(address);
            return NoContent();
        }
    }
}
 