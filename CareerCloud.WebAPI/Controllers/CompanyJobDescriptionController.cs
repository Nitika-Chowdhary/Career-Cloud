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
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private readonly CompanyJobDescriptionLogic _logic;
        public CompanyJobsDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("jobsdescription/{id}")]
        public ActionResult GetCompanyJobsDescription(Guid id)
        {
            CompanyJobDescriptionPoco poco = _logic.Get(id);
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
        [Route("jobsdescription")]
        public ActionResult GetAllCompanyJobDescription()
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
        [Route("jobsdescription")]
        public ActionResult PostCompanyJobsDescription(
            [FromBody] CompanyJobDescriptionPoco[] CompanyJobDescriptionPocos)
        {
            _logic.Add(CompanyJobDescriptionPocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobsdescription")]
        public ActionResult PutCompanyJobsDescription(
            [FromBody] CompanyJobDescriptionPoco[] CompanyJobDescriptionPocos)
        {
            _logic.Update(CompanyJobDescriptionPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobsdescription")]
        public ActionResult DeleteCompanyJobsDescription(
            [FromBody] CompanyJobDescriptionPoco[] CompanyJobDescriptionPocos)
        {
            _logic.Delete(CompanyJobDescriptionPocos);
            return Ok();
        }

    }
}