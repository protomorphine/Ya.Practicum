namespace Ya.Practicum.SprintOne;

/// <summary>
/// Вася делает тест по математике: вычисляет значение функций в различных точках.
/// Стоит отличная погода, и друзья зовут Васю гулять.
/// Но мальчик решил сначала закончить тест и только после этого идти к друзьям.
/// К сожалению, Вася пока не умеет программировать. Зато вы умеете.
/// Помогите Васе написать код функции, вычисляющей y = ax2 + bx + c.
/// Напишите программу, которая будет по коэффициентам a, b, c и числу x выводить значение функции в точке x.
/// </summary>
public static class AFuncValue
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var line = reader.ReadLine()!
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var res = line[0] * line[1] * line[1] + line[2] * line[1] + line[3];

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(res);
    }
}