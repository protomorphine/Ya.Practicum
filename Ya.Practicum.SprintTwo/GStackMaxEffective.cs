using Ya.Practicum.SprintTwo.DataStructures.Stack;

namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Реализуйте класс StackMaxEffective, поддерживающий операцию определения максимума среди элементов в стеке.
/// Сложность операции должна быть O(1).
/// Для пустого стека операция должна возвращать None.
/// При этом push(x) и pop() также должны выполняться за константное время.
/// </summary>
public static class GStackMaxEffective
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var commandsCount = int.Parse(reader.ReadLine()!);

        var stack = new StackMaxEffective();

        for (var i = 0; i < commandsCount; i++)
            ProcessCommand(stack, reader.ReadLine()!);
    }

    private static void ProcessCommand(StackMaxEffective stack, string command)
    {
        var commandWithArgs = command.Split(' ');
        command = commandWithArgs[0];

        switch (command)
        {
            case "push":
                var arg = commandWithArgs[1];
                stack.Push(int.Parse(arg));
                break;

            case "pop":
                if (stack.Pop() is 1)
                    Console.WriteLine("error");
                break;

            case "get_max":
                var max = stack.GetMax();
                Console.WriteLine(max.HasValue ? max : "None");
                break;
        }
    }
}