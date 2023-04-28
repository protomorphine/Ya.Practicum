using Ya.Practicum.SprintTwo.DataStructures.Queue;

namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Астрологи объявили день очередей ограниченного размера.
/// Тимофею нужно написать класс MyQueueSized, который принимает параметр max_size,
/// означающий максимально допустимое количество элементов в очереди.
/// Помогите ему —– реализуйте программу, которая будет эмулировать работу такой очереди.
/// Функции, которые надо поддержать, описаны в формате ввода.
///
/// В первой строке записано одно число — количество команд, оно не превосходит 5000.
/// Во второй строке задан максимально допустимый размер очереди, он не превосходит 5000.
/// Далее идут команды по одной на строке. Команды могут быть следующих видов:
///     push(x) — добавить число x в очередь;
///     pop() — удалить число из очереди и вывести на печать;
///     peek() — напечатать первое число в очереди;
///     size() — вернуть размер очереди;
///
/// При превышении допустимого размера очереди нужно вывести «error».
/// При вызове операций pop() или peek() для пустой очереди нужно вывести «None».
/// </summary>
// ReSharper disable once InconsistentNaming
public static class IFixedQueue
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var commandsCount = int.Parse(reader.ReadLine()!);
        var maxQueueSize = int.Parse(reader.ReadLine()!);

        var queue = new CircleBufferQueue(maxQueueSize);

        for (var i = 0; i < commandsCount; i++)
            ProcessCommand(queue, reader.ReadLine()!);
    }

    private static void ProcessCommand(CircleBufferQueue circleBufferQueue, string command)
    {
        var commandAndArg = command.Split(' ');

        try
        {
            switch (commandAndArg[0])
            {
                case "push":
                    var arg = int.Parse(commandAndArg[1]);
                    circleBufferQueue.Push(arg);
                    break;
                case "pop":
                    Console.WriteLine(circleBufferQueue.Pop());
                    break;
                case "peek":
                    Console.WriteLine(circleBufferQueue.Peek());
                    break;
                case "size":
                    Console.WriteLine(circleBufferQueue.Size());
                    break;
            }
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("error");
        }
        catch (Exception)
        {
            Console.WriteLine("None");
        }
    }
}