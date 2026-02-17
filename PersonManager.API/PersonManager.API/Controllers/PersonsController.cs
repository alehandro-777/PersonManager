using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManager.API.DTO;
using PersonManager.Data;


namespace PersonManager.API.Controllers
{
    /// <summary>
    /// Controller for managing persons.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonDbContext _context;
        private readonly IMapper _mapper;

        public PersonsController(PersonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Get list of persons. Optional filter by name.
        /// </summary>
        /// <param name="name">Optional name filter (search by first or last name)</param>
        /// <returns>List of persons matching the filter</returns>
        // GET: api/persons?name=Max + filter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonListDto>>> GetPersons([FromQuery] string? name)
        {
            try
            {
                var query = _context.Persons.AsQueryable();

                if (!string.IsNullOrWhiteSpace(name))
                    query = query.Where(p => p.Name.Contains(name) || p.Vorname.Contains(name));

                var persons = await query.ToListAsync();
                var result = _mapper.Map<List<PersonListDto>>(persons);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching persons: {ex.Message}");
            }
        }

        /// <summary>
        /// Get details of a single person by ID, including addresses and phone numbers.
        /// </summary>
        /// <param name="id">Person ID</param>
        /// <returns>Person details</returns>
        // GET: api/persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDetailDto>> GetPerson(int id)
        {
            try
            {
                var person = await _context.Persons
                    .Include(p => p.Anschriften)
                    .Include(p => p.Telefonnummern)
                    .FirstOrDefaultAsync(p => p.PersonId == id);

                if (person == null)
                    return NotFound($"Person with ID {id} not found.");

                var result = _mapper.Map<PersonDetailDto>(person);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the person: {ex.Message}");
            }
        }

        /// <summary>
        /// Update person's name and first name.
        /// </summary>
        /// <param name="id">Person ID</param>
        /// <param name="dto">Updated person data</param>
        /// <returns>NoContent on success</returns>
        // PUT: api/persons/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] PersonUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is null.");

            try
            {
                var person = await _context.Persons.FindAsync(id);
                if (person == null)
                    return NotFound($"Person with ID {id} not found.");

                _mapper.Map(dto, person);

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Database update error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
