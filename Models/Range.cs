namespace MotivWebApp.Models
{
    //I've decided to make my own range class to use in the Loan class to calculate the interest rate based on the User's salary
    public class Range<T> where T : IComparable
    {
        public Range(T minimum, T maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
        private T Minimum { get; set; }
        private T Maximum { get; set; }

        public bool IsInsideRange(T value)
        {
            return (Minimum.CompareTo(value) <= 0 && value.CompareTo(Maximum) <= 0);
        }
    }
}
