namespace Ya.Practicum.SprintThree.Finals;

public static class ABrokenSearch
{
    public static void Execute()
    {
        var arr = new List<int> {19, 21, 100, 101, 1, 4, 5, 7, 12};

        Console.WriteLine(BrokenSearch(arr, 5));
    }

    public static int BrokenSearch(List<int> array, int el)
    {
        var pivot = FindPivot(array, 0, array.Count - 1);

        if (array[pivot] == el)
            return pivot;

        return array[pivot] < el && array[array.Count - 1] >= el
            ? BinarySearch(array, el, pivot, array.Count - 1)
            : BinarySearch(array, el, 0, pivot - 1);
    }

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

    private static int FindPivot(List<int> array, int left = 0, int right = 0, int lastMid = 0)
    {
        if (left == right)
            return left;

        var mid = (left + right) / 2;

        return array[mid] >= array[left]
            ? FindPivot(array, mid + 1, right)
            : FindPivot(array, left, mid);
    }
}