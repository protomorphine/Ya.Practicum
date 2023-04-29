namespace Ya.Practicum.SprintOne;

/// <summary>
/// Чтобы подготовиться к семинару, Гоше надо прочитать статью по эффективному менеджменту.
/// Так как Гоша хочет спланировать день заранее, ему необходимо оценить сложность статьи.
/// Он придумал такой метод оценки: берётся случайное предложение из текста и в нём ищется самое длинное слово.
/// Его длина и будет условной сложностью статьи.
/// <br/> Помогите Гоше справиться с этой задачей.
/// </summary>
public static class ELongestWord
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var length = int.Parse(reader.ReadLine()!);
        var text = reader.ReadLine()!;

        var res = text.Split(' ').OrderByDescending(it => it.Length).First();

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(res);
        writer.WriteLine(res.Length);
    }
}