using AddressBook.BL;
using AddressBook.Domain;
using AddressBook.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AddressBook.Controllers
{
    [Route("api/Counties")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IBLCountry _countryService;
        public CountryController(IBLCountry countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountryAsync()
        {
            return Ok(JsonSerializer.Serialize(await _countryService.GetAllAsync()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountryByIdAsync(int id)
        {
            var country = await _countryService.GetBuIdAsync(id);
            if (country != null)
            {
                return Ok(JsonSerializer.Serialize(country));
            }
            return NotFound(JsonSerializer.Serialize(new MessageViewModel()
            {
                Message = "Country not found"
            }));
        }

        [HttpPost]
        public async Task<IActionResult> AddCountryAsync(ADBD01 country)
        {
            if (await _countryService.AddAsync(country))
            {
                return Created("", JsonSerializer.Serialize(new MessageViewModel()
                {
                    Message = "Country added successfully"
                }));
            }
            return BadRequest(JsonSerializer.Serialize(new MessageViewModel()
            {
                Message = "Country doesn't added successfully"
            }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry(ADBD01 country)
        {
            if (await _countryService.UpdateAsync(country))
            {
                return Ok(JsonSerializer.Serialize(new MessageViewModel()
                {
                    Message = "Country updated successfully"
                }));
            }
            return BadRequest(JsonSerializer.Serialize(new MessageViewModel()
            {
                Message = "Country doesn't updated successfully"
            }));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (await _countryService.DeleteAsync(id))
            {
                return Ok(JsonSerializer.Serialize(new MessageViewModel()
                {
                    Message = "Country deleted successfully"
                }));
            }
            return NotFound(JsonSerializer.Serialize(new MessageViewModel()
            {
                Message = "Country not found"
            }));
        }
    }
}
