namespace StringCalculator
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
