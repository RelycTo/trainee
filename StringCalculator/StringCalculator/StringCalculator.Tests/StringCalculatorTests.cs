namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void Add_EmptyString_ReturnZero()
    {
        var calculator = CreateCalculator();

        var actual = calculator.Add(string.Empty);

        Assert.Equal(0, actual);
    }

    [Fact]
    public void Add_OneNumber_ReturnNumber()
    {
        var calculator = CreateCalculator();

        var actual = calculator.Add("20");

        Assert.Equal(20, actual);
    }

    [Fact]
    public void Add_NumberWithLineBreak_ThrowFormatException()
    {
        var calculator = CreateCalculator();

        Assert.Throws<FormatException>(() => calculator.Add("11,\n"));
    }

    [Fact]
    public void Add_TwoCommaSeparatedNumbers_ReturnNumbersSum()
    {
        var calculator = CreateCalculator();

        var actual = calculator.Add("2,3");

        Assert.Equal(5, actual);
    }

    [Theory]
    [InlineData("2\n3\n4", 9)]
    [InlineData("11,21\n35", 67)]
    [InlineData("11\n23,21\n35", 90)]
    public void Add_MixDelimitersSeparatedNumbers_ReturnNumbersSum(string input, int expected)
    {
        var calculator = CreateCalculator();

        var actual = calculator.Add(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Add_CustomDelimiterSeparatedNumbers_ReturnNumbersSum()
    {
        var calculator = CreateCalculator();

        var actual = calculator.Add("//;\n1;2");

        Assert.Equal(3, actual);
    }

    [Fact]
    public void Add_NegativeNumbers_ThrowExceptionWithNotAllowedNumbers()
    {
        var calculator = CreateCalculator();

        var exception = Assert.Throws<ArgumentException>(() => calculator.Add("-1, -2, -4"));
        Assert.Contains("-1, -2, -4", exception.Message);
    }

    [Theory]
    [InlineData("1,1001,3", 4)]
    [InlineData("1010,1200", 0)]
    public void Add_GreaterThan1000Numbers_ReturnSumWithoutThem(string input, int expected)
    {
        var calculator = CreateCalculator();

        var actual = calculator.Add(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Add_CustomDelimiterGreaterThenOneSymbolWithoutBrackets_ThrowException()
    {
        var calculator = CreateCalculator();

        Assert.Throws<ArgumentException>(() => calculator.Add("//$%^\n1$%^5"));
    }

    [Fact]
    public void Add_CustomMultipleSymbolDelimiterSeparatedNumbers_ReturnNumbersSum()
    {
        var calculator = CreateCalculator();

        var actual = calculator.Add("//[;;;]\n1;;;2");

        Assert.Equal(3, actual);
    }

    [Theory]
    [InlineData("//[;][|][%]\n1;2%5|3", 11)]
    [InlineData("//[||][#]\n1||2#1", 4)]
    public void Add_CustomMultipleSymbolMultipleDelimiterSeparated_ReturnNumbersSum(string input, int expected)
    {
        var calculator = CreateCalculator();

        var actual = calculator.Add(input);

        Assert.Equal(expected, actual);
    }

    private StringCalculator CreateCalculator() => new();
}