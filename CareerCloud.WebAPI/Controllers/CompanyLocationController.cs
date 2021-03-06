using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyLocationController : ControllerBase
    {
        private readonly CompanyLocationLogic _logic;
        public CompanyLocationController()
        {
            var repo = new EFGenericRepository<CompanyLocationPoco>();
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("location/{id}")]
        public ActionResult GetCompanyLocation(Guid id)
        {
            CompanyLocationPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpGet]
        [Route("location")]
        public ActionResult GetAllCompanyLocation()
        {
            var applicants = _logic.GetAll();
            if (applicants == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(applicants);
            }
        }

        [HttpPost]
        [Route("location")]
        public ActionResult PostCompanyLocation(
            [FromBody] CompanyLocationPoco[] CompanyLocationPocos)
        {
            _logic.Add(CompanyLocationPocos);
            return Ok();
        }

        [HttpPut]
        [Route("location")]
        public ActionResult PutCompanyLocation(
            [FromBody] CompanyLocationPoco[] CompanyLocationPocos)
        {
            _logic.Update(CompanyLocationPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("location")]
        public ActionResult DeleteCompanyLocation(
            [FromBody] CompanyLocationPoco[] CompanyLocationPocos)
        {
            _logic.Delete(CompanyLocationPocos);
            return Ok();
        }

    }
}