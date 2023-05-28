namespace Ya.Practicum.SprintFour;

/// <summary>
/// Алле очень понравился алгоритм вычисления полиномиального хеша. Помогите ей написать функцию,
/// вычисляющую хеш строки s. В данной задаче необходимо использовать
/// в качестве значений отдельных символов их коды в таблице ASCII.
/// </summary>
public static class APolynomialHashes
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var a = int.Parse(reader.ReadLine()!);
        var m = int.Parse(reader.ReadLine()!);
        var str = reader.ReadLine()!;

        Console.WriteLine(Hash(str, a, m));
    }

    private static long Hash(string str, int a, int m) => 
        str.Aggregate<char, long>(0, (current, c) => (current * a % m + (int) c) % m);
}