using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_webAPI.Dto;
using Task_webAPI.Models;
using Task_webAPI.Repository;

namespace Task_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employee;

        public EmployeeController(IEmployeeRepository employee)
        {
            this.employee = employee;
        }
        [HttpGet]
        public IActionResult getall()
        {
            List<EmployeeWithDepartmentNameDto> employees = employee.getall();
            return Ok(employees);
        }
        [HttpGet("dto/{id}")]
        public IActionResult getbyidWithDeptName(int id)
        {
            EmployeeWithDepartmentNameDto employees = employee.getallWithDeptName(id);
            return Ok(employees);
        }
        [HttpGet]
        [Route("{id:int}", Name = "EmployeeRoute")]
        public IActionResult getbyid(int id)
        {
            Employee employees = employee.getbyid(id);
            return Ok(employees);
        }
        [HttpPost]
        public IActionResult PostEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                string url = Url.Link("EmployeeRoute", new { id = emp.ID });
                employee.insert(emp);
                return Created(url, emp);
            }

            return BadRequest(ModelState);

        }
        [HttpPut("{id}")]
        public IActionResult PutEmployee([FromRoute] int id, [FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                employee.update(id, emp);

                return StatusCode(StatusCodes.Status204NoContent);

            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult deleteEmployee([FromRoute] int id)
        {
            try
            {
                employee.delete(id);
                return StatusCode(StatusCodes.Status204NoContent);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
