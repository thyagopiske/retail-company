using Microsoft.AspNetCore.Mvc;
using RetailCompany.DTOs;
using RetailCompany.Entities;
using RetailCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }


        [HttpPost]
        public async Task AddEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
        }

        [HttpPut]
        public async Task UpdateEmployee([FromBody] EmployeeDto employeeDto)
        {
            var updatedEmployee = await _employeeRepository.GetEmployeeByIdAsync(employeeDto.Id);
            updatedEmployee.FirstName = employeeDto.FirstName;
            updatedEmployee.LastName = employeeDto.LastName;

            await _employeeRepository.UpdateEmployeeAsync(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }

        // TEMP - TEST QUERY
        [Route("get-all")]
        [HttpGet]
        public ActionResult<IList<Employee>> TestQuery()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

    }
}
