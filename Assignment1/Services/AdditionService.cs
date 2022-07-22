using CalculatorAssignment.Interfaces.Addition;

namespace CalculatorAssignment.Services
{
    public class AdditionService : Program , IAdditionService
    {
        public double Addition(double firstInput, double secondInput)
        {
            return firstInput + secondInput;
        }
    }
}
