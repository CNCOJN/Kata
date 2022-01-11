namespace StringAverage;

public class Case
{
    private readonly string[] _numbersInLetters =
        new[] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    
    private const string NotAvailable = "n/a";

    public string StringAverage1(string? source)
    {
        if (string.IsNullOrEmpty(source?.Trim())) return NotAvailable;
        var numbersInDigits = ConertNumberInLettersToDigits(source);
        return AreNumbersInValid(numbersInDigits) ? NotAvailable : GetAverageInNumericLetters(numbersInDigits);
    }

    private IEnumerable<int> ConertNumberInLettersToDigits(string input) => input
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => Array.IndexOf(_numbersInLetters, x.ToLowerInvariant()));

    private bool AreNumbersInValid(IEnumerable<int> numbers) => numbers.Any(x => x == -1);

    private string GetAverageInNumericLetters(IEnumerable<int> numbersInDigits) =>
        _numbersInLetters[(int) numbersInDigits.Average()];
}