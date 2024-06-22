using Microsoft.AspNetCore.Mvc;
using WebApi_emprepositorycrud.Models;

namespace WebApi_emprepositorycrud.Service
{
    public interface IEmployeeservice
    {
        Task<ActionResult<Employee>?> GetEmployee(int Id);
        Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee();
        Task<ActionResult<Employee>> Add(Employee employee);
        Task<Employee> Update(int id, Employee employeeChanges);
        Task<Employee> Delete(int Id);

    }
}
