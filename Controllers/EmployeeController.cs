using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_emprepositorycrud.Models;
using WebApi_emprepositorycrud.Service;

namespace WebApi_emprepositorycrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeservice _repository;

        public EmployeeController(IEmployeeservice repository)
        {
            _repository = repository;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>?>> GetEmployees()
        {
            if (await _repository.GetAllEmployee() == null)
            {
                return NotFound();
            }

            return await _repository.GetAllEmployee();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _repository.GetEmployee(id);
            return employee == null ? NotFound() : employee;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
           
            await _repository.Delete(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _repository.Add(employee);
            return CreatedAtAction("GetEmployees", new { id = employee.Id }, employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            try
            {
                await _repository.Update(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.GetEmployee(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


    }
}
