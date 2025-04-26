using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using redee_prueba_back.Data;
using redee_prueba_back.Entities;

namespace redee_prueba_back.Controllres
{
    [ApiController]
    [Route("api/companies")]
     public class CompanyControllers : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CompanyControllers(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

      
        [HttpGet]
        public async Task<IEnumerable<Company>> Get ()
        {
            return await applicationDbContext.Companies.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            var company = await applicationDbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return company;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest("Id no coicinde");
            }
            applicationDbContext.Update(company);
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var company = await applicationDbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            applicationDbContext.Remove(company);
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Company company)
        {
            if (company == null)
            {
                return BadRequest("Company cannot be null");
            }
            applicationDbContext.Companies.Add(company);
            await applicationDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = company.Id }, company);

        }

    }
}
