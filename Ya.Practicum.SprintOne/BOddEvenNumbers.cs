namespace Ya.Practicum.SprintOne;

/// <summary>
/// Представьте себе онлайн-игру для поездки в метро:
/// игрок нажимает на кнопку, и на экране появляются три случайных числа.
/// Если все три числа оказываются одной чётности, игрок выигрывает.
/// Напишите программу, которая по трём числам определяет, выиграл игрок или нет.
/// </summary>
public static class BOddEvenNumbers
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());

        var line = reader.ReadLine()!
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => Math.Abs(int.Parse(s) % 2))
            .ToList();

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(line.TrueForAll(i => i is 0) || line.TrueForAll(i => i is 1) ? "WIN" : "FAIL");
    }
}
