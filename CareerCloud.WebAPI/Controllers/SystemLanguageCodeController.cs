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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemLanguageCodeController : ControllerBase
    {
        private readonly SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("languagecode/{id}")]
        public ActionResult GetSystemLanguageCode(string code)
        {
            SystemLanguageCodePoco poco = _logic.Get(code);
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
        [Route("languagecode")]
        public ActionResult GetAllSystemLanguageCode()
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
        [Route("languagecode")]
        public ActionResult PostSystemLanguageCode(
            [FromBody] SystemLanguageCodePoco[] SystemLanguageCodePocos)
        {
            _logic.Add(SystemLanguageCodePocos);
            return Ok();
        }

        [HttpPut]
        [Route("languagecode")]
        public ActionResult PutSystemLanguageCode(
            [FromBody] SystemLanguageCodePoco[] SystemLanguageCodePocos)
        {
            _logic.Update(SystemLanguageCodePocos);
            return Ok();
        }

        [HttpDelete]
        [Route("languagecode")]
        public ActionResult DeleteSystemLanguageCode(
            [FromBody] SystemLanguageCodePoco[] SystemLanguageCodePocos)
        {
            _logic.Delete(SystemLanguageCodePocos);
            return Ok();
        }

    }
}