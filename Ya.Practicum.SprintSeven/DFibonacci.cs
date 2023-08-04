namespace Ya.Practicum.SprintSeven;

/// <summary>
/// Гоша практикуется в динамическом программировании — он хочет быстро считать числа Фибоначчи.
/// Напомним, что числа Фибоначчи определены как последовательность . F0 = F1 = 1, Fn = Fn -1 + Fn-2, n ≥ 2.
/// Помогите Гоше решить эту задачу.
/// </summary>
public static class DFibonacci
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var idx = int.Parse(reader.ReadLine()!);

        var memo = new Dictionary<int, long>()
        {
            {0, 1},
            {1, 1}
        };

        for (var i = 2; i <= idx; i++) 
            memo.Add(i, (memo[i - 2] + memo[i - 1]) % 1_000_000_007);

        Console.WriteLine(memo[idx]);
    }
}