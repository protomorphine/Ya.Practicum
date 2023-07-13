namespace Ya.Practicum.SprintSix.Finals;

/// <summary>
/// Тимофей решил соединить все компьютеры в своей компании в единую сеть.
/// Для этого он придумал построить минимальное остовное дерево, чтобы эффективнее использовать ресурсы.
/// Но от начальства пришла новость о том, что выделенный на сеть бюджет оказался очень большим и
/// его срочно надо израсходовать. Поэтому Тимофея теперь интересуют не минимальные, а максимальные остовные деревья.
/// Он поручил вам найти вес такого максимального остовного дерева в неориентированном графе, который задаёт схему офиса.
/// ====================================================================================================================
/// https://contest.yandex.ru/contest/25070/run-report/88991205/
/// ====================================================================================================================
/// -- Принцип работы алгоритма --
/// В качестве представления графа в памяти используется список смежности.
///
/// Вес максимального остового дерева вычисляется с помощью алгоритма Прима.
/// Выполнение алгоритма начием с вершины 1, складывая веса ребер большего веса.
/// 
/// В качестве множества уже добавленных в остов вершин используется приоритетная очередь
/// и реализация метода CompareTo(Edge? other);
/// 
/// -- Доказательство корректности --
/// Корректность работы алгоритма обусловлена использованием приоритетной очереди и корректным выбором
/// функции-компаратора для двух ребер, позволяющей определить ребро большего веса.
/// 
/// -- Временная сложность --
/// Временная сложность работы алгоритма Прима - O(|V| * |E|),
/// где |V| - кол-во вершин, |E| - кол-во ребер.
///
/// Но из-за использования приоритетной очереди, в котором получение
/// и удаление элемента происходит за O(logN)
/// (https://stackoverflow.com/questions/74180472/what-is-the-time-complexity-for-priorityqueue-added-in-net-6),
/// пропадает необходимость искать
/// ребро с большим весом, мы его получаем сразу по приоритету.
/// 
/// Таким образом временная сложность программы O(|E| * log|V|).
/// 
/// -- Пространственная сложность --
/// O(|V| + |E|) на хранение списка смежности, а так же O(|V|) для приоритетной очереди.
/// Итого - O(|V| + |E|) + O(|V|)
/// </summary>
public static class AExpensiveNetwork
{
    /// <summary>
    /// Множество вершин, уже добавленных в остов.
    /// </summary>
    private static readonly PriorityQueue<Edge, Edge> Added = new();

    /// <summary>
    /// Множество вершины, ещё не добавленных в остов.
    /// </summary>
    private static bool[] _notAdded = null!;
    private static int _notAddedCounter;

    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var counts = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var (n, m) = (counts[0], counts[1]);

        _notAdded = Enumerable.Range(0, n + 1).Select(_ => true).ToArray();
        _notAddedCounter = n;

        var graph = ReadGraph(m, reader);

        var mst = FindMst(graph);

        Console.WriteLine(_notAddedCounter > 0 || n - 1 > m ? "Oops! I did it again" : mst);
    }

    /// <summary>
    /// Считывает граф из ридера.
    /// </summary>
    /// <param name="m">Количество ребер графа.</param>
    /// <param name="reader">Экземпляр ридера.</param>
    /// <returns>Список смежности (представление графа в памяти).</returns>
    private static Dictionary<int, List<Edge>> ReadGraph(int m, TextReader reader)
    {
        var graph = new Dictionary<int, List<Edge>>();

        for (var i = 0; i < m; i++)
        {
            var read = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();

            if (!graph.ContainsKey(read[0]))
                graph.Add(read[0], new List<Edge>());

            if (!graph.ContainsKey(read[1]))
                graph.Add(read[1], new List<Edge>());

            graph[read[0]].Add(new Edge(read[0], read[1], read[2]));
            graph[read[1]].Add(new Edge(read[1], read[0], read[2]));
        }

        return graph;
    }

    /// <summary>
    /// Добавляет вершину для вычисления веса максимального остового дерева.
    /// </summary>
    /// <param name="v">Номер вершины.</param>
    /// <param name="graph">Список смежности (представление графа в памяти).</param>
    private static void AddVertex(int v, IReadOnlyDictionary<int, List<Edge>> graph)
    {
        _notAdded[v] = false;
        _notAddedCounter--;

        if (!graph.TryGetValue(v, out var edges))
            return;

        foreach (var edge in edges.Where(edge => _notAdded[edge.To]))
            Added.Enqueue(edge, edge);
    }

    /// <summary>
    /// Находит вес максимального остового дерева.
    /// </summary>
    /// <param name="graph">Список смежности (представление графа в памяти).</param>
    /// <returns>Вес максимального остового дерева.</returns>
    private static int FindMst(IReadOnlyDictionary<int, List<Edge>> graph)
    {
        AddVertex(1, graph);
        var mst = 0;

        while (_notAddedCounter > 0 && Added.Count > 0)
        {
            var edge = Added.Dequeue();

            if (!_notAdded[edge.To])
                continue;

            mst += edge.Weight;
            AddVertex(edge.To, graph);
        }

        return mst;
    }
}

/// <summary>
/// Представление ребра графа.
/// </summary>
public class Edge : IComparable<Edge>
{
    /// <summary>
    /// Вершина начала ребра.
    /// </summary>
    public int From { get; }

    /// <summary>
    /// Вершина окончания ребра.
    /// </summary>
    public int To { get; }

    /// <summary>
    /// Вес ребра.
    /// </summary>
    public int Weight { get; }

    /// <summary>
    /// Создает новый экземпляр <see cref="Edge"/>
    /// </summary>
    public Edge(int from, int to, int weight)
    {
        From = from;
        To = to;
        Weight = weight;
    }

    /// <inheritdoc />
    public int CompareTo(Edge? other)
    {
        if (other != null)
            return other.Weight - Weight;

        return 0;
    }
}