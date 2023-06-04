namespace Ya.Practicum.SprintFour;

/// <summary>
/// Гоша написал программу, которая сравнивает строки исключительно по их хешам. Если хеш равен, то и строки равны.
/// Тимофей увидел это безобразие и поручил вам сломать программу Гоши, чтобы остальным неповадно было.
/// В этой задаче вам надо будет лишь найти две различные строки, которые для заданной хеш-функции будут давать
/// одинаковое значение.
/// </summary>
public static class BBreakMe
{
    public static void Execute()
    {
        const int @base = 1000;
        const int mod = 123_987_123;
        const string allowed = "abcdefghijklmnopqrstuvwxyz";

        var length = Random.Shared.Next(15);
        var str1 = CreateRandomString(length, allowed);
        var str2 = CreateRandomString(length, allowed);

        while (APolynomialHashes.Hash(str1, @base, mod) != APolynomialHashes.Hash(str2, @base, mod))
            str2 = CreateRandomString(length, allowed);

        Console.WriteLine(str1);
        Console.WriteLine(str2);
    }

    private static string CreateRandomString(int length, string allowed) =>
        string.Create(length, allowed, (span, s) =>
        {
            for (var i = 0; i < length; i++)
                span[i] = s[Random.Shared.Next(allowed.Length)];
        });
}