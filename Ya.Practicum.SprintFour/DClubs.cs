namespace Ya.Practicum.SprintFour;

/// <summary>
/// В компании, где работает Тимофей, заботятся о досуге сотрудников и устраивают различные кружки по интересам.
/// Когда кто-то записывается на занятие, в лог вносится название кружка.
/// По записям в логе составьте список всех кружков, в которые ходит хотя бы один человек.
/// </summary>
public static class DClubs
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var logEntries = int.Parse(reader.ReadLine()!);
        var logs = new HashSet<string>();

        for (var i = 0; i < logEntries; i++)
            logs.Add(reader.ReadLine()!);

        foreach (var log in logs)
            Console.WriteLine(log);
    }
}