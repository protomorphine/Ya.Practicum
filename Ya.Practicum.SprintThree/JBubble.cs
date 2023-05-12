namespace Ya.Practicum.SprintThree;

/// <summary>
/// Чтобы выбрать самый лучший алгоритм для решения задачи,
/// Гоша продолжил изучать разные сортировки. На очереди сортировка пузырьком.
/// Её алгоритм следующий (сортируем по неубыванию):
/// 
/// 1. На каждой итерации проходим по массиву, поочередно сравнивая пары соседних элементов.
///     Если элемент на позиции i больше элемента на позиции i + 1, меняем их местами.
///     После первой итерации самый большой элемент всплывёт в конце массива.
/// 2. Проходим по массиву, выполняя указанные действия до тех пор, пока на очередной итерации не окажется,
///     что обмены больше не нужны, то есть массив уже отсортирован.
/// 3. После не более чем n – 1 итераций выполнение алгоритма заканчивается,
///     так как на каждой итерации хотя бы один элемент оказывается на правильной позиции.
///    Помогите Гоше написать код алгоритма.
/// </summary>
public static class JBubble
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var n = int.Parse(reader.ReadLine()!);
        var arr = reader.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

        var flag = true;
        for (var i = 0; i < n - 1; i++)
        {
            for (var j = 0; j < n - i - 1; j++)
            {
                if (arr[j] <= arr[j + 1])
                    continue;

                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                flag = false;
            }

            if (flag)
                break;

            Console.WriteLine(string.Join(" ", arr));
        }

        if (flag)
            Console.WriteLine(string.Join(" ", arr));
    }
}