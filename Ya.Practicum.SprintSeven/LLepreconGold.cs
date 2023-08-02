namespace Ya.Practicum.SprintSeven;

/// <summary>
/// Лепреконы в данной задаче появились по соображениям общей морали, так как грабить банки — нехорошо.
/// Вам удалось заключить неплохую сделку с лепреконами, поэтому они пустили вас в своё хранилище золотых слитков.
/// Все слитки имеют единую пробу, то есть стоимость 1 грамма золота в двух разных слитках одинакова.
/// В хранилище есть n слитков, вес i-го слитка равен wi кг. У вас есть рюкзак, вместимость которого M килограмм.
/// Выясните максимальную суммарную массу золотых слитков, которую вы сможете унести.
/// </summary>
public static class LLepreconGold
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var arr = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var capacity = arr[1];

        var masses = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();

        var dp = new int[capacity + 1];
        foreach (var mass in masses)
        {
            for (var i = capacity; i >= mass; i--) 
                dp[i] = Math.Max(dp[i], mass + dp[i - mass]);
        }
        
        Console.WriteLine(dp[capacity]);
    }
}