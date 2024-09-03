using blazor_auto_indexed_db.Client.Models;

namespace blazor_auto_indexed_db.Client.Interfaces;

public interface ICustomerService
{
    Task CreateCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int id);
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task<List<Customer>> GetAllCustomersAsync();
}
