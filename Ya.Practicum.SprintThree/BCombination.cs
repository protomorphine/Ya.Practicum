namespace Ya.Practicum.SprintThree;

/// <summary>
/// На клавиатуре старых мобильных телефонов каждой цифре соответствовало несколько букв.
/// Вам известно в каком порядке были нажаты кнопки телефона, без учета повторов.<br/><br/>
/// Примерно так:<br/>
/// 2:'abc',<br/>
/// 3:'def',<br/>
/// 4:'ghi',<br/>
/// 5:'jkl',<br/>
/// 6:'mno',<br/>
/// 7:'pqrs',<br/>
/// 8:'tuv',<br/>
/// 9:'wxyz'<br/><br/>
/// Напечатайте все комбинации букв, которые можно набрать такой последовательностью нажатий.
/// </summary>
public static class BCombination
{
    /// <summary>
    /// Сопостовление номера на клавиатуре с символами.
    /// </summary>
    private static readonly Dictionary<int, char[]> Map = new()
    {
        { 2, new[] { 'a', 'b', 'c' } },
        { 3, new[] { 'd', 'e', 'f' } },
        { 4, new[] { 'g', 'h', 'i' } },
        { 5, new[] { 'j', 'k', 'l' } },
        { 6, new[] { 'm', 'n', 'o' } },
        { 7, new[] { 'p', 'q', 'r', 's' } },
        { 8, new[] { 't', 'u', 'v' } },
        { 9, new[] { 'w', 'x', 'y', 'z' } }
    };

    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var number = reader.ReadLine()!.ToCharArray().Select(it => int.Parse(it.ToString())).ToArray();

        PrintCombinationInConsole(number);
    }

    /// <summary>
    /// Печатает комбинации в консоль.
    /// </summary>
    /// <param name="number">Номер.</param>
    private static void PrintCombinationInConsole(int[] number) => PrintCombinationInternal(number, Console.Write);

    /// <summary>
    /// Печатает комбинации с использование переданного делегата.
    /// </summary>
    /// <param name="number">Номер.</param>
    /// <param name="printAction">Делегат печати.</param>
    /// <param name="prefix">Промежуточная комбинация.</param>
    private static void PrintCombinationInternal(int[] number, Action<string> printAction, string prefix = "")
    {
        if (Array.Exists(number, n => n is > 9 or < 2))
            throw new ArgumentOutOfRangeException(nameof(number), "All source array elements must be in range [2, 9]");
        
        if (!number.Any())
        {
            printAction.Invoke(prefix + " ");
            return;
        }
        
        var mapEntry = Map[number[0]];

        foreach (var c in mapEntry)
            PrintCombinationInternal(number[1..], printAction, prefix + c);
    }
}