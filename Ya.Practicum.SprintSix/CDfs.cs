namespace Ya.Practicum.SprintSix;

/// <summary>
/// Задан неориентированный граф. Обойдите с помощью DFS все вершины,
/// достижимые из заданной вершины s, и выведите их в порядке обхода, если начинать обход из s.
/// </summary>
public static class CDfs
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var counts = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var (n, m) = (counts[0], counts[1]);
        
        var adjustmentList = ReadGraph(n, m, reader);

        var startVertex = int.Parse(reader.ReadLine()!);
        var colored = Enumerable.Range(0, n + 1).Select(_ => Colors.White).ToList();
        
        Dfs(colored, startVertex, adjustmentList);
    }

    private static List<List<int>> ReadGraph(int n, int m, TextReader reader)
    {
        var adjustmentList = new List<List<int>>();
        for (var i = 0; i < n + 1; i++)
            adjustmentList.Add(new List<int>());

        for (var i = 0; i < m; i++)
        {
            var read = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
            adjustmentList[read[0]].Add(read[1]);
            adjustmentList[read[1]].Add(read[0]);
        }

        return adjustmentList;
    }

    private static void Dfs(IList<Colors> colors, int vertex, IReadOnlyList<List<int>> edges)
    {
        if (colors[vertex] is not Colors.Gray)
            Console.Write(vertex + " ");
        
        colors[vertex] = Colors.Gray;

        foreach (var w in edges[vertex]
                     .Where(v => colors[v] is not Colors.Gray)
                     .OrderBy(it => it)) 
            Dfs(colors, w, edges);
    }
}

internal enum Colors
{
    White,
    Gray
} 