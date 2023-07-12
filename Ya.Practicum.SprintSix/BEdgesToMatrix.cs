using System.Text;

namespace Ya.Practicum.SprintSix;

/// <summary>
/// Алла успешно справилась с предыдущим заданием, и теперь ей дали новое. На этот раз список рёбер ориентированного
/// графа надо переводить в матрицу смежности. Конечно же, Алла попросила вас помочь написать программу для этого.
/// </summary>
public static class BEdgesToMatrix
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var counts = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var (n, m) = (counts[0], counts[1]);

        var edges = new List<KeyValuePair<int, int>>();
        for (var i = 0; i < m; i++)
        {
            var read = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
            edges.Add(new KeyValuePair<int, int>(read[0], read[1]));
        }

        var result = new int[n, n];

        foreach (var edge in edges)
            result[edge.Key - 1, edge.Value - 1] = 1;

        for (var i = 0; i < n; i++)
        {
            var row = new StringBuilder();
            for (var j = 0; j < n; j++)
                row.Append($"{result[i, j]} ");

            Console.WriteLine(row);
        }
    }
}