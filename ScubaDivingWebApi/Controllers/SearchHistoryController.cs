using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SearchHistoryController : ControllerBase
    {
        private readonly ISearchHistoryRepository _repository;
        private readonly IMapper _mapper;

        public SearchHistoryController(ISearchHistoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/searchhistory
        [HttpGet]
        public async Task<IActionResult> GetLastSearches()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var searches = await _repository.GetLastSearchesAsync(userId);
            return Ok(_mapper.Map<IEnumerable<SearchHistoryDto>>(searches));
        }

        // POST: api/searchhistory
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSearchHistoryDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var entity = _mapper.Map<SearchHistory>(dto);
            entity.UserId = userId;

            await _repository.AddAsync(entity);
            return Ok();
        }

        // DELETE: api/searchhistory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _repository.DeleteAsync(id, userId);
            return Ok();
        }
    }
}
