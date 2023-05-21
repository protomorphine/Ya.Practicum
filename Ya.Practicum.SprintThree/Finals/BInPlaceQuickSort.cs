namespace Ya.Practicum.SprintThree.Finals;

public static class BInPlaceQuickSort
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var participants = new List<Participant>();
        var count = int.Parse(reader.ReadLine()!);
        for (var i = 0; i < count; i++)
        {
            var data = reader.ReadLine()!.Split(' ');
            participants.Add(new Participant(data[0], int.Parse(data[1]), int.Parse(data[2])));
        }

        QuickSort(participants, 0, count - 1);

        foreach (var login in participants.Select(p => p.Login))
            Console.WriteLine(login);
    }

    private static void QuickSort<T>(IList<T> arr, int left, int right) where T : IComparable<T>
    {
        if (left > right)
            return;

        var pivot = arr[(left + right) / 2];

        var lPointer = left;
        var rPointer = right;

        while (lPointer <= rPointer)
        {
            if (arr[lPointer].CompareTo(pivot) < 0)
            {
                lPointer++;
                continue;
            }

            if (arr[rPointer].CompareTo(pivot) > 0)
            {
                rPointer--;
                continue;
            }

            (arr[lPointer], arr[rPointer]) = (arr[rPointer], arr[lPointer]);
            lPointer++;
            rPointer--;
        }

        QuickSort(arr, left, rPointer);
        QuickSort(arr, lPointer, right);
    }
}

public class Participant : IComparable<Participant>
{
    public string Login { get; }

    public int SolvedTasks { get; }

    public int Fine { get; }

    public Participant(string login, int solvedTasks, int fine)
    {
        Login = login;
        SolvedTasks = solvedTasks;
        Fine = fine;
    }

    public int CompareTo(Participant? other)
    {
        if (ReferenceEquals(this, other))
            return 0;

        if (ReferenceEquals(null, other))
            return 1;

        if (SolvedTasks == other.SolvedTasks)
            return Fine == other.Fine
                ? string.Compare(Login, other.Login, StringComparison.CurrentCulture)
                : Fine.CompareTo(other.Fine);

        return other.SolvedTasks.CompareTo(SolvedTasks);
    }
}