using CalculatorAssignment.Interfaces.Subtraction;

namespace CalculatorAssignment.Services
{
    public class SubtractionService : ISubtractionService
    {
        public double Subtraction(double firstInput, double secondInput)
        {
            return firstInput - secondInput ;
        }
    }
}
