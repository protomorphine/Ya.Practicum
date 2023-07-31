namespace Ya.Practicum.SprintSeven;

/// <summary>
/// Черепаха Кондратина путешествует по клетчатому полю из n строк и m столбцов. В каждой клетке либо растёт цветочек,
/// либо не растёт. Кондратине надо добраться из левого нижнего в правый верхний угол и собрать как можно больше цветочков.
/// Помогите ей с этой сложной задачей и определите, какое наибольшее число цветочков она сможет собрать при условии,
/// что Кондратина умеет передвигаться только на одну клетку вверх или на одну клетку вправо за ход.
/// </summary>
public static class HFlowerField
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var bounds = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var field = ReadField(bounds[0], bounds[1], reader);

        var dp = new int[bounds[0] + 1][].Select(_ => new int[bounds[1] + 1]).ToArray();
        for (var i = 1; i < field.Length; i++)
        {
            for (var j = 1; j < field[i].Length; j++) 
                dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]) + field[i][j];
        }
        
        Console.WriteLine(dp[bounds[0]][bounds[1]]);
    }

    private static int[][] ReadField(int n, int m, TextReader reader)
    {
        var field = new int[n + 1][];

        for (var i = n; i > 0; i--)
        {
            var tokens = $"0{reader.ReadLine()!}";
            field[i] = tokens.ToCharArray().Select(it => int.Parse(it.ToString())).ToArray();
        }

        field[0] = new int[m + 1];
        return field;
    }
}