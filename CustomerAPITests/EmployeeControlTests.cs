using CustomerAPI_LM.Controllers;
using CustomerAPI_LM.Delegates;
using CustomerAPI_LM.Models;
using CustomerAPI_LM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EmployeeAPITests
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController _employeeController;
        private readonly Mock<GetEmployeeByIdDelegate> _mockGetEmployeeById;
        private readonly Mock<UpdateEmployeeDelegate> _mockUpdateEmployee;

        public EmployeeControllerTests()
        {
            _mockGetEmployeeById = new Mock<GetEmployeeByIdDelegate>();
            _mockUpdateEmployee = new Mock<UpdateEmployeeDelegate>();
            var employeeService = new EmployeeService(_mockGetEmployeeById.Object, _mockUpdateEmployee.Object);
            _employeeController = new EmployeeController(employeeService);
        }

        [Fact]
        public void GetEmployee_ValidId_ReturnsOk_EmployeeExists()
        {
            //Arrange
            var employee = new Employee { Id = 1, FirstName = "Mack", LastName = "Duck", Address = "Waterland", Salary = 45555 };
            _mockGetEmployeeById.Setup(m => m(1)).Returns(employee);

            //Act
            var result = _employeeController.GetEmployeeById(1);

            //var returnedEmployee = result.Value as Employee;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEmployee = Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(employee.FirstName, returnedEmployee.FirstName);

            //Assert.NotNull()
        }

        [Fact]
        public void GetEmployee_InvalidId_ReturnsNotFound_EmployeeDoesNotExist()
        {
            //Arrange
            _mockGetEmployeeById.Setup(d => d(It.IsAny<int>())).Returns((Employee)null);

            //Act
            var result = _employeeController.GetEmployeeById(101);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);

        }
        [Fact]
        public void PatchEmployee_InvalidId_ReturnsNotFound_EmployeeDoesNotExists()
        {
            // Arrange
            _mockGetEmployeeById.Setup(m => m(It.IsAny<int>())).Returns((Employee)null);

            // Act
            var result = _employeeController.UpdateEmployeeById(1, new Employee());

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);

        }

        [Fact]
        public void PatchEmployee_ValidId_ReturnsNoContent_EmployeeExists()
        {
            //Arrange
            var employee = new Employee { Id = 1, FirstName = "Green", LastName = "Duck", Address = "Oceanstreet", Salary = 99999 };
            _mockGetEmployeeById.Setup(d => d(1)).Returns(employee);

            //Act
            var result = _employeeController.UpdateEmployeeById(1, new Employee { FirstName = "Greem", LastName = "Duck" });

            //Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}





