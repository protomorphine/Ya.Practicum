namespace Ya.Practicum.SprintFive;

/// <summary>
/// Ребятам стало интересно, сколько может быть различных деревьев поиска, содержащих
/// в своих узлах все уникальные числа от 1 до n. Помогите им найти ответ на этот вопрос.
/// =============================================================================================
/// https://www.geeksforgeeks.org/program-nth-catalan-number/#discuss
/// https://ru.wikipedia.org/wiki/%D0%A7%D0%B8%D1%81%D0%BB%D0%B0_%D0%9A%D0%B0%D1%82%D0%B0%D0%BB%D0%B0%D0%BD%D0%B0
/// </summary>
public static class IDifferentBSTs
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var n = int.Parse(reader.ReadLine()!);
        
        Console.WriteLine(Calculate(n));
    }

    private static int Calculate(int n) => n < 2 ? 1 : Enumerable.Range(0, n).Sum(i => Calculate(i) * Calculate(n - 1 - i));
}