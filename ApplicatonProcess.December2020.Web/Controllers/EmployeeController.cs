using ApplicatonProcess.December2020.Data.Services;
using ApplicatonProcess.December2020.Domain.Models;
using ApplicatonProcess.December2020.Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicatonProcess.December2020.Web.Controllers
{
    [Route("EmployeeApp")]
    public class EmployeeController : Controller
    {
        public readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            this.employeeService = _employeeService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string employeeId)
        {
            var result = employeeService.Get(Convert.ToInt32(employeeId));

            return Ok(result);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            if (employee.IsValid(out IEnumerable<string> errors))
            {
                var result = await employeeService.Create(employee);

                return CreatedAtAction("Create Employee", new { id = result.Id }, result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            if (employee.IsValid(out IEnumerable<string> errors))
            {
                var result = await employeeService.Update(employee);

                return Ok(result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpPost("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string employeeId)
        {
            var result = await employeeService.Delete(Convert.ToInt32(employeeId));

            return Ok(result);
        }
    }
}
