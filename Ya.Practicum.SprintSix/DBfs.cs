namespace Ya.Practicum.SprintSix;

/// <summary>
/// Задан неориентированный граф. Обойдите поиском в ширину все вершины,
/// достижимые из заданной вершины s, и выведите их в порядке обхода, если начинать обход из s.
/// </summary>
public static class DBfs
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var counts = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var (n, m) = (counts[0], counts[1]);

        var graph = ReadVertices(m, reader);
        var start = int.Parse(reader.ReadLine()!);

        var colors = Enumerable.Range(0, n + 1).Select(_ => Colors.White).ToList();

        Bfs(start, graph, colors, current => Console.Write($"{current} "));
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
        Action<object> action
    )
    {
        var queue = new Queue<int>();
        queue.Enqueue(vertex);

        colors[vertex] = Colors.Gray;

        while (queue.Count > 0)
        {
            var u = queue.Dequeue();

            action.Invoke(u);

            if (!graph.ContainsKey(u))
                continue;

            foreach (var v in graph[u].Where(v => colors[v] is Colors.White).OrderBy(it => it))
            {
                colors[v] = Colors.Gray;
                queue.Enqueue(v);
            }
        }
    }
}