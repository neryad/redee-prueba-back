using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Octetus.ConsultasDgii.Core.Messages;
using Octetus.ConsultasDgii.Services;
using redee_prueba_back.Data;
using redee_prueba_back.Entities;

namespace redee_prueba_back.Controllres
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyControllers(ApplicationDbContext applicationDbContext, ServicioConsultasWebDgii servicioConsultasWebDgii) : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;
        private readonly ServicioConsultasWebDgii servicioConsultasWebDgii = servicioConsultasWebDgii;

        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await applicationDbContext.GetAllCompaniesAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            var company = await applicationDbContext.GetCompanyByIdAsync(id);
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
                return BadRequest("Id no coincide");
            }
            var rowAffected = await applicationDbContext.UpdateCompanyAsync(company);
            if (rowAffected == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(rowAffected);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var company = await applicationDbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            await applicationDbContext.DeleteCompanyAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Company company)
        {
            if (company == null)
            {
                return BadRequest("Company cannot be null");
            }
            await applicationDbContext.InsertCompanyAsync(company);

            return CreatedAtAction(nameof(Get), new { id = company.Id }, company);
        }

        [HttpGet]
        [Route("rnc/{rnc}")]
        public IActionResult getRnc(string rnc)
        {
            RespuestaConsultaRncContribuyentes response = servicioConsultasWebDgii.ConsultarRncContribuyentes(rnc);

            if (response == null)
            {
                return NotFound(new { success = false, message = "No se recibió respuesta del servicio DGII." });
            }

            if (!response.Success)
            {
                return NotFound(new { success = false, message = response.Message });
            }

           
            var company = new Company
            {
                Rnc = response.CedulaORnc,
                Name = response.NombreORazónSocial,
                CommercialName = string.IsNullOrWhiteSpace(response.NombreComercial) ? "N/A" : response.NombreComercial,
                Status = response.Estado,
                Category = response.Categoría,
                Payment = response.RegimenDePagos,
                Activity = response.ActividadEconomica,
                Branch = response.AdministracionLocal
            };

            return Ok(new { success = true, data = company });
        }
    }
}
