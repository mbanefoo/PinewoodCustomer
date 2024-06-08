using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PinewoodCustomer.UI.Interface;
using PinewoodCustomer.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

var PinewoodCustomerURI = new Uri("https://localhost:3001/");

void RegisterTypedClient<TClient, TImplementation>(Uri apiBaseUrl)
    where TClient : class where TImplementation : class, TClient
{
    builder.Services.AddHttpClient<TClient, TImplementation>(client =>
    {
        client.BaseAddress = apiBaseUrl;
    });
}

// HTTP services
RegisterTypedClient<ICustomerDataService, CustomerDataService>(PinewoodCustomerURI);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
