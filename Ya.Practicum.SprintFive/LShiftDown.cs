namespace Ya.Practicum.SprintFive;

/// <summary>
/// Напишите функцию, совершающую просеивание вниз в куче на максимум.
/// Гарантируется, что порядок элементов в куче может быть нарушен только элементом,
/// от которого запускается просеивание.
/// Функция принимает в качестве аргументов массив, в котором хранятся элементы кучи, и индекс элемента,
/// от которого надо сделать просеивание вниз. Функция должна вернуть индекс,
/// на котором элемент оказался после просеивания.
/// Также необходимо изменить порядок элементов в переданном в функцию массиве.
/// </summary>
public static class LShiftDown
{
    public static void Execute()
    {
        var sample = new List<int> {-1, 12, 1, 8, 3, 4, 7};
        Console.WriteLine(SiftDown(sample, 2) == 5);
    }

    private static int SiftDown(IList<int> array, int idx)
    {
        var left = idx * 2;
        var right = idx * 2 + 1;

        if (array.Count <= left)
            return idx;

        int largestIdx;
        if (right < array.Count && array[left] < array[right])
            largestIdx = right;
        else
            largestIdx = left;

        if (array[idx] > array[largestIdx])
            return idx;
        
        (array[idx], array[largestIdx]) = (array[largestIdx], array[idx]);
        return SiftDown(array, largestIdx);
    }
}