namespace Ya.Practicum.SprintSeven;

/// <summary>
/// Гуляя по одному из островов Алгосского архипелага, Гоша набрёл на пещеру, в которой лежат кучи золотого песка.
/// К счастью, у Гоши есть с собой рюкзак грузоподъёмностью до M килограмм, поэтому он может унести с собой
/// какое-то ограниченное количество золота.
/// Всего золотых куч n штук, и все они разные. В куче под номером i содержится mi килограммов золотого песка,
/// а стоимость одного килограмма — ci алгосских франков.
/// </summary>
public static class CGoldFever
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var maxKilo = long.Parse(reader.ReadLine()!);
        var goldBunchesCount = int.Parse(reader.ReadLine()!);

        var goldBunches = new List<long[]>();
        for (var i = 0; i < goldBunchesCount; i++)
        {
            var tokens = reader.ReadLine()!.Split(' ').Select(long.Parse).ToList();
            goldBunches.Add(new []{tokens[0], tokens[1]});
        }

        var spaceLeft = maxKilo;
        long profit = 0;
        foreach (var goldBunch in goldBunches.OrderByDescending(it => it[0]))
        {
            if (spaceLeft <= 0)
                break;

            var min = Math.Min(spaceLeft, goldBunch[1]);

            spaceLeft -= min;
            profit += min * goldBunch[0];
        }
        
        Console.WriteLine(profit);
    }
}