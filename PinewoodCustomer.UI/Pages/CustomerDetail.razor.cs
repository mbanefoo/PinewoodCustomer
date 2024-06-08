using Microsoft.AspNetCore.Components;
using PinewoodCustomer.Shared.Models;
using PinewoodCustomer.UI.Interface;
using System.Net;

namespace PinewoodCustomer.UI.Pages
{
    public partial class CustomerDetail : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ICustomerDataService customerDataService { get; set; } = default!;

        [Parameter]
        public int id { get; set; }
        public Customer? customer { get; set; } = new Customer();

        protected override async Task OnInitializedAsync()
        {
            customer = await customerDataService.GetCustomerDetails(id);
        }
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/customer");
        }
    }
}
