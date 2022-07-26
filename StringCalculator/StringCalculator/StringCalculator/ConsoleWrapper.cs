namespace StringCalculator
{
    public class ConsoleWrapper
    {
        public virtual ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public virtual void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
        public virtual void Write(string s)
        {
            Console.Write(s);
        }

        public virtual void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
