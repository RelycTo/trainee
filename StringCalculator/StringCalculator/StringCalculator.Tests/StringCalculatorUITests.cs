using Moq;

namespace StringCalculator.Tests;

public class StringCalculatorUITests
{
    [Fact]
    public void Run_Empty_Exit()
    {
        var mockConsoleWrapper = new Mock<ConsoleWrapper>();
        mockConsoleWrapper
            .Setup(w => w.ReadLine())
            .Returns(string.Empty);
        var ui = new StringCalculatorUI(mockConsoleWrapper.Object);

        ui.Run();

        mockConsoleWrapper.Verify(w => w.ReadLine(), Times.Once);
        mockConsoleWrapper.Verify(w => w.WriteLine("Sum: 0"), Times.Never);
    }

    [Fact]
    public void Run_WhiteSpace_ReturnZeroAndExit()
    {
        var mockConsoleWrapper = new Mock<ConsoleWrapper>();
        mockConsoleWrapper
            .SetupSequence(w => w.ReadLine())
            .Returns(" ")
            .Returns(string.Empty);
        var ui = new StringCalculatorUI(mockConsoleWrapper.Object);

        ui.Run();

        mockConsoleWrapper.Verify(w => w.ReadLine(), Times.Exactly(2));
        mockConsoleWrapper.Verify(w => w.WriteLine("Sum: 0"), Times.Once);
    }

    [Fact]
    public void Run_SingleNumber_ReturnNumberAndExit()
    {
        var mockConsoleWrapper = new Mock<ConsoleWrapper>();
        mockConsoleWrapper
            .SetupSequence(w => w.ReadLine())
            .Returns("8")
            .Returns(string.Empty);
        var ui = new StringCalculatorUI(mockConsoleWrapper.Object);

        ui.Run();

        mockConsoleWrapper.Verify(w => w.ReadLine(), Times.Exactly(2));
        mockConsoleWrapper.Verify(w => w.WriteLine("Sum: 8"), Times.Once);
    }

    [Fact]
    public void Run_CommaSeparatedNumbers_ReturnNumbersSumAndExit()
    {
        var mockConsoleWrapper = new Mock<ConsoleWrapper>();
        mockConsoleWrapper
            .SetupSequence(w => w.ReadLine())
            .Returns("5,8")
            .Returns(string.Empty);

        var ui = new StringCalculatorUI(mockConsoleWrapper.Object);

        ui.Run();

        mockConsoleWrapper.Verify(w => w.ReadLine(), Times.Exactly(2));
        mockConsoleWrapper.Verify(w => w.WriteLine("Sum: 13"), Times.Once);
    }
}