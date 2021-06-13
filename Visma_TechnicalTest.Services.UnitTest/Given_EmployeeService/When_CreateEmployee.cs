using Moq;
using Visma_TechnicalTest.Core;
using Visma_TechnicalTest.Core.Models;
using Visma_TechnicalTest.Core.Services;
using Xunit;

namespace Visma_TechnicalTest.Services.UnitTest.Given_EmployeeService
{
    public class When_CreateEmployee
    {
        #region .: Private Variables :. 
        private readonly MockRepository _mockRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        #endregion .: Private Variables :.

        #region .: Constructor :. 
        public When_CreateEmployee()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockUnitOfWork = _mockRepository.Create<IUnitOfWork>();
        }
        #endregion .: Constructor :.

        #region .: Test Methods :.
        [Trait("UnitTest", "CreateEmployee")]
        [Fact]
        public void Then_InsertEmployee()
        {
            //ARRANGE
            _mockUnitOfWork.Setup(x => x.Employees.Add(It.IsAny<Employee>()));
            _mockUnitOfWork.Setup(x => x.SaveChanges()).Returns(1);

            //ACT
            var sut = CreateSUT();
            sut.CreateEmployee(GetEmployee());

            //ASSERT
            _mockRepository.VerifyAll();
        }
        #endregion

        #region .: Private Methods :.
        private IEmployeeService CreateSUT()
        {
            return new EmployeeService(_mockUnitOfWork.Object);
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
        #endregion
    }
}
