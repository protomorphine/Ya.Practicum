namespace Ya.Practicum.SprintFour;

/// <summary>
/// Алла не остановилась на достигнутом –— теперь она хочет научиться
/// быстро вычислять хеши произвольных подстрок данной строки. Помогите ей!
/// На вход поступают запросы на подсчёт хешей разных подстрок.
/// Ответ на каждый запрос должен выполняться за O(1). Допустимо в начале работы программы сделать
/// предподсчёт для дальнейшей работы со строкой.
/// </summary>
public static class CPrefixHashes
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var a = int.Parse(reader.ReadLine()!);
        var m = int.Parse(reader.ReadLine()!);
        var s = reader.ReadLine()!;
        var intervals = int.Parse(reader.ReadLine()!);

        var hashes = CalculatePrefixHashes(s, a, m);
        var powers = CalculatePowers(s, a, m);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        for (var i = 0; i < intervals; i++)
        {
            var interval = reader.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
            writer.WriteLine(GetHash(hashes, powers, m, interval));
        }
    }

    private static long GetHash(IReadOnlyList<long> hashes, IReadOnlyList<long> powers, long m, IReadOnlyList<int> interval)
    {
        var start = interval[0] - 1;
        var stop = interval[1];
        var distance = stop - start;

        var stopHash = hashes[stop];
        var startHash = hashes[start];
        var distancePowers = powers[distance];

        return (stopHash + m - (startHash * distancePowers) % m) % m;
    }

    private static long[] CalculatePowers(string str, int a, int m)
    {
        var powers = new long[str.Length + 1];
        powers[0] = 1;
        for (var i = 1; i <= str.Length; i++)
            powers[i] = powers[i - 1] * a % m;

        return powers;
    }

    private static long[] CalculatePrefixHashes(string str, int a, int m)
    {
        var hashes = new long[str.Length + 1];
        for (var i = 1; i <= str.Length; i++)
            hashes[i] = hashes[i - 1] * a % m + str[i - 1] % m;

        return hashes;
    }
}