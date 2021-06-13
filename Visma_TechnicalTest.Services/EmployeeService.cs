using System.Collections.Generic;
using Visma_TechnicalTest.Core;
using Visma_TechnicalTest.Core.Models;
using Visma_TechnicalTest.Core.Services;

namespace Visma_TechnicalTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region Private Variables
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Contructor
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        public IEnumerable<Employee> GetAll()
        {
            return _unitOfWork.Employees.GetAll();
        }

        public void CreateEmployee(Employee employee)
        {
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.SaveChanges();
        }
        #endregion
    }
}