namespace StringCalculator
{
    internal class Parser
    {
        private string _input;
        private List<string> _delimiters;
        private bool _isCustomDelimiterExist;

        public Parser(string input)
        {
            _input = input;
            _delimiters = new List<string> { ",", "\n" };
            _isCustomDelimiterExist = _input?.StartsWith("//") ?? false;
        }

        public IEnumerable<int> Parse()
        {
            var position = -1;
            if (_isCustomDelimiterExist)
            {
                position = _input.IndexOf('\n');
                SetDelimiters(GetCustomDelimiters(_input, position));
            }

            return GetNumbers(_input, position + 1, _delimiters);
        }

        private static IEnumerable<string> GetCustomDelimiters(string delimiters, int position)
        {
            var result = Array.Empty<string>();
            var part = GetCustomDelimitersSubString(delimiters, position);
            if (!part.Contains('['))
            {
                if (part.Length > 1)
                    throw new ArgumentException("Multiple symbols delimiter should be in square brackets");

                result = new[] { part };
            }
            else
            {
                result = part
                    .TrimStart('[')
                    .TrimEnd(']')
                    .Split("][");
            }

            return result;
        }

        private static string GetCustomDelimitersSubString(string input, int position)
        {
            if (position == -1)
                throw new ArgumentException("Arguments cannot contain only delimiters");
            return input.Substring(2, position - 2);
        }

        private void SetDelimiters(IEnumerable<string> delimiters)
        {
            if (delimiters != null && delimiters.Any())
                _delimiters.AddRange(delimiters);
        }

        private static IEnumerable<int> GetNumbers(string numbers, int position, IEnumerable<string> delimiters)
        {
            var result = new List<int>();
            return numbers.Substring(position)
                .Split(delimiters.ToArray(), StringSplitOptions.TrimEntries)
                .Select(t => Convert.ToInt32(t));
        }
    }
}
