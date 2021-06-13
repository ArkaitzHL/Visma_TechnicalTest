using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Visma_TechnicalTest.Api.Controllers;
using Visma_TechnicalTest.Api.Resources;
using Visma_TechnicalTest.Core.Models;
using Visma_TechnicalTest.Core.Services;
using Xunit;

namespace Visma_TechnicalTest.Api.UnitTest.Given_EmployeesController
{
    public class When_Post
    {
        #region .: Private Variables :. 
        private readonly MockRepository _mockRepository;
        private readonly Mock<IEmployeeService> _mockEmployeeService;
        private readonly Mock<IMapper> _mockMapper;
        #endregion .: Private Variables :.

        #region .: Constructor :. 
        public When_Post()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockEmployeeService = _mockRepository.Create<IEmployeeService>();
            _mockMapper = _mockRepository.Create<IMapper>();
        }
        #endregion .: Constructor :.

        #region .: Test Methods :.
        [Trait("UnitTest", "Post")]
        [Fact]
        public void Then_OkResult()
        {
            //ARRANGE
            _mockMapper
                .Setup(x => x.Map<SaveEmployeeResource, Employee>(It.IsAny<SaveEmployeeResource>()))
                .Returns(GetEmployee());
            _mockEmployeeService.Setup(x => x.CreateEmployee(It.IsAny<Employee>()));

            //ACT
            var sut = CreateSUT();
            var actionResult = sut.Post(GetSaveEmployeeResource());

            //ASSERT
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<OkResult>(actionResult);
            _mockRepository.VerifyAll();
        }

        [Trait("UnitTest", "Post")]
        [Fact]
        public void If_EmployeeDataIsInvalid_Then_ReturnBadRequest()
        {
            //ACT
            var sut = CreateSUT();
            var actionResult = sut.Post(GetInvalidSaveEmployeeResource());

            //ASSERT
            var badRequestResult = actionResult as BadRequestObjectResult;
            var a = badRequestResult.Value;
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult);
            _mockRepository.VerifyAll();
        }

        [Trait("UnitTest", "Post")]
        [Fact]
        public void If_ThereAreErrors_Then_ReturnInternalServerError()
        {
            //ARRANGE
            _mockMapper
                .Setup(x => x.Map<SaveEmployeeResource, Employee>(It.IsAny<SaveEmployeeResource>()))
                .Throws(new Exception());

            //ACT
            var sut = CreateSUT();
            var actionResult = sut.Post(GetSaveEmployeeResource());

            //ASSERT
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<ObjectResult>(actionResult);
            Assert.Equal(500, (actionResult as ObjectResult).StatusCode);
            _mockRepository.VerifyAll();
        }
        #endregion .: Test Methods :.

        #region .: Private Methods :.
        private EmployeesController CreateSUT()
        {
            return new EmployeesController(_mockEmployeeService.Object, _mockMapper.Object);
        }

        private Employee GetEmployee()
        {
            return new Employee()
            {
                FirstName = "UnitTest1",
                LastName = "Unit Test1",
                SocialSecurityNumber = "12345689",
                Phone = "666333222"
            };
        }

        private SaveEmployeeResource GetInvalidSaveEmployeeResource()
        {
            return new SaveEmployeeResource()
            {
                FirstName = "",
                LastName = "Unit Test1",
                SocialSecurityNumber = "12345689",
                Phone = "666333222"
            };
        }

        private SaveEmployeeResource GetSaveEmployeeResource()
        {
            return new SaveEmployeeResource()
            {
                FirstName = "UnitTest1",
                LastName = "Unit Test1",
                SocialSecurityNumber = "12345689",
                Phone = "666333222"
            };
        }
        #endregion
    }
}
