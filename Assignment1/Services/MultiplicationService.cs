using CalculatorAssignment.Interfaces.Multiplication;

namespace CalculatorAssignment.Services
{
    public class MultiplicationService : IMultiplicationService
    {
        public double Multiplication(double firstInput, double secondInput)
        {
            return firstInput * secondInput;
        }
    }
}
