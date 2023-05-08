namespace Ya.Practicum.SprintThree;

/// <summary>
/// Рита по поручению Тимофея наводит порядок в правильных скобочных последовательностях (ПСП),
/// состоящих только из круглых скобок ().
/// Для этого ей надо сгенерировать все ПСП длины 2n в алфавитном порядке —– алфавит состоит из ( и )
/// и открывающая скобка идёт раньше закрывающей.
/// Помогите Рите —– напишите программу, которая по заданному n выведет все ПСП в нужном порядке.
/// </summary>
public static class ABracketsGeneration
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var n = int.Parse(reader.ReadLine()!);

        Generate(n);
    }

    private static void Generate(int n, string prefix = "", int open = 0, int close = 0)
    {
        if (prefix.Length == n * 2)
        {
            Console.WriteLine(prefix);
            return;
        }

        if (open < n)
            Generate(n, prefix + "(", open + 1, close);

        if (open > close)
            Generate(n, prefix + ")", open, close + 1);
    }
}