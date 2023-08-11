using System.Text;

namespace Ya.Practicum.SprintEight;

/// <summary>
/// У Риты была строка s, Гоша подарил ей на 8 марта ещё n других строк ti, 1≤ i≤ n. Теперь Рита думает,
/// куда их лучше поставить. Один из вариантов —– расположить подаренные строки внутри имеющейся строки s,
/// поставив строку ti сразу после символа строки s с номером ki
/// (в частности, если ki=0, то строка вставляется в самое начало s).
/// Помогите Рите и определите, какая строка получится после вставки в s всех подаренных Гошей строк.
/// </summary>
public static class EStringInsert
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var originalString = reader.ReadLine()!;
        var surpriseCount = int.Parse(reader.ReadLine()!);

        var surprise = new List<KeyValuePair<string, int>>();
        
        for (var i = 0; i < surpriseCount; i++)
        {
            var tokens = reader.ReadLine()!.Split(' ');
            surprise.Add(new KeyValuePair<string, int>(tokens[0], int.Parse(tokens[1])));
        }

        var sb = new StringBuilder();
        var current = 0;
        foreach (var pair in surprise.OrderBy(it => it.Value))
        {
            sb.Append(originalString[current..pair.Value]);
            sb.Append(pair.Key);

            current = pair.Value;
        }

        sb.Append(originalString[current..]);
        
        Console.WriteLine(sb.ToString());
    }
}