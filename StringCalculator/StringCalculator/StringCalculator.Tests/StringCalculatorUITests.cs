using Moq;

namespace StringCalculator.Tests
{
    public class StringCalculatorUITests
    {
        [Fact]
        public void Run_Empty_ReturnZero()
        {
            const ConsoleKey endSymbol = ConsoleKey.E;
            const ConsoleKey exitSymbol = ConsoleKey.Escape;
            var mockConsoleWrapper = new Mock<ConsoleWrapper>();
            mockConsoleWrapper
                .SetupSequence(w => w.ReadKey())
                .Returns(new ConsoleKeyInfo((char)endSymbol, endSymbol, false, false, false))
                .Returns(new ConsoleKeyInfo((char)exitSymbol, exitSymbol, false, false, false));
            var ui = new StringCalculatorUI(mockConsoleWrapper.Object);

            ui.Run();

            mockConsoleWrapper.Verify(w => w.ReadKey(), Times.Exactly(2));
			mockConsoleWrapper.Verify(w => w.Write("Sum: 0"), Times.Once);
		}

        [Fact]
        public void Run_SingleNumber_ReturnNumber()
        {
            const ConsoleKey endSymbol = ConsoleKey.E;
            const ConsoleKey exitSymbol = ConsoleKey.Escape;
            const ConsoleKey number = ConsoleKey.D8;
            var mockConsoleWrapper = new Mock<ConsoleWrapper>();
            mockConsoleWrapper
                .SetupSequence(w => w.ReadKey())
                .Returns(new ConsoleKeyInfo((char)number, number, false, false, false))
                .Returns(new ConsoleKeyInfo((char)endSymbol, endSymbol, false, false, false))
                .Returns(new ConsoleKeyInfo((char)exitSymbol, exitSymbol, false, false, false));
            var ui = new StringCalculatorUI(mockConsoleWrapper.Object);

            ui.Run();

            mockConsoleWrapper.Verify(w => w.ReadKey(), Times.Exactly(3));
            mockConsoleWrapper.Verify(w => w.Write("Sum: 8"), Times.Once);
        }

        [Fact]
        public void Run_CommaSeparatedNumbers_ReturnNumbersSum()
        {
            const ConsoleKey endSymbol = ConsoleKey.E;
            const ConsoleKey exitSymbol = ConsoleKey.Escape;
            const ConsoleKey number1 = ConsoleKey.D8;
            const ConsoleKey number2 = ConsoleKey.D4;
            const ConsoleKey number3 = ConsoleKey.D1;
            const ConsoleKey commaKey = (ConsoleKey)44;
            var mockConsoleWrapper = new Mock<ConsoleWrapper>();
            mockConsoleWrapper
                .SetupSequence(w => w.ReadKey())
                .Returns(new ConsoleKeyInfo((char)number1, number1, false, false, false))
                .Returns(new ConsoleKeyInfo((char)commaKey, commaKey, false, false, false))
                .Returns(new ConsoleKeyInfo((char)number2, number2, false, false, false))
                .Returns(new ConsoleKeyInfo((char)commaKey, commaKey, false, false, false))
                .Returns(new ConsoleKeyInfo((char)number3, number3, false, false, false))
                .Returns(new ConsoleKeyInfo((char)endSymbol, endSymbol, false, false, false))
                .Returns(new ConsoleKeyInfo((char)exitSymbol, exitSymbol, false, false, false));
            var ui = new StringCalculatorUI(mockConsoleWrapper.Object);

            ui.Run();

            mockConsoleWrapper.Verify(w => w.ReadKey(), Times.Exactly(7));
            mockConsoleWrapper.Verify(w => w.Write("Sum: 13"), Times.Once);
        }
    }
}
