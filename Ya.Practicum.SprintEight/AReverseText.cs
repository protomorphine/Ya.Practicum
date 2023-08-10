namespace Ya.Practicum.SprintEight;

/// <summary>
/// В некоторых языках предложения пишутся и читаются не слева направо, а справа налево.
/// Вам под руку попался странный текст –— в нём обычный (слева направо) порядок букв в словах.
/// А вот сами слова идут в противоположном направлении.
/// Вам надо преобразовать текст так, чтобы слова в нём были написаны слева направо.
/// </summary>
public static class AReverseText
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var text = reader.ReadLine()!.Split(' ').ToArray();
        Array.Reverse(text);
        
        Console.WriteLine(string.Join(" ", text));
    }
}