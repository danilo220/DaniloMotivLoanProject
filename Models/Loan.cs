using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.Models
{
    public class Loan
    {
        private const int MonthsPerYear = 12;
        private const int YearlyInterestRateToDivide = 1200;
        private static double interestRate = 20;
        //Decided to use decimal for some fields because it's good practice for financial data after a few google searches https://exceptionnotfound.net/decimal-vs-double-and-other-tips-about-number-types-in-net/#:~:text=Use%20double%20for%20non%2Dinteger,performant%20than%20short%20or%20long%20.
        public Guid Id { get; set; }
        public int MinimumSalaryRequired { get; } = 5000;
        public bool IsLoanAccepted { get; private set; }
        [Display(Name = "Loan amount")]
        [Required(ErrorMessage = "You must provide a loan amount")]
        public decimal LoanAmount { get; set; }
        [Required(ErrorMessage = "You must provide a deposit even if 0")]
        public decimal Deposit { get; set; } = 0;
        public double InterestRate { get; private set; } = interestRate;
        [Display(Name = "Number of years")]
        [Required(ErrorMessage = "You must provide how many years")]
        public int NumberOfYears { get; set; }
        public double NumberOfPayments
        {
            get { return NumberOfYears * MonthsPerYear; }
        }
        public decimal TotalAmountWithInterest
        {
            get { return MonthlyPayment * (decimal)NumberOfPayments; }
        }
        public decimal AmountChargedInInterest
        {
            get { return TotalAmountWithInterest - LoanAmount; }
        }
        public double MonthlyInterestRate
        {
            get { return InterestRate / YearlyInterestRateToDivide; }
        }
        public decimal MonthlyPayment
        {
            get { return Convert.ToDecimal(MonthlyInterestRate) * LoanAmount / Convert.ToDecimal(1 - Math.Pow(1 + MonthlyInterestRate, NumberOfPayments * -1)); }
        }
        public void CalculateInterestRate(decimal userYearlySalary)
        {
            List<Range<decimal>> salaryRanges = new List<Range<decimal>>()
            {
                new Range<decimal>(MinimumSalaryRequired, 10000),
                new Range<decimal>(10000, 20000),
                new Range<decimal>(20000, 30000),
                new Range<decimal>(30000, 40000),
            };
            foreach (Range<decimal> salaryRange in salaryRanges)
            {
                if (userYearlySalary > 40000)
                {
                    InterestRate = 4;
                    return;
                }
                if (salaryRange.IsInsideRange(userYearlySalary))
                {
                    InterestRate = interestRate;
                    return;
                }
                interestRate -= 5;
            }
        }

        public void CheckLoanAcceptance(decimal userYearlySalary)
        {
            IsLoanAccepted = userYearlySalary >= MinimumSalaryRequired;
        }
    }
}
