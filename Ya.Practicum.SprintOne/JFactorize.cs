namespace Ya.Practicum.SprintOne;

/// <summary>
/// Основная теорема арифметики говорит:
/// любое число раскладывается на произведение простых множителей единственным образом,
/// с точностью до их перестановки. Например:
/// <br /> Число 8 можно представить как 2 × 2 × 2.
/// <br /> Число 50 –— как 2 × 5 × 5 (или 5 × 5 × 2, или 5 × 2 × 5).
/// Три варианта отличаются лишь порядком следования множителей.
/// <br />
/// <br /> Разложение числа на простые множители называется факторизацией числа.
/// <br /> Напишите программу, которая производит факторизацию переданного числа.
/// </summary>
public static class JFactorize
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var num = int.Parse(reader.ReadLine()!);

        var res = new List<int>();
        for (var i = 2; i * i <= num; i++)
        {
            while (num % i == 0)
            {
                res.Add(i);
                num /= i;
            }
        }

        if (num > 1)
            res.Add(num);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(string.Join(" ", res));
    }
}