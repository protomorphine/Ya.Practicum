namespace Ya.Practicum.SprintThree;

/// <summary>
/// Рита решила оставить у себя одежду только трёх цветов:
///     розового, жёлтого и малинового.
/// После того как вещи других расцветок были убраны,
/// Рита захотела отсортировать свой новый гардероб по цветам.
/// Сначала должны идти вещи розового цвета, потом —– жёлтого,
/// и в конце —– малинового. Помогите Рите справиться с этой задачей.
/// Примечание: попробуйте решить задачу за один проход по массиву!
/// </summary>
public static class GWardrobe
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var clothes = int.Parse(reader.ReadLine()!);
        
        if (clothes is 0)
            return;

        var wardrobe = reader.ReadLine()!.Split(' ').Select(int.Parse).OrderBy(it => it);
        Console.WriteLine(string.Join(" ", wardrobe));
    }

}