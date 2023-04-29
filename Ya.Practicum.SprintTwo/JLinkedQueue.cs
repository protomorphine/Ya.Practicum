using Ya.Practicum.SprintTwo.DataStructures.Queue;

namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Любимый вариант очереди Тимофея — очередь, написанная с использованием связного списка.
/// Помогите ему с реализацией. Очередь должна поддерживать выполнение трёх команд:
///     get() — вывести элемент, находящийся в голове очереди, и удалить его. Если очередь пуста, то вывести «error».
///     put(x) — добавить число x в очередь
///     size() — вывести текущий размер очереди
/// </summary>
public static class JLinkedQueue
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var commandCount = int.Parse(reader.ReadLine()!);

        var queue = new LinkedQueue<int>();
        for (var i = 0; i < commandCount; i++)
            ProcessCommand(queue, reader.ReadLine()!);
    }

    private static void ProcessCommand(LinkedQueue<int> queue, string command)
    {
        var commandAndArg = command.Split(' ');

        try
        {
            switch (commandAndArg[0])
            {
                case "get":
                    Console.WriteLine(queue.Get());
                    break;
                case "put":
                    var arg = int.Parse(commandAndArg[1]);
                    queue.Put(arg);
                    break;
                case "size":
                    Console.WriteLine(queue.Size());
                    break;
            }
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("error");
        }
    }
}