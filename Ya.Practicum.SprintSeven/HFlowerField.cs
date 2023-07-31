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
        var field = new int[bounds[0] + 1][];

        for (var i = bounds[0]; i > 0; i--)
        {
            var tokens = $"0{reader.ReadLine()!}";
            field[i] = tokens.ToCharArray().Select(it => int.Parse(it.ToString())).ToArray();
        }

        field[0] = new int[bounds[1] + 1];


        var dp = new int[bounds[0] + 1][];
        for (var i = 0; i < dp.Length; i++) 
            dp[i] = new int[bounds[1] + 1];

        for (var i = 1; i < field.Length; i++)
        {
            for (var j = 1; j < field[i].Length; j++) 
                dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]) + field[i][j];
        }
        
        Console.WriteLine(dp[bounds[0]][bounds[1]]);
    }
}