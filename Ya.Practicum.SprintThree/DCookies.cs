namespace Ya.Practicum.SprintThree;

/// <summary>
/// К Васе в гости пришли одноклассники. Его мама решила угостить ребят печеньем.
/// Но не всё так просто. Печенья могут быть разного размера. А у каждого ребёнка есть
/// фактор жадности —– минимальный размер печенья, которое он возьмёт.
/// Нужно выяснить, сколько ребят останутся довольными в лучшем случае, когда они действуют оптимально.
/// </summary>
public static class DCookies
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var kids = int.Parse(reader.ReadLine()!);
        var greeds = reader.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        var cookies = int.Parse(reader.ReadLine()!);
        var cookieSizes = reader.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        
        Array.Sort(greeds);
        Array.Sort(cookieSizes);

        int kid = 0, cookie = 0, res = 0;
        while (kid < kids && cookie < cookies)
        {
            if (greeds[kid] <= cookieSizes[cookie])
            {
                res++;
                kid++;
                
            }

            cookie++;
        }
        
        Console.WriteLine(res);
    }
}