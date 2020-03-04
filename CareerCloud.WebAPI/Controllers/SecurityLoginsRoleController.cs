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
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class SecurityLoginsRoleController : ControllerBase
    {
        private readonly SecurityLoginsRoleLogic _logic;
        public SecurityLoginsRoleController()
        {
            var repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("education/{id}")]
        public ActionResult GetSecurityLoginsRole(Guid id)
        {
            SecurityLoginsRolePoco poco = _logic.Get(id);
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
        [Route("education")]
        public ActionResult GetAllSecurityLoginsRole()
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
        [Route("education")]
        public ActionResult PostSecurityLoginRole(
            [FromBody] SecurityLoginsRolePoco[] SecurityLoginsRolePocos)
        {
            _logic.Add(SecurityLoginsRolePocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public ActionResult PutSecurityLoginsRole(
            [FromBody] SecurityLoginsRolePoco[] SecurityLoginsRolePocos)
        {
            _logic.Update(SecurityLoginsRolePocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public ActionResult DeleteSecurityLoginRole(
            [FromBody] SecurityLoginsRolePoco[] SecurityLoginsRolePocos)
        {
            _logic.Delete(SecurityLoginsRolePocos);
            return Ok();
        }

    }
}