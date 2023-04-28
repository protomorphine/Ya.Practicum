namespace Ya.Practicum.SprintTwo;

/// <summary>
/// У Тимофея было n(0≤n≤32) стажёров.
/// Каждый стажёр хотел быть лучше своих предшественников,
/// поэтому i-й стажёр делал столько коммитов, сколько делали два предыдущих стажёра в сумме.
/// Два первых стажёра были менее инициативными —– они сделали по одному коммиту.
///
/// Пусть Fi —– число коммитов, сделанных i-м стажёром (стажёры нумеруются с нуля).
/// Тогда выполняется следующее: F0 = F1 = 1.
///  Для всех i ≥ 2 выполнено Fi = Fi-1 + Fi-2.
/// Определите, сколько кода напишет следующий стажёр –— найдите Fn.
/// Решение должно быть реализовано рекурсивно.
/// </summary>
public static class KRecursiveFibonacci
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var n = int.Parse(reader.ReadLine()!);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(GetFibonacciByIndexRecursively(n));
    }

    private static int GetFibonacciByIndexRecursively(int n)
    {
        if (n is 0 or 1)
            return 1;

        return GetFibonacciByIndexRecursively(n - 1) + GetFibonacciByIndexRecursively(n - 2);
    }
}