using Moq;
using System.Collections.Generic;
using Visma_TechnicalTest.Core;
using Visma_TechnicalTest.Core.Models;
using Visma_TechnicalTest.Core.Services;
using Xunit;

namespace Visma_TechnicalTest.Services.UnitTest.Given_EmployeeService
{
    public class When_GetAll
    {
        #region .: Private Variables :. 
        private readonly MockRepository _mockRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        #endregion .: Private Variables :.

        #region .: Constructor :. 
        public When_GetAll()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockUnitOfWork = _mockRepository.Create<IUnitOfWork>();
        }
        #endregion .: Constructor :.

        #region .: Test Methods :.
        [Trait("UnitTest", "GetAll")]
        [Fact]
        public void Then_ReturnEmployees()
        {
            var employees = GetEmployees();

            //ARRANGE
            _mockUnitOfWork.Setup(x => x.Employees.GetAll()).Returns(employees);

            //ACT
            var sut = CreateSUT();
            var result = sut.GetAll();

            //ASSERT
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(employees, result);
            _mockRepository.VerifyAll();
        }
        #endregion

        #region .: Private Methods :.
        private IEmployeeService CreateSUT()
        {
            return new EmployeeService(_mockUnitOfWork.Object);
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
        #endregion
    }
}
