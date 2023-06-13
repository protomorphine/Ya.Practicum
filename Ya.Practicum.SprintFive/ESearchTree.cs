using Ya.Practicum.SprintFive.DataStructures;

namespace Ya.Practicum.SprintFive;

/// <summary>
/// Гоша понял, что такое дерево поиска, и захотел написать функцию, которая определяет,
/// является ли заданное дерево деревом поиска. Значения в левом поддереве должны быть строго меньше,
/// в правом —- строго больше значения в узле.
/// Помогите Гоше с реализацией этого алгоритма.
/// </summary>
public static class ESearchTree
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
        Console.WriteLine(Solve(node5));
        node2.Value = 5;
        Console.WriteLine(Solve(node5));
    }

    private static bool Solve(Node root) => 
        IsBinarySearchTree(root, int.MinValue, int.MaxValue);

    private static bool IsBinarySearchTree(Node? current, int min, int max)
    {
        if (current == null)
            return true;
        
        if (current.Value < min || current.Value > max)
            return false;

        return IsBinarySearchTree(current.Left, min, current.Value - 1)
               && IsBinarySearchTree(current.Right, current.Value + 1, max);
    }
}