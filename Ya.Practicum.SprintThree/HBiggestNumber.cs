namespace Ya.Practicum.SprintThree;

/// <summary>
/// Вечером ребята решили поиграть в игру «Большое число».
/// Даны числа. Нужно определить, какое самое большое число можно из них составить.
/// </summary>
public static class HBiggestNumber
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var n = int.Parse(reader.ReadLine()!);
        var numbers = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();

        for (var i = 1; i < n; i++)
        {
            var item = numbers[i];
            var j = i;

            while (j > 0 && Compare(numbers[j - 1], item) < 0)
            {
                numbers[j] = numbers[j - 1];
                j--;
            }

            numbers[j] = item;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(string.Join(string.Empty, numbers));
    }

    private static int Compare(int a, int b) => string.Compare($"{a}{b}", $"{b}{a}", StringComparison.Ordinal);
}