namespace Ya.Practicum.SprintSeven.Finals;

/// <summary>
/// Расстоянием Левенштейна между двумя строками s и t называется количество атомарных изменений, с
/// помощью которых можно одну строку превратить в другую. Под атомарными изменениями подразумеваются:
/// удаление одного символа, вставка одного символа, замена одного символа на другой.
/// Найдите расстояние Левенштейна для предложенной пары строк.
/// Выведите единственное число — расстояние между строками.
/// </summary>
/// ====================================================================================================================
/// https://contest.yandex.ru/contest/25597/run-report/89510721/
/// ====================================================================================================================
/// -- Принцип работы алгоритма --
/// Алгорит вычисления раастояния по Левенштейну работает следующим образом:
/// Создается пустая матрица n x m, где n - длина первой строки + 1, m - длина второй строки + 1.
///
/// Сперва происходит первичное заполнение данных: для первой  строки в первую строку матрицы записываются индксы символов по порядку.
/// для второй строки индексы символов записываются в первый стоблбец матрицы.
///
/// Для рассчета значения в ячейке используется формула:
/// M[i, j] = min(M[i, j - 1] + 1, M[i - 1, j] + 1, M[i - 1, j - 1] + c(s1[i-1], s2[j-1]));
///
/// Смысл формулы сводится к вычислению минимальной стоимости из действий удаления, вставки, замены символа.
///
/// Итоговое расстояние Левенштейна находится в M[s1.Length, s2.Length]
///
/// -- Доказательство корректности --
/// Представленый алгоритм относиться к динамическим алгоритмам и реализуется с помощью рекурентной формулы,
/// т.е. результат текущий вычислений напрямую зависит от предыдущих.
///
/// -- Временная сложность --
/// Алгоритм предполагает проход по матрице замером m на n, следовательно временная сложность алгоритма - O(n * m);
/// 
/// -- Простарнственная сложность --
/// Для хранения матрицы используется O(n * m) дополнительной памяти.
/// 
public static class ALevenshteinDistance
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var firstString = reader.ReadLine()!;
        var secondString = reader.ReadLine()!;

        Console.WriteLine(LevenshteinDistance(firstString, secondString));
    }

    /// <summary>
    /// Вычисляет раастояние по Левенштейну между двух строк.
    /// </summary>
    /// <param name="str1">Первая строка.</param>
    /// <param name="str2">Вторая строка.</param>
    /// <returns>Расстояние по Левенштейну.</returns>
    private static int LevenshteinDistance(string str1, string str2)
    {
        var matrix = new int[str1.Length + 1, str2.Length + 1];

        FillInitData(matrix, str1.Length + 1, MatrixAccessor.Column);
        FillInitData(matrix, str2.Length + 1, MatrixAccessor.Row);

        for (var i = 1; i < str1.Length + 1; i++)
        {
            for (var j = 1; j < str2.Length + 1; j++)
                matrix[i, j] = GetMin(
                    matrix[i, j - 1] + 1,
                    matrix[i - 1, j] + 1,
                    matrix[i - 1, j - 1] + Compare(str1[i - 1], str2[j - 1])
                );
        }

        return matrix[str1.Length, str2.Length];
    }

    /// <summary>
    /// Сравнивает два символа.
    /// </summary>
    /// <param name="a">Первый символ.</param>
    /// <param name="b">Второй символ.</param>
    /// <returns>0 - если символы равны, 1 - если символы не равны.</returns>
    private static int Compare(char a, char b) => a == b ? 0 : 1;

    /// <summary>
    /// Заполняет матрицу начальными значениями.
    /// </summary>
    /// <param name="matrix">Матрица.</param>
    /// <param name="length">Длина строки или стоблца матрицы.</param>
    /// <param name="accessor">Идентификатор заполняемой части матрицы (строка или столбец).</param>
    private static void FillInitData(int[,] matrix, int length, MatrixAccessor accessor)
    {
        for (var i = 0; i < length; i++)
        {
            if (accessor is MatrixAccessor.Column)
                matrix[i, 0] = i;
            else
                matrix[0, i] = i;
        }
    }

    /// <summary>
    /// Возвращает минимум из переданных чисел.
    /// </summary>
    /// <param name="ints">Числа.</param>
    /// <returns>Минимальное число.</returns>
    private static int GetMin(params int[] ints) => ints.Min();
}

public enum MatrixAccessor
{
    Row,
    Column
}