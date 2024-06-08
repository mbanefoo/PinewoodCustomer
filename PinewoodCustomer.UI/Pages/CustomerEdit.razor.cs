using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PinewoodCustomer.Shared.Models;
using PinewoodCustomer.UI.Interface;

namespace PinewoodCustomer.UI.Pages
{
    public partial class CustomerEdit : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        [Inject]
        public ICustomerDataService customerDataService { get; set; } = default!;
        [Parameter]
        public string id { get; set; } = string.Empty;
        public InputText LastNameInputText { get; set; } = default!;
        public string PageTitle { get; set; } = string.Empty;
        public Customer? customer { get; set; } = new Customer();
        //{
        //    Address = new Address(),
        //    Contact = new Contact(),
        //    JobCategoryId = 1,
        //    BirthDate = DateTime.Now,
        //    JoinedDate = DateTime.Now
        //};

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(id, out var _id);

            if (_id != 0) //new customer is being created
            {

                customer = await customerDataService.GetCustomerDetails(int.Parse(id));
                PageTitle = $"Details for {customer.firstName} {customer.lastName}";
            }
            else
            {
                PageTitle = "Add New Customer Details";
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (customer.id == 0) //new
            {
                var addedCustomer = await customerDataService.AddCustomer(customer);

                if (addedCustomer != null)
                {
                    StatusClass = "alert-success";
                    Message = "New customer added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new customer. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await customerDataService.UpdateCustomer(customer);
                StatusClass = "alert-success";
                Message = "Customer updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteCustomer()
        {
            await customerDataService.DeleteCustomer(customer.id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/customer");
        }
    }
}
