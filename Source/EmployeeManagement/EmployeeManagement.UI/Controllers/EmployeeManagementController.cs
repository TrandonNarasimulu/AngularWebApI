using EmployeeManagement.Application.EmployeeManagement.Commands.CreateEmployee;
using EmployeeManagement.Application.EmployeeManagement.Commands.RemoveEmployee;
using EmployeeManagement.Application.EmployeeManagement.Commands.UpdateEmployee;
using EmployeeManagement.Application.EmployeeManagement.Queries.GetAllEmployees;
using EmployeeManagement.Application.EmployeeManagement.Queries.GetEmployee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers
{
    public class EmployeeManagementController : ApiController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateEmployeeViewModel>> CreateEmployee(CreateEmployeeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{employeeNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeDetails>> GetEmployeeDetails(string employeeNumber)
        {
            return Ok(await Mediator.Send(new GetEmployeeQuery { EmployeeNumber = employeeNumber }));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetAllEmployees()
        {
            return Ok(await Mediator.Send(new GetAllEmployeesQuery { }));
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateEmployeeDetails(UpdateEmployeeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{employeeNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> DeleteEmployee(string employeeNumber)
        {
            return Ok(await Mediator.Send(new RemoveEmployeeCommand { EmployeeNumber = employeeNumber }));
        }
    }
}
