namespace StringCalculator;

public class ConsoleWrapper
{
    public virtual string ReadLine()
    {
        return Console.ReadLine();
    }

    public virtual void WriteLine(string s)
    {
        Console.WriteLine(s);
    }
}
