using CustomerAPI_LM.Interfaces;
using CustomerAPI_LM.Models;
using CustomerAPI_LM.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

using Moq;
using CustomerAPI_LM.Delegates;

namespace CustomerAPITests
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _customerController;
        private readonly Mock<GetCustomerByIdDelegate> _mockGetCustomerById;
        private readonly Mock<UpdateCustomerDelegate> _mockUpdateCustomer;

        public CustomerControllerTests()
        {
            _mockGetCustomerById = new Mock<GetCustomerByIdDelegate>();
            _mockUpdateCustomer = new Mock<UpdateCustomerDelegate>();
            var customerService = new CustomerService(_mockGetCustomerById.Object, _mockUpdateCustomer.Object);
            _customerController = new CustomerController(customerService);
        }

        [Fact]
        public void GetCustomer_ValidId_ReturnsOk_CustomerExists()
        {
            //Arrange
            var customer = new Customer { Id = 1, FirstName = "Mack", LastName = "Duck", Address = "Waterland" };
            _mockGetCustomerById.Setup(m => m(1)).Returns(customer);

            //Act
            var result = _customerController.GetCustomerById(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCustomer = Assert.IsType<Customer>(okResult.Value);
            Assert.Equal(customer.FirstName, returnedCustomer.FirstName);

        }

        [Fact]
        public void GetCustomer_InvalidId_ReturnsNotFound_CustomerDoesNotExist()
        {
            //Arrange
            _mockGetCustomerById.Setup(d => d(It.IsAny<int>())).Returns((Customer)null);

            //Act
            var result = _customerController.GetCustomerById(101);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);

        }
        [Fact]
        public void PatchCustomer_InvalidId_ReturnsNotFound_CustomerDoesNotExists()
        {
            // Arrange
            _mockGetCustomerById.Setup(m=>m(It.IsAny<int>())).Returns((Customer)null);

            // Act
            var result = _customerController.UpdateCustomerById(1, new Customer());
            
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
                
        }

        [Fact]
        public void PatchCustomer_ValidId_ReturnsNoContent_CustomerExists()
        {
            //Arrange
            var customer = new Customer { Id = 1, FirstName = "Mack", LastName = "Duck", Address = "Waterland" };
            _mockGetCustomerById.Setup(d => d(1)).Returns(customer);

            //Act
            var result = _customerController.UpdateCustomerById(1, new Customer { FirstName = "Mack", LastName="Duck" });

            //Assert
            Assert.IsType<NoContentResult>(result);
        } 

    }
}

