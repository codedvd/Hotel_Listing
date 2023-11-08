using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Listing.api.Data;
using Hotel_Listing.api.Models;
using AutoMapper;
using Hotel_Listing.api.Dtos.Country;
using Hotel_Listing.api.Contracts;

namespace Hotel_Listing.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepo _contry;
        private readonly IMapper _mapper;
        public CountriesController(IMapper mapper, ICountryRepo contry)
        {
            _mapper = mapper;
            _contry = contry;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _contry.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _contry.GetDetails(id);
            if (country == null) 
            {
                return NotFound();
            }
              
            var response = _mapper.Map<CountryDto>(country);

            return response;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountry)
        {
            if (id != updateCountry.Id)
            {
                return BadRequest("Invalid Record ID");
            }

            var country = await _contry.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCountry, country);

            try
            {
                await _contry.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);

            await _contry.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _contry.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _contry.DeleteAsync(id);

            return NoContent();
        }

        private Task<bool> CountryExists(int id)
        {
            return _contry.Exist(id);
        }
    }
}
