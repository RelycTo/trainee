using System.Text;
namespace StringCalculator;

public class StringCalculatorUI
{
    private readonly StringCalculator _calculator;
    private readonly ConsoleWrapper _consoleWrapper;

    public StringCalculatorUI(ConsoleWrapper consoleWrapper)
    {
        _calculator = new StringCalculator();
        _consoleWrapper = consoleWrapper;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                _consoleWrapper.WriteLine("Enter comma separated numbers (enter to exit):");
                var input = _consoleWrapper.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;

                _consoleWrapper.WriteLine("Sum: " + _calculator.Add(input));
            }
            catch (Exception e)
            {
                _consoleWrapper.WriteLine(e.Message);
            }
        }
    }
}