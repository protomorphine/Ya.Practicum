using Ya.Practicum.SprintFive.DataStructures;

namespace Ya.Practicum.SprintFive;

/// <summary>
/// Напишите функцию, которая будет выводить по неубыванию все ключи от L до R
/// включительно в заданном бинарном дереве поиска.
/// Ключи в дереве могут повторяться.
/// Решение должно иметь сложность O(h+k), где h –— глубина дерева, k — число элементов в ответе.
/// </summary>
public static class KPrintRange
{
    public static void Execute()
    {
        var node1 = new Node(1);
        var node2 = new Node(4);
        var node3 = new Node(3)
        {
            Left = node1,
            Right = node2
        };
        var node4 = new Node(8);
        var node5 = new Node(5)
        {
            Left = node3,
            Right = node4
        };

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        PrintRange(node5, 3, 8, writer);
    }

    private static void PrintRange(Node root, int left, int right, TextWriter writer)
    {
        if (root.Value >= left && root.Left != null)
            PrintRange(root.Left, left, right, writer);
        
        if (root.Value <= right && root.Value >= left)
            writer.WriteLine(root.Value);
        
        if (root.Value <= right && root.Right != null)
            PrintRange(root.Right, left, right, writer);
    }

}