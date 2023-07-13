namespace Ya.Practicum.SprintSix.Finals;

/// <summary>
/// В стране X есть n городов, которым присвоены номера от 1 до n. Столица страны имеет номер n.
/// Между городами проложены железные дороги.
/// Однако дороги могут быть двух типов по ширине полотна. Любой поезд может ездить только по одному типу полотна.
/// Условно один тип дорог помечают как R, а другой как B.
/// То есть если маршрут от одного города до другого имеет как дороги типа R, так и дороги типа B,
/// то ни один поезд не сможет по этому маршруту проехать. От одного города до другого можно проехать
/// только по маршруту, состоящему исключительно из дорог типа R или только из дорог типа B.
/// Но это ещё не всё. По дорогам страны X можно двигаться только от города с меньшим номером к городу с большим номером.
/// Это объясняет большой приток жителей в столицу, у которой номер n.
/// Карта железных дорог называется оптимальной, если не существует пары городов A и B такой,
/// что от A до B можно добраться как по дорогам типа R, так и по дорогам типа B.
/// Иными словами, для любой пары городов верно, что от города с меньшим номером до города с бОльшим
/// номером можно добраться по дорогам только какого-то одного типа или же что маршрут построить вообще нельзя.
/// Выясните, является ли данная вам карта оптимальной.
/// ====================================================================================================================
/// https://contest.yandex.ru/contest/25070/run-report/88997920/
/// ====================================================================================================================
/// -- Принцип работы алгоритма --
/// Для корректной работы этого алгоритма составляется список смежность (один из вариантов представления графа в памяти)
/// Ребра, помеченные символом "R" разворачиваются, т.е. начало и конец меняются местами.
///
/// При таком подходе задача сводится к поиску цикла в графе.
/// Поиск цикла реализован за счет алгоритма  DFS.
/// Если при проверке смежных по исходящим дугам вершин очередная вершина окажется серой — цикл есть.
/// 
/// -- Доказательство корректности --
/// Корректность решения задачи обуслеовлена использованием алгоритма DFS для поиска циклов,
/// а так же за счет "разворота" определенных ребер.
/// "Разворот" ребер обусловлен условием задачи (То есть если маршрут от одного города до другого имеет как
/// дороги типа R, так и дороги типа B,то ни один поезд не сможет по этому маршруту проехать).
/// 
/// -- Временная сложность --
/// Врмеенная сложность алгоритма обхода графа в глубину (DFS)
/// O(|V| + |E|), где |V| - кол-во вершин.
///                   |E| - кол-во ребер.
/// 
/// -- Пространственная сложность --
/// O(|V| + |E|) на хранение списка смежности, а так же O(|V|) на хранение списка цветов вершин.
/// Итого - O(|V| + |E|) + O(|V|)
/// </summary>
public static class BRailways
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var cities = int.Parse(reader.ReadLine()!);

        var graph = ReadGraph(cities, reader);

        Console.WriteLine(IsOptimal(cities, graph) ? "YES" : "NO");
    }

    /// <summary>
    /// Считывает граф железнодорожных путей из stdin.
    /// </summary>
    /// <param name="cities">Количество городов.</param>
    /// <param name="reader">Экземпляр ридера.</param>
    /// <returns>Граф ЖД путей.</returns>
    private static Dictionary<int, List<int>> ReadGraph(int cities, TextReader reader)
    {
        var graph = new Dictionary<int, List<int>>();
        for (var city = 1; city <= cities - 1; city++)
        {
            var read = reader.ReadLine()!;
            AddGraphEntryIfNotExist(city, graph);

            for (var edge = 0; edge < read.Length; edge++)
                AddEdge(read, city, edge, graph);
        }

        return graph;
    }

    /// <summary>
    /// Добавляет ребро к графу.
    /// Если ребро помечено символом "B" - просто доабвляем его в список смежности.
    /// Иначе (ребро помечено символом "R") - "переворачиваем" ребро.
    /// </summary>
    /// <param name="read">Считанная строка ридера.</param>
    /// <param name="cityFrom">Город (начало ребра).</param>
    /// <param name="cityTo">Город (окончание ребра).</param>
    /// <param name="graph">Список смежности (представление графа в памяти).</param>
    private static void AddEdge(string read, int cityFrom, int cityTo, IDictionary<int, List<int>> graph)
    {
        if (read[cityTo] is 'B')
        {
            graph[cityFrom].Add(cityFrom + cityTo + 1);
            return;
        }

        AddGraphEntryIfNotExist(cityFrom + cityTo + 1, graph);
        graph[cityFrom + cityTo + 1].Add(cityFrom);
    }

    /// <summary>
    /// При необходимости добавляет в словарь элемент с указанным ключом.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <param name="dict">Словарь.</param>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    /// <typeparam name="TValue">Тип значения в словаре.</typeparam>
    private static void AddGraphEntryIfNotExist<TKey, TValue>(TKey key, IDictionary<TKey, TValue> dict)
        where TKey : notnull
        where TValue : new()
    {
        if (!dict.ContainsKey(key))
            dict.Add(key, new TValue());
    }

    /// <summary>
    /// Возвращает исходящие ребра из вершины графа.
    /// </summary>
    /// <param name="graph">Список смежности (представление графа в памяти).</param>
    /// <param name="vertex">Вершина.</param>
    /// <returns>Список вершин, в которые можно попасть из vertex</returns>
    private static IEnumerable<int> GetOutgoingEdges(IReadOnlyDictionary<int, List<int>> graph, int vertex) =>
        !graph.ContainsKey(vertex) ? Enumerable.Empty<int>() : graph[vertex];

    /// <summary>
    /// Возвращает флаг наличия цикла в графе.
    /// </summary>
    /// <param name="colors">Список вершин графа, представляющий состояние каждой вершины. <seealso cref="Color"/></param>
    /// <param name="city">Город (вершина графа), откуда запускается алгоритм DFS.</param>
    /// <param name="graph">Список смежности (представление графа в памяти).</param>
    /// <returns>Булевый флаг наличия цикла в графе.</returns>
    private static bool IsCycled(IList<Color> colors, int city, IReadOnlyDictionary<int, List<int>> graph)
    {
        var stack = new Stack<int>();
        stack.Push(city);

        while (stack.Count > 0)
        {
            var fromStack = stack.Pop();

            if (colors[fromStack] is not Color.White)
            {
                colors[fromStack] = Color.Black;
                continue;
            }

            colors[fromStack] = Color.Gray;
            stack.Push(fromStack);

            foreach (var edge in GetOutgoingEdges(graph, fromStack))
            {
                switch (colors[edge])
                {
                    case Color.White:
                        stack.Push(edge);
                        continue;
                    case Color.Gray:
                        return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Возвращает флаг оптимальности карты железных дорог.
    /// </summary>
    /// <param name="cities">Количество городов.</param>
    /// <param name="graph">Список смежности (представление графа в памяти).</param>
    /// <returns>Булевый флаг оптимальности карты железных дорог.</returns>
    private static bool IsOptimal(int cities, IReadOnlyDictionary<int, List<int>> graph)
    {
        var colors = Enumerable.Range(0, cities + 1).Select(_ => Color.White).ToList();
        for (var i = 1; i < cities; i++)
        {
            if (colors[i] is not Color.White)
                continue;

            if (IsCycled(colors, i, graph))
                return false;
        }

        return true;
    }
}

/// <summary>
/// Определяет состояние вершины графа.
/// </summary>
internal enum Color
{
    /// <summary>
    /// Белый цвет.
    /// Вершина не была посещена.
    /// </summary>
    White,

    /// <summary>
    /// Серый цвет.
    /// Вершина была посещена, но не обработана до конца.
    /// </summary>
    Gray,

    /// <summary>
    /// Черный цвет.
    /// Вершина обработана полностью.
    /// </summary>
    Black
}