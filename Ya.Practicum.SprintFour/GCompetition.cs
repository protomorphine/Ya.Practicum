namespace Ya.Practicum.SprintFour;

/// <summary>
/// Жители Алгосов любят устраивать турниры по спортивному программированию.
/// Все участники разбиваются на пары и соревнуются друг с другом.
/// А потом два самых сильных программиста встречаются в финальной схватке,
/// которая состоит из нескольких раундов.
/// Если в очередном раунде выигрывает первый участник, в таблицу с результатами записывается 0, если второй, то 1.
/// Ничьей в раунде быть не может.
///
/// Нужно определить наибольший по длине непрерывный отрезок раундов,
/// по результатам которого суммарно получается ничья.
/// Например, если дана последовательность 0 0 1 0 1 1 1 0 0 0, то раунды с 2-го по 9-й
/// (нумерация начинается с единицы) дают ничью.
/// </summary>
public static class GCompetition
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var n = int.Parse(reader.ReadLine()!);
        var rounds = reader.ReadLine()!.Split(' ').Select(c => c == "0" ? -1 : 1).ToList();

        var map = new Dictionary<int, List<int>>
        {
            { 0, new List<int> {0} }
        };

        var lastPrefix = 0;
        for (var i = 0; i < n; i++)
        {
            lastPrefix += rounds[i];

            if (!map.ContainsKey(lastPrefix))
                map.Add(lastPrefix, new List<int>());

            map[lastPrefix].Add(i + 1);
        }

        Console.WriteLine(map.Values.Select(value => value[^1] - value[0]).Prepend(0).Max());
    }
}