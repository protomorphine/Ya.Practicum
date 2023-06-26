namespace Ya.Practicum.SprintOne.Finals;

/// <summary>
/// Игра «Тренажёр для скоростной печати» представляет собой поле из клавиш 4x4.
/// В нём на каждом раунде появляется конфигурация цифр и точек.
/// На клавише написана либо точка, либо цифра от 1 до 9.<br />
/// В момент времени t игрок должен одновременно нажать на все клавиши, на которых написана цифра t.
/// Гоша и Тимофей могут нажать в один момент времени на k клавиш каждый.
/// Если в момент времени t нажаты все нужные клавиши, то игроки получают 1 балл.<br />
/// <br />Найдите число баллов, которое смогут заработать Гоша и Тимофей, если будут нажимать на клавиши вдвоём.
/// </summary>
public static class BGoldenHand
{
    public static void Execute()
    {
        const int rowsCount = 4;
        const int playersCount = 2;
        const int times = 10;

        using var reader = new StreamReader(Console.OpenStandardInput());
        var k = int.Parse(reader.ReadLine()!);

        var map = new Dictionary<int, int>();
        for (var i = 0; i < rowsCount; i++)
        {
            foreach (var c in reader.ReadLine()!)
            {
                if (!int.TryParse(c.ToString(), out var parsed)) continue;
                if (map.TryGetValue(parsed, out _))
                {
                    map[parsed]++;
                    continue;
                }

                map.Add(parsed, 1);
            }
        }

        var points = 0;
        for (var t = 1; t < times; t++)
        {
            var entriesCount = map.GetValueOrDefault(t);
            if (entriesCount > 0 && entriesCount <= k * playersCount)
                points++;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(points);
    }
}