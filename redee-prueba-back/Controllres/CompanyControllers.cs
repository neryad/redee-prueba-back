using Microsoft.AspNetCore.Mvc;

namespace redee_prueba_back.Controllres
{
    [ApiController]
    [Route("api/companies")]
     public class CompanyControllers : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello from CompanyControllers";
        }

    }
}
