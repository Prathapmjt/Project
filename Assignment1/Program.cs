using CalculatorAssignment;
using CalculatorAssignment.Interfaces.Addition;
using CalculatorAssignment.Interfaces.Division;
using CalculatorAssignment.Interfaces.Multiplication;
using CalculatorAssignment.Interfaces.Subtraction;
using CalculatorAssignment.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
     static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<IAdditionService, AdditionService>();
                services.AddTransient<IMultiplicationService, MultiplicationService>();
                services.AddTransient<ISubtractionService, SubtractionService>();
                services.AddTransient<IDivisionService, DivisionService>();
            })
            .Build();
        var createInstance = ActivatorUtilities.CreateInstance<Calculator>(host.Services);
        createInstance.StartCalculator();
    }
}