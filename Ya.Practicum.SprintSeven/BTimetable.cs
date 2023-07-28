using System.Globalization;

namespace Ya.Practicum.SprintSeven;

/// <summary>
/// Дано количество учебных занятий, проходящих в одной аудитории. Для каждого из них указано время начала и конца.
/// Нужно составить расписание, в соответствии с которым в классе можно будет провести как можно больше занятий.
/// Если возможно несколько оптимальных вариантов, то выведите любой. Возможно одновременное проведение
/// более чем одного занятия нулевой длительности.
/// </summary>
public static class BTimetable
{
    public static void Execute()
    {
        var cultureInfo = new CultureInfo("en-US");
        
        using var reader = new StreamReader(Console.OpenStandardInput());
        var days = int.Parse(reader.ReadLine()!);

        var timeTable = new List<float[]>();
        for (var i = 0; i < days; i++)
            timeTable.Add(reader.ReadLine()!.Split(' ').Select(it => float.Parse(it, cultureInfo)).ToArray());

        var time = 0.0f;
        var res = new List<float[]>();
        foreach (var ts in timeTable.OrderBy(it => it[1]).ThenBy(it => it[0]))
        {
            if (ts[0] < time)
                continue;
            
            res.Add(ts);
            time = ts[1];
        }

        Console.WriteLine(res.Count);
        Console.WriteLine(
            string.Join(
                "\n",
                res.Select(it =>
                    $"{it[0].ToString(cultureInfo)} {it[1].ToString(cultureInfo)}")));
    }
}

public class Timesheet
{
    public float StartsAt { get; set; }
    public float EndsAt { get; set; }

    public Timesheet(string str)
    {
        var tokens = str.Split(' ');
        StartsAt = float.Parse(tokens[0], new CultureInfo("en-US"));
        EndsAt = float.Parse(tokens[1], new CultureInfo("en-US"));
    }
}