namespace Ya.Practicum.SprintOne;

public static class GIntToBin
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var num = int.Parse(reader.ReadLine()!);

        var res = "";
        while (num / 2 >= 1)
        {
            res += num % 2;
            num = num / 2;
        }

        res += num % 2;

        var chArray = res.ToCharArray();
        Array.Reverse(chArray);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(new string(chArray));
    }
}