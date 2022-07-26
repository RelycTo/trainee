namespace StringCalculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        var terms = new Parser(numbers)
            .Parse()
            .Where(t => t <= 1000)
            .ToArray();

        var negatives = terms.Where(t => t < 0).ToArray();
        if (negatives.Any())
            throw new ArgumentException($"negatives not allowed: {string.Join(", ", negatives)}");

        return terms.Sum();
    }
}