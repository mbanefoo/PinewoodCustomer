using Microsoft.AspNetCore.Components;
using PinewoodCustomer.Shared.Models;
using PinewoodCustomer.UI.Interface;

namespace PinewoodCustomer.UI.Pages
{
    public partial class CustomerOverview : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ICustomerDataService customerDataService { get; set; }
        public List<Customer> customerList { get; set; }

        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                customerList = (await customerDataService.GetAllCustomers()).ToList();
            }
            catch (Exception e)
            {
                Message = "Something went wrong.";
            }

        }

        protected void NavigateToAddView()
        {
            NavigationManager.NavigateTo("/customeredit");
        }
    }
}
