namespace Ya.Practicum.SprintSix;

/// <summary>
/// Вам дан ориентированный граф. Известно, что все его вершины достижимы из вершины s=1.
/// Найдите время входа и выхода при обходе в глубину, производя первый запуск из вершины s.
/// Считайте, что время входа в стартовую вершину равно 0. Соседей каждой вершины обходите в порядке увеличения номеров.
/// </summary>
public static class HTimeToGoOut
{
    private static int _time = -1;
    private static List<Colors> _colors = new();
    private static int[] _entry = null!;
    private static int[] _leave = null!;
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var counts = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var (n, m) = (counts[0], counts[1]);

        var graph = ReadVertices(m, reader);

        _colors = Enumerable.Range(0, n + 1).Select(_ => Colors.White).ToList();
        _entry = new int[n + 1];
        _leave = new int[n + 1];

        Dfs(1, graph);

        for (var i = 1; i < n + 1; i++)
            Console.WriteLine($"{_entry[i]} {_leave[i]}");
    }

    private static Dictionary<int, List<int>> ReadVertices(int verticesCount, TextReader reader)
    {
        var graph = new Dictionary<int, List<int>>();
        for (var i = 0; i < verticesCount; i++)
        {
            var read = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
            if (graph.ContainsKey(read[0]))
            {
                graph[read[0]].Add(read[1]);
                continue;
            }

            graph.Add(read[0], new List<int> {read[1]});
        }

        return graph;
    }

    private static IEnumerable<int> GetOutgoingEdges(IReadOnlyDictionary<int, List<int>> graph, int vertex) =>
        !graph.ContainsKey(vertex) ? Enumerable.Empty<int>() : graph[vertex];

    private static void Dfs( int vertex, IReadOnlyDictionary<int, List<int>> edges)
    {
        _time += 1;
        _entry[vertex] = _time;
        _colors[vertex] = Colors.Gray;

        foreach (var w in GetOutgoingEdges(edges, vertex).OrderBy(it => it))
        {
            if (_colors[w] is Colors.White)
                Dfs(w, edges);
        }

        _time += 1;
        _leave[vertex] = _time;
    }
}