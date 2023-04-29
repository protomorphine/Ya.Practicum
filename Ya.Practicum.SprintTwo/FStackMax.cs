using Ya.Practicum.SprintTwo.DataStructures.Stack;

namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Нужно реализовать класс StackMax, который поддерживает операцию определения максимума среди всех элементов в стеке.
/// Класс должен поддерживать операции push(x), где x – целое число, pop() и get_max().
/// </summary>
public static class FStackMax
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var commandsCount = int.Parse(reader.ReadLine()!);

        var stack = new StackMax<int>();

        for (var i = 0; i < commandsCount; i++)
            ProcessCommand(stack, reader.ReadLine()!);
    }

    private static void ProcessCommand(StackMax<int> stack, string command)
    {
        var commandWithArgs = command.Split(' ');
        command = commandWithArgs[0];

        switch (command)
        {
            case "push":
                var arg = commandWithArgs[1];
                stack.Push(int.Parse(arg!));
                break;

            case "pop":
                if (stack.Pop() is 1)
                    Console.WriteLine("error");
                break;

            case "get_max":
                try { Console.WriteLine(stack.GetMax()); }
                catch { Console.WriteLine("None"); }
                break;
        }
    }
}