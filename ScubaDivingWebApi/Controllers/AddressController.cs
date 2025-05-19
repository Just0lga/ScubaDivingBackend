using AutoMapper;
using Core.Dtos;
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
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        // GET: api/address/all/{userId}
        [HttpGet("all/{userId}")]
        public async Task<ActionResult<IReadOnlyList<AddressReadDto>>> GetAllAddresses(string userId)
        {
            var addresses = await _addressRepository.GetAllAddresses(userId);
            var addressDtos = _mapper.Map<IReadOnlyList<AddressReadDto>>(addresses);
            return Ok(addressDtos);
        }

        // GET: api/address/{userId}/{addressId}
        [HttpGet("{userId}/{addressId}")]
        public async Task<ActionResult<AddressReadDto>> GetAddress(string userId, int addressId)
        {
            var address = await _addressRepository.GetAddress(userId, addressId);
            if (address == null) return NotFound();

            var addressDto = _mapper.Map<AddressReadDto>(address);
            return Ok(addressDto);
        }

        // POST: api/address
        [HttpPost]
        public async Task<ActionResult> CreateAddress([FromBody] AddressCreateDto addressCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var address = _mapper.Map<Address>(addressCreateDto);
            await _addressRepository.CreateAddress(address);

            var readDto = _mapper.Map<AddressReadDto>(address);
            return CreatedAtAction(nameof(GetAddress), new { userId = readDto.UserId, addressId = readDto.Id }, readDto);
        }

        // PUT: api/address/{userId}/{addressId}
        [HttpPut("{userId}/{addressId}")]
        public async Task<ActionResult> UpdateAddress(string userId, int addressId, [FromBody] AddressUpdateDto addressUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingAddress = await _addressRepository.GetAddress(userId, addressId);
            if (existingAddress == null) return NotFound();

            _mapper.Map(addressUpdateDto, existingAddress); // Update mevcut entity
            await _addressRepository.UpdateAddress(existingAddress);

            return Ok();
        }

        // DELETE: api/address/{userId}/{addressId}
        [HttpDelete("{userId}/{addressId}")]
        public async Task<ActionResult> DeleteAddress(string userId, int addressId)
        {
            var address = await _addressRepository.GetAddress(userId, addressId);
            if (address == null) return NotFound();

            await _addressRepository.DeleteAddress(address);
            return NoContent();
        }
    }
}
