namespace Ya.Practicum.SprintOne;

/// <summary>
/// Вася реализовал функцию, которая переводит целое число из десятичной системы в двоичную.
/// Но, кажется, она получилась не очень оптимальной.
/// Попробуйте написать более эффективную программу.
/// <br /><b>Не используйте встроенные средства языка по переводу чисел в бинарное представление.</b>
/// </summary>
public static class GIntToBin
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var num = int.Parse(reader.ReadLine()!);

        var res = string.Empty;
        while (num / 2 >= 1)
        {
            res += num % 2;
            num /= 2;
        }

        res += num % 2;

        var chArray = res.ToCharArray();
        Array.Reverse(chArray);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(new string(chArray));
    }
}