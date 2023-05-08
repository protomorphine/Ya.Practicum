using Microsoft.VisualBasic;

namespace Ya.Practicum.SprintThree;

/// <summary>
/// Вася решил накопить денег на два одинаковых велосипеда — себе и сестре.
/// У Васи есть копилка, в которую каждый день он может добавлять деньги
/// (если, конечно, у него есть такая финансовая возможность). В процессе накопления Вася не вынимает деньги из копилки.
/// У вас есть информация о росте Васиных накоплений — сколько у Васи в копилке было денег в каждый из дней.
/// Ваша задача — по заданной стоимости велосипеда определить
///     первый день, в которой Вася смог бы купить один велосипед,
///     и первый день, в который Вася смог бы купить два велосипеда.
/// Подсказка: решение должно работать за O(log n).
/// </summary>
public static class LTwoBicycle
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var days = int.Parse(reader.ReadLine()!);
        var moneys = reader.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        var bicyclePrice = int.Parse(reader.ReadLine()!);

        var singleBicycle = BinarySearch(moneys, bicyclePrice, 0, days - 1);
        var twoBicycle = BinarySearch(moneys, bicyclePrice * 2, 0, days - 1);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine($"{singleBicycle} {twoBicycle}");
    }

    private static int BinarySearch(IReadOnlyList<int> arr, int elem, int left, int right)
    {
        if (right == left)
            return left + 1;

        if (elem > arr[right])
            return -1;

        var middle = (left + right) / 2;

        return arr[middle] < elem
            ? BinarySearch(arr, elem, middle + 1, right)
            : BinarySearch(arr, elem, left, middle);
    }
}