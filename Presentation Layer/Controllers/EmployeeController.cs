using EmployeeManagementProject.Application_Layer.Command.EmployeeCommands;
using EmployeeManagementProject.Application_Layer.Common;
using EmployeeManagementProject.Application_Layer.Query.EmployeeQueries;
using EmployeeManagementProject.Domain_Layer.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementProject.Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeeList = await _mediator.Send(new GetEmployeeListQuery());
            return employeeList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Employee ID must be a positive integer.");
            }

            Employee employee = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });

            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employee newEmployee = await _mediator.Send(new CreateEmployeeCommand(
                employee.Name,
                employee.Address,
                employee.Email,
                employee.Phone
                ));

            if (newEmployee == null)
            {
                return StatusCode(500, "Failed to create employee. An unexpected error occurred.");
            }

            return Ok(newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int updatedEmployee = await _mediator.Send(new UpdateEmployeeCommand(
               employee.Id,
               employee.Name,
               employee.Address,
               employee.Email,
               employee.Phone));

            if (updatedEmployee == 0)
            {
                return NotFound($"Employee with ID {employee.Id} not found for update.");
            }

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Employee ID must be a positive integer.");
            }

            int employeeDeletedCount = await _mediator.Send(new DeleteEmployeeCommand() { Id = id });

            if (employeeDeletedCount == 0)
            {
                return NotFound($"Employee with ID {id} not found for deletion.");
            }

            return Ok(id);
        }
    }
}
