namespace Ya.Practicum.SprintSeven;

/// <summary>
/// Рита хочет попробовать поиграть на бирже. Но для начала она решила потренироваться на исторических данных.
/// Даны стоимости акций в каждый из n дней. В течение дня цена акции не меняется.
/// Акции можно покупать и продавать, но только по одной штуке в день. В один день нельзя совершать более
/// одной операции (покупки или продажи). Также на руках не может быть более одной акции в каждый момент времени.
/// Помогите Рите выяснить, какую максимальную прибыль она могла бы получить.
/// </summary>
public static class AExchange
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        _ = int.Parse(reader.ReadLine()!);
        var prices = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();

        var maxProfit = 0;
        for (var i = 1; i < prices.Count; i++) 
            maxProfit += Math.Max(0, prices[i] - prices[i - 1]);

        Console.WriteLine(maxProfit);
    }
}