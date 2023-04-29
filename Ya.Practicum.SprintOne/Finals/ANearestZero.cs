namespace Ya.Practicum.SprintOne.Finals;

/// <summary>
/// Тимофей ищет место, чтобы построить себе дом.
/// Улица, на которой он хочет жить, имеет длину n, то есть состоит из n одинаковых идущих подряд участков.
/// Каждый участок либо пустой, либо на нём уже построен дом.<br/>
/// Общительный Тимофей не хочет жить далеко от других людей на этой улице.
/// Поэтому ему важно для каждого участка знать расстояние до ближайшего пустого участка.
/// Если участок пустой, эта величина будет равна нулю — расстояние до самого себя.<br/>
/// <br/>Помогите Тимофею посчитать искомые расстояния.
/// Для этого у вас есть карта улицы. Дома в городе Тимофея нумеровались в том порядке,
/// в котором строились, поэтому их номера на карте никак не упорядочены. Пустые участки обозначены нулями.
/// </summary>
public static class ANearestZero
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var len = int.Parse(reader.ReadLine()!);
        var street = reader.ReadLine()!
            .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();

        var result = new List<int>();
        var distance = len;

        foreach (var house in street)
        {
            distance = house == 0 ? 0 : ++distance;
            result.Add(distance);
        }

        distance = len;
        for (var i = len - 1; i >= 0; i--)
        {
            distance = street[i] == 0 ? 0 : ++distance;
            var minDistance = Math.Min(distance, result[i]);
            result[i] = minDistance;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(string.Join(" ", result));
    }
}