namespace Ya.Practicum.SprintSix;

/// <summary>
/// Вам дан неориентированный граф. Найдите его компоненты связности.
/// </summary>
public static class EConnectivityComponents
{
    private static List<int> _colors = new();
    private static int _compCount = 1;

    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var counts = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var (n, m) = (counts[0], counts[1]);

        var graph = ReadVertices(m, reader);

        _colors = Enumerable.Range(0, n + 1).Select(_ => -1).ToList();

        for (var i = 1; i < _colors.Count; i++)
        {
            if (_colors[i] is not -1)
                continue;

            Dfs(i, graph);
            _compCount++;
        }

        var groups = _colors.Select((it, i) => new KeyValuePair<int, int>(it, i))
            .GroupBy(it => it.Key).Select(it => it.ToList()).ToList();

        Console.WriteLine(groups.Count - 1);
        for (var i = 1; i < groups.Count; i++)
            Console.WriteLine(string.Join(" ", groups[i].Select(it => it.Value)));
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

    private static IEnumerable<int> GetOutgoingEdges(IReadOnlyDictionary<int, List<int>> graph, int vertex) =>
        !graph.ContainsKey(vertex) ? Enumerable.Empty<int>() : graph[vertex];

    private static void Dfs(int vertex, IReadOnlyDictionary<int, List<int>> edges)
    {
        _colors[vertex] = 0;

        foreach (var w in GetOutgoingEdges(edges, vertex).OrderBy(it => it))
        {
            if (_colors[w] is -1)
                Dfs(w, edges);
        }

        _colors[vertex] = _compCount;
    }
}