using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Visma_TechnicalTest.Api.Controllers;
using Visma_TechnicalTest.Api.Resources;
using Visma_TechnicalTest.Core.Models;
using Visma_TechnicalTest.Core.Services;
using Xunit;

namespace Visma_TechnicalTest.Api.UnitTest.Given_EmployeesController
{
    public class When_GetAll
    {
        #region .: Private Variables :. 
        private readonly MockRepository _mockRepository;
        private readonly Mock<IEmployeeService> _mockEmployeeService;
        private readonly Mock<IMapper> _mockMapper;
        #endregion .: Private Variables :.

        #region .: Constructor :. 
        public When_GetAll()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockEmployeeService = _mockRepository.Create<IEmployeeService>();
            _mockMapper = _mockRepository.Create<IMapper>();
        }
        #endregion .: Constructor :.

        #region .: Test Methods :.
        [Trait("UnitTest", "GetAll")]
        [Fact]
        public void Then_ReturnEmployees()
        {
            var employeeResources = GetEmployeeResources();

            //ARRANGE
            _mockEmployeeService
                .Setup(x => x.GetAll())
                .Returns(GetEmployees());
            _mockMapper
                .Setup(x => x.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(It.IsAny<IEnumerable<Employee>>()))
                .Returns(employeeResources);

            //ACT
            var sut = CreateSUT();
            var actionResult = sut.GetAll();

            //ASSERT
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);
            Assert.Equal(employeeResources, (actionResult.Result as OkObjectResult).Value);
            _mockRepository.VerifyAll();
        }

        [Trait("UnitTest", "GetAll")]
        [Fact]
        public void If_ThereAreErrors_Then_ReturnInternalServerError()
        {
            //ARRANGE
            _mockEmployeeService.Setup(x => x.GetAll()).Throws(new Exception());

            //ACT
            var sut = CreateSUT();
            var actionResult = sut.GetAll();

            //ASSERT
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<ObjectResult>(actionResult.Result);
            Assert.Equal(500, (actionResult.Result as ObjectResult).StatusCode);
            _mockRepository.VerifyAll();
        }
        #endregion .: Test Methods :.

        #region .: Private Methods :.
        private EmployeesController CreateSUT()
        {
            return new EmployeesController(_mockEmployeeService.Object, _mockMapper.Object);
        }

        private IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    FirstName = "UnitTest1",
                    LastName = "Unit Test1",
                    SocialSecurityNumber = "12345689",
                    Phone = "666333222"
                },
                new Employee()
                {
                    Id = 2,
                    FirstName = "UnitTest2",
                    LastName = "Unit Test2",
                    SocialSecurityNumber = "987654321",
                    Phone = "666555444"
                }
            };
        }

        private IEnumerable<EmployeeResource> GetEmployeeResources()
        {
            return new List<EmployeeResource>()
            {
                new EmployeeResource()
                {
                    Id = 1,
                    FirstName = "UnitTest1",
                    LastName = "Unit Test1",
                    SocialSecurityNumber = "12345689",
                    Phone = "666333222"
                },
                new EmployeeResource()
                {
                    Id = 2,
                    FirstName = "UnitTest2",
                    LastName = "Unit Test2",
                    SocialSecurityNumber = "987654321",
                    Phone = "666555444"
                }
            };
        }
        #endregion
    }
}
