namespace Ya.Practicum.SprintSix;

/// <summary>
/// Под расстоянием между двумя вершинами в графе будем понимать длину кратчайшего пути между ними в рёбрах.
/// Для данной вершины s определите максимальное расстояние от неё до другой вершины неориентированного графа.
/// </summary>
public static class GMaxDistance
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var counts = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var (n, m) = (counts[0], counts[1]);

        var graph = ReadVertices(m, reader);
        var start = int.Parse(reader.ReadLine()!);

        var colors = Enumerable.Range(0, n + 1).Select(_ => Colors.White).ToList();

        var distances = new int[n + 1];
        Bfs(start, graph, colors, distances);

        Console.WriteLine(distances.Max());
    }

    private static Dictionary<int, List<int>> ReadVertices(int verticesCount, TextReader reader)
    {
        var graph = new Dictionary<int, List<int>>();
        for (var i = 0; i < verticesCount; i++)
        {
            var read = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
            if (graph.ContainsKey(read[0]))
                graph[read[0]].Add(read[1]);
            else
                graph.Add(read[0], new List<int> {read[1]});

            if (graph.ContainsKey(read[1]))
                graph[read[1]].Add(read[0]);
            else
                graph.Add(read[1], new List<int> {read[0]});
        }

        return graph;
    }

    private static void Bfs(
        int vertex,
        IReadOnlyDictionary<int, List<int>> graph,
        IList<Colors> colors,
        int[] distances
    )
    {
        var queue = new Queue<int>();
        queue.Enqueue(vertex);

        distances[vertex] = 0;

        colors[vertex] = Colors.Gray;

        while (queue.Count > 0)
        {
            var u = queue.Dequeue();

            if (!graph.ContainsKey(u))
                continue;

            foreach (var v in graph[u].Where(v => colors[v] is Colors.White).OrderBy(it => it))
            {
                distances[v] = distances[u] + 1;
                colors[v] = Colors.Gray;
                queue.Enqueue(v);
            }
        }
    }
}