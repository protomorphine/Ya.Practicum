using Ya.Practicum.Common;

namespace Ya.Practicum.SprintFive.Finals;

/// <summary>
/// В данной задаче необходимо реализовать сортировку кучей. При этом кучу необходимо реализовать самостоятельно,
/// использовать имеющиеся в языке реализации нельзя. Сначала рекомендуется решить задачи про просеивание вниз и вверх.
/// Тимофей решил организовать соревнование по спортивному программированию, чтобы найти талантливых стажёров.
/// Задачи подобраны, участники зарегистрированы, тесты написаны. Осталось придумать, как в конце соревнования будет
/// определяться победитель.
/// Каждый участник имеет уникальный логин. Когда соревнование закончится, к нему будут привязаны два показателя:
/// количество решённых задач Pi и размер штрафа Fi.
/// Штраф начисляется за неудачные попытки и время, затраченное на задачу.
/// Тимофей решил сортировать таблицу результатов следующим образом: при сравнении двух участников выше будет идти тот,
/// у которого решено больше задач. При равенстве числа решённых задач первым идёт участник с меньшим штрафом.
/// Если же и штрафы совпадают, то первым будет тот, у которого логин идёт раньше в алфавитном (лексикографическом) порядке.
/// Тимофей заказал толстовки для победителей и накануне поехал за ними в магазин.
/// В своё отсутствие он поручил вам реализовать алгоритм сортировки кучей (англ. Heapsort) для таблицы результатов.
/// </summary>
public static class AHeapSort
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var count = ReadInt(reader);
        var participants = ReadList(reader, count, args =>
            new Participant(args[0], int.Parse(args[1]), int.Parse(args[2])));
        
        HeapSort(participants);

        foreach (var participant in participants) 
            Console.WriteLine(participant.Login);
    }
    
    /// <summary>
    /// Читает число (int) из ридера.
    /// </summary>
    /// <param name="reader">Ридер данных.</param>
    /// <returns>Число.</returns>
    private static int ReadInt(TextReader reader) => int.Parse(reader.ReadLine()!);

    /// <summary>
    /// Читает последовательность из ридера.
    /// </summary>
    /// <param name="reader">Ридер.</param>
    /// <param name="count">Размер последовательности.</param>
    /// <param name="factory">Делегат создания экземпляра элемента последовательсноти из сичтанной ридером строки.</param>
    /// <typeparam name="T">Тип элемента последовательности.</typeparam>
    /// <returns>Последовательность элементов.</returns>
    private static List<T> ReadList<T>(TextReader reader, int count, Func<string[], T> factory)
    {
        var list = new List<T>();

        for (var i = 0; i < count; i++)
            list.Add(factory.Invoke(reader.ReadLine()!.Split(' ')));

        return list;
    }

    /// <summary>
    /// Выполняет пирамидальную сортировку.
    /// </summary>
    /// <param name="list">Сортируемая последовательность.</param>
    /// <typeparam name="T">Тип элемента сортируемой последовательности.</typeparam>
    private static void HeapSort<T>(IList<T> list) where T : IComparable<T>
    {
        for (var i = list.Count / 2 - 1; i >= 0; i--)
            Shift(list, list.Count, i);
        
        for (var i = list.Count - 1; i >= 0; i--)
        {
            (list[0], list[i]) = (list[i], list[0]);
            
            Shift(list, i);
        }
    }
    
    /// <summary>
    /// Выполняет просеивание кучи.
    /// </summary>
    /// <param name="heap">Куча.</param>
    /// <param name="heapSize">Размер кучи.</param>
    /// <param name="rootIndex">Индекс начала просеивания.</param>
    /// <typeparam name="T">Тип элемента в куче.</typeparam>
    private static void Shift<T>(IList<T> heap, int heapSize, int rootIndex = 0) where T : IComparable<T>
    {
        var largest = rootIndex;
        
        var left = 2 * rootIndex + 1;
        var right = 2 * rootIndex + 2;
        
        if (left < heapSize && heap[left].CompareTo(heap[largest]) > 0)
            largest = left;
        
        if (right < heapSize && heap[right].CompareTo(heap[largest]) > 0)
            largest = right;

        if (largest == rootIndex) 
            return;
        
        (heap[rootIndex], heap[largest]) = (heap[largest], heap[rootIndex]);
        
        Shift(heap, heapSize, largest);
    }
}