namespace Ya.Practicum.SprintFour;

public static class CPrefixHashes
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var a = int.Parse(reader.ReadLine()!);
        var m = int.Parse(reader.ReadLine()!);
        var s = reader.ReadLine()!;
        var intervals = int.Parse(reader.ReadLine()!);

        var hashes = GetPrefixHashes(s, a, m);
        var powers = GetPowers(s, a, m);

        for (var i = 0; i < intervals; i++)
        {
            var interval = reader.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(GetHash(hashes, powers, m, interval));
        }
    }

    private static double GetHash(long[] hashes, long[] powers, long m, int[] interval)
    {
        var start = interval[0];
        var stop = interval[1];

        return (hashes[stop] + m - (hashes[start] * powers[stop - start]) % m) % m;
    }

    private static long[] GetPowers(string str, int a, int m)
    {
        var powers = new long[str.Length + 1];
        powers[0] = 1;
        for (var i = 1; i <= str.Length; i++)
            powers[i] = powers[i - 1] * a % m;

        return powers;
    }

    private static long[] GetPrefixHashes(string str, int a, int m)
    {
        var hashes = new long[str.Length + 1];
        for (var i = 1; i <= str.Length; i++)
            hashes[i] = (hashes[i - 1] * a % m + str[i - 1]) % m;

        return hashes;
    }
}