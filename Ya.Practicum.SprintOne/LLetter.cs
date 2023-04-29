namespace Ya.Practicum.SprintOne;

/// <summary>
/// Васе очень нравятся задачи про строки, поэтому он придумал свою.
/// Есть 2 строки s и t, состоящие только из строчных букв.
/// Строка t получена перемешиванием букв строки s и добавлением 1 буквы в случайную позицию.
/// Нужно найти добавленную букву.
/// </summary>
public static class LLetter
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var s = reader.ReadLine()!.OrderBy(it => it).ToList();
        var t = reader.ReadLine()!.OrderBy(it => it).ToList();

        foreach (var ch in s)
            t.Remove(ch);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(t.First());
    }
}