namespace Ya.Practicum.SprintOne;

/// <summary>
/// Метеорологическая служба вашего города решила исследовать погоду новым способом.
/// <br/>Под температурой воздуха в конкретный день будем понимать максимальную температуру в этот день.
/// <br/>Под хаотичностью погоды за n дней служба понимает количество дней, в которые температура строго больше,
/// чем в день до (если такой существует) и в день после текущего (если такой существует).
/// Например, если за 5 дней максимальная температура воздуха составляла [1, 2, 5, 4, 8] градусов,
/// то хаотичность за этот период равна 2: в 3-й и 5-й дни выполнялись описанные условия.
/// <br/> Определите по ежедневным показаниям температуры хаотичность погоды за этот период.
/// <br/> Заметим, что если число показаний n=1, то единственный день будет хаотичным.
/// </summary>
public static class DWeatherForecast
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var len = int.Parse(reader.ReadLine()!);
        var temps = reader.ReadLine()!
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        temps.Insert(0, -273);
        temps.Add(-273);

        var res = 0;
        for (var i = 1; i < temps.Count - 1; i++)
        {
            if (temps[i] > temps[i - 1] && temps[i] > temps[i + 1])
                res += 1;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(res);
    }
}