using CalculatorAssignment.Interfaces.Division;

namespace CalculatorAssignment.Services
{
    public class DivisionService : IDivisionService
    {
        public double Division(double firstInput, double secondInput)
        {
            return firstInput / secondInput;
        }
    }
}
