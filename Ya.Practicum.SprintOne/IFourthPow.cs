namespace Ya.Practicum.SprintOne;

/// <summary>
/// Напишите программу, которая определяет, будет ли положительное целое число степенью четвёрки.
/// <br />Подсказка: степенью четвёрки будут все числа вида 4^n, где n – целое неотрицательное число.
/// </summary>
// ReSharper disable once InconsistentNaming
public static class IFourthPow
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var number = int.Parse(reader.ReadLine()!);

        var res = Math.Log(number, 4);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        writer.WriteLine(Math.Truncate(res) == res);
    }
}