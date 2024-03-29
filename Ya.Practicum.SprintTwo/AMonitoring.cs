﻿namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Алла получила задание, связанное с мониторингом работы различных серверов.
/// Требуется понять, сколько времени обрабатываются определённые запросы на конкретных серверах.
/// Эту информацию нужно хранить в матрице, где номер столбца соответствуют идентификатору запроса,
/// а номер строки — идентификатору сервера. Алла перепутала строки и столбцы местами. С каждым бывает.
/// Помогите ей исправить баг.
///
/// Есть матрица размера m × n. Нужно написать функцию, которая её транспонирует.
///
/// Транспонированная матрица получается из исходной заменой строк на столбцы.
///
/// Например, для матрицы А (слева) транспонированной будет следующая матрица (справа):
///
/// 1 2 3     ->      1 0 7 2
/// 0 2 6     ->      2 2 4 7
/// 7 4 1     ->      3 6 1 0
/// 2 7 0     ->
/// </summary>
public static class AMonitoring
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var n = int.Parse(reader.ReadLine()!);
        var m = int.Parse(reader.ReadLine()!);

        var matrix = new List<List<int>>();

        for (var i = 0; i < n; i++)
            matrix.Add(reader.ReadLine()!
                .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

        var transposed = CreateEmptyMatrix(m, n);

        for (var i = 0; i < matrix.Count; i++)
        {
            for (var j = 0; j < matrix[i].Count; j++)
                transposed[j][i] = matrix[i][j];
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        foreach (var row in transposed)
            writer.WriteLine(string.Join(" ", row));
    }

    private static int[][] CreateEmptyMatrix(int rows, int columns)
    {
        var matrix = new int[rows][];
        for (var i = 0; i < rows; i++)
            matrix[i] = new int[columns];
        return matrix;
    }
}