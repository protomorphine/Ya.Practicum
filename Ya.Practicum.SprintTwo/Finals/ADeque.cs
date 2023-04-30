using Ya.Practicum.SprintTwo.DataStructures.Deque;

namespace Ya.Practicum.SprintTwo.Finals;

/// <summary>
/// Гоша реализовал структуру данных Дек, максимальный размер которого определяется заданным числом.
/// Методы push_back(x), push_front(x), pop_back(), pop_front() работали корректно.
/// Но, если в деке было много элементов, программа работала очень долго.
/// Дело в том, что не все операции выполнялись за O(1).
/// Помогите Гоше! Напишите эффективную реализацию.
/// </summary>
public static class ADeque
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var commands = int.Parse(reader.ReadLine()!);
        var dequeue = new RingBufferDeque<int>(int.Parse(reader.ReadLine()!));

        for (var _ = 0; _ < commands; _++)
            ProcessCommand(dequeue, reader.ReadLine()!);
    }

    private static void ProcessCommand(RingBufferDeque<int> dequeue, string command)
    {
        var commandAndArg = command.Split(' ');
        try
        {
            string arg;
            switch (commandAndArg[0])
            {
                case "push_back":
                    arg = commandAndArg[1];
                    dequeue.PushBack(int.Parse(arg));
                    break;
                case "push_front":
                    arg = commandAndArg[1];
                    dequeue.PushFront(int.Parse(arg));
                    break;
                case "pop_back":
                    Console.WriteLine(dequeue.PopBack());
                    break;
                case "pop_front":
                    Console.WriteLine(dequeue.PopFront());
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}