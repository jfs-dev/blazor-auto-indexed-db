using blazor_auto_indexed_db.Client.Interfaces;
using blazor_auto_indexed_db.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TG.Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddIndexedDB(dbStore =>
{
    dbStore.DbName = "blazor-auto-indexded-db";
    dbStore.Version = 1;

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "customers",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes =
        [
            new IndexSpec { Name = "name", KeyPath = "name" },
            new IndexSpec { Name = "email", KeyPath = "email", Unique = true },
        ]
    });
});

builder.Services.AddScoped<ICustomerService, CustomerService>();

await builder.Build().RunAsync();
