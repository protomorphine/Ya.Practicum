namespace Ya.Practicum.SprintOne;

/// <summary>
/// Дана матрица. Нужно написать функцию, которая для элемента возвращает всех его соседей.
/// Соседним считается элемент, находящийся от текущего на одну ячейку влево, вправо, вверх или вниз.
/// Диагональные элементы соседними не считаются.
/// </summary>
public static class CNeighbours
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var rows = int.Parse(reader.ReadLine()!);
        var cols = int.Parse(reader.ReadLine()!);

        var matrix = new List<List<int>>();
        for (var _ = 0; _ < rows; _++)
            matrix.Add(reader.ReadLine()!
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

        var rowId = int.Parse(reader.ReadLine()!);
        var colId = int.Parse(reader.ReadLine()!);

        var xLimit = matrix[0].Count - 1;
        var yLimit = matrix.Count - 1;

        var res = new List<int>();

        if (colId + 1 <= xLimit)
            res.Add(matrix[rowId][colId + 1]);

        if (rowId - 1 >= 0)
            res.Add(matrix[rowId - 1][colId]);

        if (colId - 1 >= 0)
            res.Add(matrix[rowId][colId - 1]);

        if (rowId + 1 <= yLimit)
            res.Add(matrix[rowId + 1][colId]);

        res.Sort();

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(string.Join(' ', res));
    }
}