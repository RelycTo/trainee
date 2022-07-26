using System.Text;

namespace StringCalculator
{
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
            var input = new StringBuilder();
            Console.WriteLine("Enter comma or row separated numbers ('E' to complete input and esc to exit):");
            while (true)
            {
                try
                {
                    var current = _consoleWrapper.ReadKey();
                    if (current.Key == ConsoleKey.Escape) break;

                    if (current.Key == ConsoleKey.Enter)
                    {
                        input.Append('\n');
                        _consoleWrapper.WriteLine();
                    }

                    input.Append(current.KeyChar);

                    if (current.Key == ConsoleKey.E)
                    {
                        _consoleWrapper.WriteLine();
                        _consoleWrapper.Write("Sum: " + _calculator.Add(input.ToString()
                            .Replace("\r", string.Empty)
                            .TrimEnd('E')));
                        _consoleWrapper.WriteLine();
                        input.Clear();
                    }
                }
                catch (Exception e)
                {
                    input.Clear();
                    _consoleWrapper.WriteLine(e.Message);
                }
            }
        }
    }
}
