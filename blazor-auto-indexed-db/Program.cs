using blazor_auto_indexed_db.Client.Interfaces;
using blazor_auto_indexed_db.Client.Pages;
using blazor_auto_indexed_db.Client.Services;
using blazor_auto_indexed_db.Components;
using TG.Blazor.IndexedDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(blazor_auto_indexed_db.Client._Imports).Assembly);

app.Run();
