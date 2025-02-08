using CustomerAPI_LM.Interfaces;
using CustomerAPI_LM.Models;
using CustomerAPI_LM.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

using Moq;

namespace CustomerAPITests
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _customerController;
        private readonly ICustomerService _customerService;

        public CustomerControllerTests()
        {
            _customerService = new CustomerService();
            _customerController = new CustomerController(_customerService);
        }

        [Fact]
        public void GetCustomer_ValidId_ReturnsOk()
        {
            //Arrange
            var result = _customerController.GetCustomerById(1) as OkObjectResult;

            //Act
            Assert.NotNull(result);

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetCustomer_InvalidId_ReturnsNotFound()
        {
            var result = _customerController.GetCustomerById(99) as NotFoundResult;
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public void PatchCustomer_ValidId_ReturnsNoContent()
        {
            
            // Arrange
            var mockService = new Mock<ICustomerService>();
            var controller = new CustomerController(mockService.Object);

            JsonPatchDocument<Customer> patchDoc = new JsonPatchDocument<Customer>();
            patchDoc.Replace(c => c.FirstName, "ABC");
            patchDoc.Add(c => c.LastName, "DEF");

            var existingCustomer = new Customer { Id = 1, FirstName = "Jason", LastName="Smith" };
            //mockService.Setup(s => s.GetCustomerById(1)).Returns(existingCustomer);

            patchDoc.ApplyTo(existingCustomer);

            //mockService.Setup(s => s.UpdateCustomerById(1, existingCustomer));

            // Act
            var result = controller.UpdateCustomerById(1, existingCustomer);

            // Assert
            Assert.IsType<NoContentResult>(result);
            
        }

    }
}

