namespace Ya.Practicum.SprintSix;

/// <summary>
/// Алла пошла на стажировку в студию графического дизайна, где ей дали такое задание: для очень большого
/// числа ориентированных графов преобразовать их список рёбер в список смежности. Чтобы побыстрее решить эту задачу,
/// она решила автоматизировать процесс.
///Помогите Алле написать программу, которая по списку рёбер графа будет строить его список смежности.
/// </summary>
public static class AToAdjacencyList
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var counts = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var (n, m) = (counts[0], counts[1]);

        var vertices = Enumerable.Range(1, n).ToList();
        var edges = new List<KeyValuePair<int, int>>();
        var result = new List<KeyValuePair<int, List<int>>>();

        for (var i = 0; i < m; i++)
        {
            var read = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
            edges.Add(new KeyValuePair<int, int>(read[0], read[1]));
        }

        foreach (var vertex in vertices)
        {
            if (edges.Exists(it => it.Key == vertex))
            {
                result.Add(
                    new KeyValuePair<int, List<int>>(
                        edges.Count(it => it.Key == vertex),
                        edges.Where(it => it.Key == vertex).Select(it => it.Value).ToList()
                    ));
                continue;
            }

            result.Add(new KeyValuePair<int, List<int>>(0, Enumerable.Empty<int>().ToList()));
        }

        foreach (var pair in result)
            Console.WriteLine($"{pair.Key} {string.Join(" ", pair.Value)}");
    }
}