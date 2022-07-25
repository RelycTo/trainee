namespace StringCalculator
{
    public interface IConsoleWrapper
    {
        void WriteLine(string s);
        void WriteLine();
        ConsoleKeyInfo ReadKey();
    }
}
