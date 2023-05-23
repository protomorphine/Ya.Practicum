﻿namespace Ya.Practicum.SprintThree.Finals;

/// <summary>
/// Алла ошиблась при копировании из одной структуры данных в другую.
/// Она хранила массив чисел в кольцевом буфере. Массив был отсортирован по возрастанию,
/// и в нём можно было найти элемент за логарифмическое время.
/// Алла скопировала данные из кольцевого буфера в обычный массив,
/// но сдвинула данные исходной отсортированной последовательности.
/// Теперь массив не является отсортированным.
/// Тем не менее, нужно обеспечить возможность находить в нем элемент за O(log N).
/// Можно предполагать, что в массиве только уникальные элементы.
///
/// ===================================================================================================================
/// https://contest.yandex.ru/contest/23815/run-report/87562464/
/// ===================================================================================================================
/// -- ПРИНЦИП РАБОТЫ --
/// Данный алгоритм выплняет поиск по "сломанной" последователнсоти.
/// "Сломанная" в данном случае означает что до некого индекса значения возрастают, затем упорядочивание "ломается"
/// и элементы снова начинают возрастать. Например последовательность [5, 6, 7, 1, 2, 3, 4] имеет "перелом" на элементе 7.
///
/// В данной задаче для поиска "перелома" используется функция FindPivot, которая с помощью рекурсивного бинарного
/// поиска находит индекс "перелома" последовательности.
///
/// Зная индекс перелома можно разделить последовательность на две, при этом каждая из подпоследовательнсотей
/// будет упорядочена по возрастанию. Для поиска индекса искогомо элемента выполняется бинарный поиск.
/// 
/// -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
///
/// По условию задачи входная последовательнсоть имеет всего 1 "перелом", следовательно, после нахождения
/// индекса этого "перелома", последовательность можно разделить на две отсортированные последовательности,
/// и уже в зависимости от расположения искомого элемента относительно "перелома", осуществляется бинарный поиск по
/// необходимой подпоследовательности.
///
/// -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
///
/// 1) FindPivot - осущесталяет бинарный поиск "перелома" последовательности. Выполняется за O(logN).
/// 2) BinarySearch - осуществляет бинарный поиск по последовательности. Выполянется за O(logN).
///
/// Следовательно, в наихудщем случае будут выполнены два бинарных поиска, в связи с этим алгоритм выполнится за o(logN).
/// 
/// -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
///
/// Данный алгорит не требует дополнительных аллокаций и следовательно, пространственная сложность решения - O(1).
/// </summary>
public static class ABrokenSearch
{
    public static void Execute()
    {
        var arr = new List<int> {19, 21, 100, 101, 1, 4, 5, 7, 12};

        Console.WriteLine(BrokenSearch(arr, 5));
    }

    /// <summary>
    /// Осуществляет поиск в "сломаном" списке чисел.
    /// </summary>
    /// <param name="array">Список чисел.</param>
    /// <param name="el">Искомый элемент.</param>
    /// <returns>Индекс искомого элемента в списке, если элемент не найден - возвращает -1.</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    // Вызывается из вне
    public static int BrokenSearch(List<int> array, int el)
    {
        var pivot = FindPivot(array, 0, array.Count - 1);

        if (array[pivot] == el)
            return pivot;

        // ReSharper disable once UseIndexFromEndExpression
        // У Яндекса "отличный" тренажер, который не знает про тип Index
        return array[pivot] < el && array[array.Count - 1] >= el
            ? BinarySearch(array, el, pivot, array.Count - 1)
            : BinarySearch(array, el, 0, pivot - 1);
    }

    /// <summary>
    /// Реализация бинарного поиска.
    /// </summary>
    /// <param name="arr">Список чисел.</param>
    /// <param name="el">Искомый элемент.</param>
    /// <param name="left">Указатель на начало интервала для поиска.</param>
    /// <param name="right">Указатель на конец интервала для поиска.</param>
    /// <returns>Индекс искомого элемента в списке, если элемент не найден - возвращает -1.</returns>
    // ReSharper disable once SuggestBaseTypeForParameter
    // У Яндекса "отличный" тренажер, который не может найти IReadOnlyList<T> в System.Collections.Generic
    private static int BinarySearch(List<int> arr, int el, int left = 0, int right = 0)
    {
        if (left > right)
            return -1;

        var mid = (left + right) / 2;

        if (arr[mid] == el)
            return mid;

        return arr[mid] > el
            ? BinarySearch(arr, el, left, mid - 1)
            : BinarySearch(arr, el, mid + 1, right);
    }

    /// <summary>
    /// Находит "перелом" списка с помощью бинарного поиска.
    /// </summary>
    /// <param name="array">Список чисел.</param>
    /// <param name="left">Указатель на начало интервала для поиска.</param>
    /// <param name="right">Указатель на конец интервала для поиска.</param>
    /// <returns>Индекс "перелома" списка.</returns>
    // ReSharper disable once SuggestBaseTypeForParameter
    // У Яндекса "отличный" тренажер, который не может найти IReadOnlyList<T> в System.Collections.Generic
    private static int FindPivot(List<int> array, int left, int right)
    {
        if (left == right)
            return left;

        var mid = (left + right) / 2;

        return array[mid] >= array[left]
            ? FindPivot(array, mid + 1, right)
            : FindPivot(array, left, mid);
    }
}