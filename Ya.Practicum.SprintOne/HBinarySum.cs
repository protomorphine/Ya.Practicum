namespace Ya.Practicum.SprintOne;

/// <summary>
/// Тимофей записал два числа в двоичной системе счисления
/// и попросил Гошу вывести их сумму, также в двоичной системе.
/// Встроенную в язык программирования возможность сложения двоичных чисел применять нельзя.
/// Помогите Гоше решить задачу.
/// Решение должно работать за O(N), где N –— количество разрядов максимального числа на входе.
/// </summary>
public static class HBinarySum
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var first = reader.ReadLine()!;
        var second = reader.ReadLine()!;

        string max, min;
        if (first.Length != second.Length)
        {
            max = first.Length > second.Length ? first : second;
            min = first.Length < second.Length ? first : second;

            min = min.PadLeft(max.Length, '0');
        }
        else
        {
            max = first;
            min = second;
        }

        var res = "";
        var over = 0;
        for (var i = max.Length - 1; i >= 0; i--)
        {
            var firstChar = int.Parse(max[i].ToString());
            var secondChar = int.Parse(min[i].ToString());
            var tmp = firstChar + secondChar + over;

            res += tmp % 2;

            if (tmp >= 2)
            {
                over = 1;
                continue;
            }

            over = 0;
        }

        if (over != 0)
            res += over;

        var reversed = res.ToCharArray();
        Array.Reverse(reversed);
        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(new string(reversed));
    }
}