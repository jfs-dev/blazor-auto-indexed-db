using blazor_auto_indexed_db.Client.Interfaces;
using blazor_auto_indexed_db.Client.Models;
using TG.Blazor.IndexedDB;

namespace blazor_auto_indexed_db.Client.Services;

public class CustomerService(IndexedDBManager dbManager) : ICustomerService
{
    public async Task CreateCustomerAsync(Customer customer) =>
        await dbManager.AddRecord(new StoreRecord<Customer> { Storename = "customers", Data = customer });

    public async Task UpdateCustomerAsync(Customer customer) =>
        await dbManager.UpdateRecord(new StoreRecord<Customer> { Storename = "customers", Data = customer });

    public async Task DeleteCustomerAsync(int id) =>
        await dbManager.DeleteRecord<int>("customers", id);

    public async Task<Customer?> GetCustomerByIdAsync(int id) =>
        await dbManager.GetRecordById<int, Customer>("customers", id);

    public async Task<List<Customer>> GetAllCustomersAsync() =>
        await dbManager.GetRecords<Customer>("customers");
}
