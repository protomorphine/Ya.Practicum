using System.Text;

namespace Ya.Practicum.SprintSeven;

/// <summary>
/// Теперь черепашке Кондратине надо узнать не только, сколько цветочков она может собрать,
/// но и как ей построить свой маршрут для этого. Помогите ей!
/// Напомним, что Кондратине надо дойти от левого нижнего до правого верхнего угла,
/// а передвигаться она умеет только вверх и вправо.
/// </summary>
public static class IComplexFlowerField
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
        Console.WriteLine(RestorePath(dp));
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

    private static string RestorePath(IReadOnlyList<int[]> dp)
    {
        var path = new StringBuilder();

        var i = dp.Count - 1;
        var j = dp[0].Length - 1;

        while (i <= dp.Count - 1 && j <= dp[0].Length - 1)
        {
            var left = j ==  1 ? -1 : dp[i][j - 1];
            var bottom = i == 1 ? -1 : dp[i - 1][j];

            if (left is -1 && bottom is -1)
                break;
            
            if (bottom > left)
            {
                path.Append('U');
                i--;
                continue;
            }

            path.Append('R');
            j--;
        }

        var restoredPath = path.ToString().ToCharArray();
        Array.Reverse(restoredPath);
        return new string(restoredPath);
    }
}