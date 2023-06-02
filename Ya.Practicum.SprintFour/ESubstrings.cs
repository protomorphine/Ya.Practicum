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

        if (str.Length < 2)
            return str.Length;
        var map = new Dictionary<char, int>();

        var left = 0;
        var right = 1;
        var max = 0;
        
        map.Add(str[left], 0);

        while (right < str.Length)
        {
            var current = str[right];

            if (map.Remove(current, out var index)) 
                left = Math.Max(left, index + 1);

            max = Math.Max(max, right - left + 1);
            map.Add(current, right);
            right++;
        }

        return max;
    }
}