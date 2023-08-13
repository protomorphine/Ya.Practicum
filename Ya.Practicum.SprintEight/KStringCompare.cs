namespace Ya.Practicum.SprintEight;

/// <summary>
/// Алла придумала новый способ сравнивать две строки: чтобы сравнить строки a и b, в них надо оставить только те буквы,
/// которые в английском алфавите стоят на четных позициях. Затем полученные строки сравниваются по обычным правилам.
/// Помогите Алле реализовать новое сравнение строк.
/// </summary>
public static class KStringCompare
{
    public static void Execute()
    {
        var alphabet = Enumerable.Range('a', 26)
            .Select((x, i) => new KeyValuePair<int,char>(i, (char)x))
            .Where(it => it.Key % 2 is not 0)
            .Select(it => it.Value)
            .ToList();
        
        using var reader = new StreamReader(Console.OpenStandardInput());
        var str1 = reader.ReadLine()!.Where(it => alphabet.Contains(it)).ToArray();
        var str2 = reader.ReadLine()!.Where(it => alphabet.Contains(it)).ToArray();
        
        Console.WriteLine(Math.Sign(string.Compare(new string(str1), new string(str2), StringComparison.Ordinal)));
    }
}