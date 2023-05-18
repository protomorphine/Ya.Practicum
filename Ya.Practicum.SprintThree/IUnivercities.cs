namespace Ya.Practicum.SprintThree;

/// <summary>
/// На IT-конференции присутствовали студенты из разных вузов со всей страны.
/// Для каждого студента известен ID университета, в котором он учится.
/// Тимофей предложил Рите выяснить, из каких k вузов на конференцию пришло больше всего учащихся.
/// </summary>
public static class IUnivercities
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var _ = int.Parse(reader.ReadLine()!);

        var ids = reader.ReadLine()!
            .Split(' ')
            .Select(int.Parse)
            .GroupBy(it => it).Select(it => new { it.Key, Count = it.Count() })
            .OrderByDescending(it => it.Count)
            .ThenBy(it => it.Key)
            .Select(it => it.Key);
        
        var reqLength = int.Parse(reader.ReadLine()!);

        Console.WriteLine(string.Join(" ", ids.Take(reqLength)));
    }
}