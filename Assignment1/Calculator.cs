using CalculatorAssignment.Interfaces.Addition;
using CalculatorAssignment.Interfaces.Division;
using CalculatorAssignment.Interfaces.Multiplication;
using CalculatorAssignment.Interfaces.Subtraction;
using static System.Net.Mime.MediaTypeNames;

namespace CalculatorAssignment
{
    public class Calculator
    {
        private readonly IAdditionService _additionService;
        private readonly ISubtractionService _subtractionService;
        private readonly IMultiplicationService _multiplicationService;
        private readonly IDivisionService _divisionService;
        private bool runCalculator = true;
        private double firstInput;
        private double secondInput;
        private double result;

        public Calculator(IAdditionService additionService, ISubtractionService subtractionService,
                        IMultiplicationService multiplicationService, IDivisionService divisionService)
        {
            _additionService = additionService;
            _subtractionService = subtractionService;
            _multiplicationService = multiplicationService;
            _divisionService = divisionService;
        }

        public void StartCalculator()
        {
            Console.WriteLine("--------------- Calculator --------------- ");
            Console.WriteLine("__________________________________________");

            while (runCalculator)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(" Enter First numeric number ");
                string readFirstInput = Console.ReadLine();

                while (!double.TryParse(readFirstInput, out firstInput))
                {
                    Console.Write(" Enter a valid number ");
                    readFirstInput = Console.ReadLine();
                }

                Console.WriteLine(" Choose a operator: {  + ,  -  ,  * ,  /  }");
                //Console.WriteLine("+ ,  -  ,  * ,  / ");

                string operation = Console.ReadLine();
                while (!(operation == "+" || operation == "-" || operation == "*" || operation == "/"))
                {
                    Console.WriteLine(" Enter a Valid Opeartion");
                    operation = Console.ReadLine();
                }

                Console.WriteLine(" Enter Second numeric number  ");
                string readSecondInput = Console.ReadLine();

                while (!double.TryParse(readSecondInput, out secondInput) || (operation == "/" && secondInput == 0))
                {
                    Console.Write(" Enter a valid number "); // check once
                    readSecondInput = Console.ReadLine();
                }

                Calculations(firstInput, secondInput, operation);

                Console.WriteLine(" Do you want to Continue ? ");
                Console.WriteLine(" If Yes press 'y' else press 'n' to exit.");

                string userChoice = Console.ReadLine();

                while (!((userChoice.ToLower() == "y") || (userChoice.ToLower() == "n")))
                {
                    Console.WriteLine(" press 'y' to continue or 'n' to exit ");
                    userChoice = Console.ReadLine();
                }

                if (userChoice.ToLower() == "n")
                {
                    runCalculator = false;
                }
            }
        }

        private void Calculations(double firstInput, double secondInput, string operation)
        {
            switch (operation)
            {
                case "+":
                    result = _additionService.Addition(firstInput, secondInput);
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine($" Addition of two numbers {firstInput} + {secondInput} = {result}");
                    Console.WriteLine("--------------------------------------------------");

                    break;

                case "-":
                    result = _subtractionService.Subtraction(firstInput, secondInput);
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine($" Subtraction of two numbers {firstInput} - {secondInput} = {result}");
                    Console.WriteLine("--------------------------------------------------");
                    break;

                case "*":
                    result = _multiplicationService.Multiplication(firstInput, secondInput);
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine($" Multiplication of two numbers {firstInput} * {secondInput} = {result}");
                    Console.WriteLine("--------------------------------------------------");
                    break;

                case "/":
                    result = _divisionService.Division(firstInput, secondInput);
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine($"Division of two numbers {firstInput} / {secondInput} = {result}");
                    Console.WriteLine("--------------------------------------------------");
                    break;
            }
        }
    }
}

