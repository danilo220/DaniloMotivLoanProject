using Microsoft.AspNetCore.Components;
using MotivWebApp.Models;

namespace MotivWebApp.Components
{
    public partial class LoanDetailsComponent
    {
        [Parameter]
        public Guid UserId { get; set; }
        private User? User { get; set; }

        private string poundsSymbol = "£";
        private string percentageSymbol = "%";
        protected override void OnInitialized()
        {
            User = ILoanService.LoadUsersById(UserId);
        }
        private string FormatToTwoDecimalPlaces(decimal? amount)
        {
            return String.Format("{0:0.00}", amount);
        }
    }
}
