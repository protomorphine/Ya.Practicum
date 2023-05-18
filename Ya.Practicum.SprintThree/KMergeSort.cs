namespace Ya.Practicum.SprintThree;

public static class KMergeSort
{
    public static void Execute()
    {
        var a = new List<int> { 1, 4, 9, 2, 10, 11 };
        var b = Merge(a, 0, 3, 6);
        var expectedMergeResult = new List<int> {1, 2, 4, 9, 10, 11};
        Console.WriteLine(b.SequenceEqual(expectedMergeResult));
        var c = new List<int> {1, 4, 2, 10, 1, 2};
        MergeSort(c, 0, 6);
        var expectedMergeSortResult = new List<int> {1, 1, 2, 2, 4, 10};
        Console.WriteLine(c.SequenceEqual(expectedMergeSortResult));
    }
    
    public static void MergeSort(List<int> array, int left, int right)
    {
        
    }

    public static List<int> Merge(List<int> array, int left, int mid, int right)
    {
        var arr = array.ToArray();

        var lPart = arr[left..mid];
        var rPart = arr[mid..right];
        var res = new int[array.Count];
        
        int l = 0, r = 0, k = 0;
        while (l < lPart.Length && r < rPart.Length)
        {
            
            if (lPart[l] <= rPart[r])
            {
                res[k] = lPart[l];
                l++;
            }
            else
            {
                res[k] = rPart[r];
                r++;
            }
            k++;
        }
        
        while (l < lPart.Length)
        {
            res[k] = lPart[l]; // перенеси оставшиеся элементы left в result
            l++;
            k++;
        }
        while (r < rPart.Length)
        {
            res[k] = rPart[r]; // перенеси оставшиеся элементы right в result
            r++;
            k++;
        }

        return res.ToList();
    }
}