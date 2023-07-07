namespace Ya.Practicum.SprintSix;

/// <summary>
/// Дан ациклический ориентированный граф (так называемый DAG, directed acyclic graph).
/// Найдите его топологическую сортировку, то есть выведите его вершины в таком порядке,
/// что все рёбра графа идут слева направо. У графа может быть несколько подходящих перестановок вершин.
/// Вам надо найти любую топологическую сортировку.
/// </summary>
public static class JTolologicalSort
{
    private static List<Colors> _colors = new();
    
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var counts = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var (n, m) = (counts[0], counts[1]);
        
        var graph = ReadVertices(m, reader);
        
        _colors = Enumerable.Range(0, n + 1).Select(_ => Colors.White).ToList();
        var stack = new Stack<int>();

        for (var i = 1; i < n + 1; i++)
        {
            if (_colors[i] is Colors.White)
                Dfs(i, graph, stack);
        }
        
        Console.WriteLine(string.Join(" ", stack));

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

    private static void Dfs( int vertex, IReadOnlyDictionary<int, List<int>> edges, Stack<int> stack)
    {
        _colors[vertex] = Colors.Gray;

        foreach (var w in GetOutgoingEdges(edges, vertex))
        {
            if (_colors[w] is Colors.White)
                Dfs(w, edges, stack);
        }
        
        stack.Push(vertex);
    }
}