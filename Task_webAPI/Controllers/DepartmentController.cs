using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_webAPI.Dto;
using Task_webAPI.Models;
using Task_webAPI.Repository;

namespace Task_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository department;

        public DepartmentController(IDepartmentRepository department)
        {
            this.department = department;
        }
        [HttpGet]
        public IActionResult getall()
        {
            List<Department> departments = department.getall();
            return Ok(departments);
        }
        [HttpGet]
        [Route("{id:int}", Name = "departmentRoute")]
        public IActionResult getbyid(int id)
        {
            Departmentlist departments = department.departlist(id);
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult PostDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                string url = Url.Link("departmentRoute", new { id = dept.ID });
                department.insert(dept);
                return Created(url, dept);
            }

            return BadRequest(ModelState);

        }
        [HttpPut("{id}")]
        public IActionResult PutDepartment([FromRoute] int id, [FromBody] Department dept)
        {
            if (ModelState.IsValid)
            {
                department.update(id, dept);

                return StatusCode(StatusCodes.Status204NoContent);

            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult deleteDepartment([FromRoute] int id)
        {
            try
            {
                department.delete(id);
                return StatusCode(StatusCodes.Status204NoContent);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
