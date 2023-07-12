namespace Ya.Practicum.SprintFour;

/// <summary>
/// Вася решил избавиться от проблем с произношением и стать певцом.
/// Он обратился за помощью к логопеду. Тот посоветовал Васе выполнять упражнение,
/// которое называется анаграммная группировка.
/// В качестве подготовительного этапа нужно выбрать из множества строк анаграммы.
/// </summary>
public static class FAnagrams
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        using var writer = new StreamWriter(Console.OpenStandardOutput());
        var count = int.Parse(reader.ReadLine()!);
        var words = reader.ReadLine()!.Split(' ').ToList();

        var res = new Dictionary<string, List<int>>();
        for (var i = 0; i < count; i++)
        {
            var word = words[i];
            var hash = GetHash(word);

            if (res.TryGetValue(hash, out var value))
                value.Add(i);
            else
            {
                var list = new List<int> {i};
                res.Add(hash, list);
            }
        }

        foreach (var val in res.Values)
            writer.WriteLine(string.Join(" ", val));
    }

    private static string GetHash(string str)
    {
        var arr = str.ToCharArray();
        Array.Sort(arr);
        return new string(arr);
    }
}