using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Visma_TechnicalTest.Api.Resources;
using Visma_TechnicalTest.Api.Validators;
using Visma_TechnicalTest.Core.Models;
using Visma_TechnicalTest.Core.Services;

namespace Visma_TechnicalTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class EmployeesController : ControllerBase
    {
        #region Private Variables
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        #endregion

        /// <summary> Get all employees. </summary>
        /// <remarks> Get all employees. </remarks>
        /// <returns> A list of Employees. </returns>
        /// <response code="200">OK: Boxes obtained correctly.</response>
        /// <response code="500">Internal Server Error: An error has occurred trying to obtain the employees.</response>
        [HttpGet("")]
        public ActionResult<IEnumerable<EmployeeResource>> GetAll()
        {
            try
            {
                var employees = _employeeService.GetAll();
                var employeeResources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees);

                return Ok(employeeResources);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        /// <summary> Insert a Employee. </summary>
        /// <remarks> Insert a Employee. </remarks>
        /// <returns> OK: Employee inserted correctly. </returns>
        /// <param name="saveEmployeeResource"></param>
        /// <response code="200">OK: Employee inserted correctly.</response>
        /// <response code="500">Internal Server Error: An error has occurred trying to insert the Employee</response>
        [HttpPost("")]
        public ActionResult Post([FromBody] SaveEmployeeResource saveEmployeeResource)
        {
            var validator = new SaveEmployeeResourceValidator();
            var validationResult = validator.Validate(saveEmployeeResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            try
            {
                var employeeToCreate = _mapper.Map<SaveEmployeeResource, Employee>(saveEmployeeResource);
                _employeeService.CreateEmployee(employeeToCreate);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
