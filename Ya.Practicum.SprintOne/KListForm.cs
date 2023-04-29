namespace Ya.Practicum.SprintOne;

/// <summary>
/// Вася просил Аллу помочь решить задачу. На этот раз по информатике.
/// Для неотрицательного целого числа X списочная форма –— это массив его цифр слева направо.
/// К примеру, для 1231 списочная форма будет [1,2,3,1].
/// На вход подается количество цифр числа Х, списочная форма неотрицательного числа Х
/// и неотрицательное число K. Число К не превосходят 10000. Длина числа Х не превосходит 1000.
/// <br />
/// <br /> Нужно вернуть списочную форму числа X + K.
/// </summary>
public static class KListForm
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var len = int.Parse(reader.ReadLine()!);
        var listForm = reader.ReadLine()!
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();

        var k = int.Parse(reader.ReadLine()!);

        var maxLength = Math.Max(k.ToString().Length, listForm.Count);

        var kAsString = k.ToString().PadLeft(maxLength, '0');
        var listFormAsString = string.Join("", listForm).PadLeft(maxLength, '0');

        var res = new List<int>();
        var over = 0;
        for (var i = listFormAsString.Length - 1; i >= 0; i--)
        {
            var tmp = int.Parse(listFormAsString[i].ToString()) + int.Parse(kAsString[i].ToString()) + over;

            res.Add(tmp % 10);
            if (tmp > 9)
            {
                over = tmp / 10;
                continue;
            }

            over = 0;
        }
        if (over >= 1)
            res.Add(over);

        res.Reverse();

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(string.Join(" ", res));
    }
}