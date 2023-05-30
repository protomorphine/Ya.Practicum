namespace Ya.Practicum.SprintFour;

/// <summary>
/// На вход подается строка. Нужно определить длину наибольшей подстроки, которая не содержит повторяющиеся символы.
/// </summary>
public static class ESubstrings
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var str = reader.ReadLine()!;
        
        Console.WriteLine(GetMaximumSubstringLength(str));
    }

    private static int GetMaximumSubstringLength(string str)
    {
        return 0;
    }
}