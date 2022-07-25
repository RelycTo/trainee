namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyNumbersReturnZero()
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(string.Empty);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void OneNumberSumReturnNumber()
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add("20");

            Assert.Equal(20, actual);
        }

        [Theory]
        [InlineData("&")]
        [InlineData("v")]
        [InlineData("#")]
        [InlineData("%^&")]
        [InlineData("%,^&")]
        [InlineData("c,^&")]
        [InlineData("11,\n")]
        public void IncorrectFormatNumberSumThrowsException(string input)
        {
            var calculator = new StringCalculator();

            Assert.Throws<FormatException>(() => calculator.Add(input));
        }

        [Theory]
        [InlineData("2,3", 5)]
        [InlineData("135,219", 354)]
        public void TwoCommaSeparatedNumbersSumReturnNumbersSum(string input, int expected)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2\n3\n4", 9)]
        [InlineData("11,21\n35", 67)]
        [InlineData("11\n23,21\n35", 90)]
        public void MixDelimitersSeparatedNumbersSumReturnNumbersSum(string input, int expected)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//|\n1|2", 3)]
        [InlineData("//&\n1&2", 3)]
        public void CustomDelimiterSeparatedNumbersSumReturnNumbersSum(string input, int expected)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NegativeNumbersSumThrowsExceptionWithNotAllowedNumbers()
        {
            var calculator = new StringCalculator();

            var exception = Assert.Throws<ArgumentException>(() => calculator.Add("-1, -2, -4"));
            Assert.Contains("-1, -2, -4", exception.Message);
        }

        [Theory]
        [InlineData("1,1001,3", 4)]
        [InlineData("10,1010,5", 15)]
        public void GreaterThan1000NumbersSumIgnoredInSum(string input, int expected)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CustomDelimiterGreaterThenOneSymbolWithoutBracketsNumbersSumThrowsException()
        {
            var calculator = new StringCalculator();

            Assert.Throws<ArgumentException>(() => calculator.Add("//$%^\n1$%^5"));
        }

        [Theory]
        [InlineData("//[;;;]\n1;;;2", 3)]
        [InlineData("//[||||]\n1||||2", 3)]
        [InlineData("//[&&]\n1&&2", 3)]
        public void CustomMultipleSymbolDelimiterSeparatedNumbersSumReturnNumbersSum(string input, int expected)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("//[;][|][%]\n1;2%5|3", 11)]
        [InlineData("//[||][#]\n1||2#1", 4)]
        public void CustomMultipleSymbolMultipleDelimiterSeparatedNumbersSumReturnNumbersSum(string input, int expected)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }

    }
}