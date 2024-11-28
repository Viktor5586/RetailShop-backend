using CustomersApi.Models;
using CustomersApi.Repositories;
using CustomersApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTests
{
  [TestClass]
  public class CustomerServiceTests
  {
    private readonly Mock<ICustomerRepository> _customerRepositoryMock;
    private readonly CustomerService _customerService;

    public CustomerServiceTests()
    {
      _customerRepositoryMock = new Mock<ICustomerRepository>();
      _customerService = new CustomerService(_customerRepositoryMock.Object);
    }

    [TestMethod]
    public async Task AddCustomerAsync_ShouldSetCreatedAtAndUpdatedAt_AndCallRepository()
    {
      var customer = new Customer { FirstName = "John", LastName = "Doe" };
      await _customerService.AddCustomerAsync(customer);
      Assert.IsTrue(customer.CreatedAt <= DateTime.Now);
      Assert.IsTrue(customer.UpdatedAt <= DateTime.Now);
      _customerRepositoryMock.Verify(repo => repo.AddCustomerAsync(It.Is<Customer>(c => c == customer)), Times.Once);
    }

    [TestMethod]
    public async Task DeleteCustomerAsync_ShouldCallRepository_WhenCustomerExists()
    {
      var customerId = 1L;
      var customer = new Customer { CustomerId = customerId };
      _customerRepositoryMock.Setup(repo => repo.GetCustomerByIdAsync(customerId)).ReturnsAsync(customer);
      await _customerService.DeleteCustomerAsync(customerId);
      _customerRepositoryMock.Verify(repo => repo.DeleteCustomerAsync(It.Is<Customer>(c => c == customer)), Times.Once);
    }

    [TestMethod]
    public async Task DeleteCustomerAsync_ShouldNotCallRepository_WhenCustomerDoesNotExist()
    {
      var customerId = 1L;
      _customerRepositoryMock.Setup(repo => repo.GetCustomerByIdAsync(customerId)).ReturnsAsync((Customer)null);
      await _customerService.DeleteCustomerAsync(customerId);
      _customerRepositoryMock.Verify(repo => repo.DeleteCustomerAsync(It.IsAny<Customer>()), Times.Never);
    }

    [TestMethod]
    public async Task GetAllCustomersAsync_ShouldReturnAllCustomers()
    {
      var customers = new List<Customer>
        {
            new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe" },
            new Customer { CustomerId = 2, FirstName = "Jane", LastName = "Smith" }
        };
      _customerRepositoryMock.Setup(repo => repo.GetAllCustomersAsync()).ReturnsAsync(customers);
      var result = await _customerService.GetAllCustomersAsync();
      Assert.AreEqual(customers, result);
    }

    [TestMethod]
    public async Task GetCustomerByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
    {
      var customerId = 1L;
      var customer = new Customer { CustomerId = customerId, FirstName = "John", LastName = "Doe" };
      _customerRepositoryMock.Setup(repo => repo.GetCustomerByIdAsync(customerId)).ReturnsAsync(customer);
      var result = await _customerService.GetCustomerByIdAsync(customerId);
      Assert.AreEqual(customer, result);
    }

    [TestMethod]
    public async Task GetCustomerByIdAsync_ShouldReturnNull_WhenCustomerDoesNotExist()
    {
      var customerId = 1L;
      _customerRepositoryMock.Setup(repo => repo.GetCustomerByIdAsync(customerId)).ReturnsAsync((Customer)null);
      var result = await _customerService.GetCustomerByIdAsync(customerId);
      Assert.IsNull(result);
    }

    [TestMethod]
    public async Task UpdateCustomerAsync_ShouldSetUpdatedAt_AndCallRepository()
    {
      var customer = new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe" };
      await _customerService.UpdateCustomerAsync(customer);
      Assert.IsTrue(customer.UpdatedAt <= DateTime.Now);
      Assert.IsTrue(customer.UpdatedAt >= DateTime.Now.AddMinutes(-1));
      _customerRepositoryMock.Verify(repo => repo.UpdateCustomerAsync(It.Is<Customer>(c => c == customer)), Times.Once);
    }
  }
}
