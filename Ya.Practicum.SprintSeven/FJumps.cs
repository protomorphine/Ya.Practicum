namespace Ya.Practicum.SprintSeven;

/// <summary>
/// Алла хочет доказать, что она умеет прыгать вверх по лестнице быстрее всех.
/// На этот раз соревнования будут проходить на специальной прыгательной лестнице.
/// С каждой её ступеньки можно прыгнуть вверх на любое расстояние от 1 до k. Число k придумывает Алла.
/// Гоша не хочет проиграть, поэтому просит вас посчитать количество способов допрыгать от первой ступеньки до n-й.
/// Изначально все стоят на первой ступеньке.
/// </summary>
public static class FJumps
{
    private const int Module = 1_000_000_007;

    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var arr = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var n = arr[0];
        var k = arr[1];

        var dp = new int[n + 1];

        Console.WriteLine(CountSteps(n, k, dp));
    }

    private static int CountSteps(int n, int k, IList<int> dp)
    {
        switch (n)
        {
            case < 1:
                return 0;

            case 1:
                return 1;

            default:
            {
                if (dp[n] == 0)
                {
                    for (var i = 1; i <= k; i++)
                    {
                        dp[n] += CountSteps(n - i, k, dp);
                        dp[n] %= Module;
                    }
                }

                break;
            }
        }

        return dp[n] % Module;
    }
}