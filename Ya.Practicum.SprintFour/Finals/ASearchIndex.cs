namespace Ya.Practicum.SprintFour.Finals;

/// <summary>
/// <b>В этой задаче можно пользоваться хеш-таблицами из стандартных библиотек.</b><br/><br/>
/// Тимофей пишет свою поисковую систему.<br/>
/// Имеется n документов, каждый из которых представляет собой текст из слов.
/// По этим документам требуется построить поисковый индекс.
/// На вход системе будут подаваться запросы.
/// Запрос —– некоторый набор слов. По запросу надо вывести 5 самых релевантных документов.
/// <br/><br/>
/// Релевантность документа оценивается следующим образом: для каждого уникального слова
/// из запроса берётся число его вхождений в документ, полученные числа для всех слов из запроса суммируются.
/// Итоговая сумма и является релевантностью документа. Чем больше сумма, тем больше документ подходит под запрос.
/// <br/><br/>
/// Сортировка документов на выдаче производится по убыванию релевантности.
/// Если релевантности документов совпадают —– то по возрастанию
/// их порядковых номеров в базе (то есть во входных данных).
/// <br/><br/>
/// Подумайте над случаями, когда запросы состоят из слов, встречающихся в малом количестве документов.
/// Что если одно слово много раз встречается в одном документе?
/// </summary>
public static class ASearchIndex
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var documents = ReadList(reader, int.Parse(reader.ReadLine()!));
        var globalIndex = CreateGlobalIndex(documents);

        var queriesCount = int.Parse(reader.ReadLine()!);
        for (var i = 0; i < queriesCount; i++)
            Console.WriteLine(string.Join(" ", Search(reader.ReadLine()!, globalIndex)));
    }

    /// <summary>
    /// Читает массив строк из <see cref="TextReader"/>
    /// </summary>
    /// <param name="reader">Экземпляр ридера.</param>
    /// <param name="lenght">Длина массива.</param>
    /// <returns>Массив считанных строк.</returns>
    private static List<string> ReadList(TextReader reader, int lenght)
    {
        var list = new List<string>();
        for (var i = 0; i < lenght; i++)
            list.Add(reader.ReadLine()!);

        return list;
    }

    /// <summary>
    /// Создает глобальный индекс.
    /// Ключ индекса - слово.
    /// Значение - Словарь (ключ = номер документа, значение = количество вхождений слова).
    /// </summary>
    /// <param name="documents">Список строк, для которых строится глобальный индекс.</param>
    /// <returns>Глобальный индекс.</returns>
    private static Dictionary<string, Dictionary<int, int>> CreateGlobalIndex(IReadOnlyList<string> documents)
    {
        var index = new Dictionary<string, Dictionary<int, int>>();

        for (var i = 0; i < documents.Count; i++)
        {
            var documentNumber = i + 1;
            foreach (var word in documents[i].Split(' '))
            {
                if (!index.ContainsKey(word))
                {
                    index.Add(word, new Dictionary<int, int> { { documentNumber, 1 } });
                    continue;
                }

                if (!index[word].ContainsKey(documentNumber))
                {
                    index[word].Add(documentNumber, 1);
                    continue;
                }

                index[word][documentNumber]++;
            }
        }

        return index;
    }

    /// <summary>
    /// Создает индекс релевантности.
    /// Ключ индекса - номер документа.
    /// Значение - релевантность.
    /// </summary>
    /// <param name="globalIndex">Глобальный индекс, в котором происходит поиск.</param>
    /// <param name="words">Список уникальный слов запроса.</param>
    /// <returns>Индекс релевантности.</returns>
    private static Dictionary<int, int> CreateRelevanceIndex(
        IReadOnlyDictionary<string, Dictionary<int, int>> globalIndex,
        HashSet<string> words
    )
    {
        var relevanceIndex = new Dictionary<int, int>();
        foreach (var word in words)
        {
            if (!globalIndex.TryGetValue(word, out var globalIndexEntry))
                continue;

            foreach (var (documentNumber, wordEntries) in globalIndexEntry)
            {
                if (relevanceIndex.ContainsKey(documentNumber))
                {
                    relevanceIndex[documentNumber] += wordEntries;
                    continue;
                }

                relevanceIndex.Add(documentNumber, wordEntries);
            }
        }

        return relevanceIndex;
    }

    /// <summary>
    /// Осуществляет поиск в глобальном индексе.
    /// </summary>
    /// <param name="query">Поисковый запрос.</param>
    /// <param name="globalIndex">Глобальный индекс.</param>
    /// <param name="resultLimit">Максимальное количество результатов (по умолчанию = 5).</param>
    /// <returns>Номера документов, отсортированных по релевантности.</returns>
    private static IEnumerable<int> Search(
        string query,
        IReadOnlyDictionary<string, Dictionary<int, int>> globalIndex,
        int resultLimit = 5
    )
    {
        var uniqWords = query.Split(' ').ToHashSet();
        var relevanceIndex = CreateRelevanceIndex(globalIndex, uniqWords);

        return relevanceIndex
            .OrderByDescending(it => it.Value)
            .ThenBy(it => it.Key)
            .Select(it => it.Key)
            .Take(resultLimit)
            .ToList();
    }
}