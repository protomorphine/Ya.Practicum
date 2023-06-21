using Ya.Practicum.SprintFive.DataStructures;

namespace Ya.Practicum.SprintFive;

/// <summary>
/// Гоше очень понравилось слушать рассказ Тимофея про деревья. Особенно часть про сбалансированные деревья.
/// Он решил написать функцию, которая определяет, сбалансировано ли дерево.
/// Дерево считается сбалансированным,
/// если левое и правое поддеревья каждой вершины отличаются по высоте не больше, чем на единицу.
/// </summary>
public static class BBalance
{
    public static void Execute()
    {
        var node1 = new Node(1);
        var node2 = new Node(-5);
        var node3 = new Node(3)
        {
            Left = node1,
            Right = node2
        };
        var node4 = new Node(10);
        var node5 = new Node(2)
        {
            Left = node3,
            Right = node4
        };
        Console.WriteLine(IsBalanced(node5));
    }

    private static bool IsBalanced(Node? root)
    {
        if (root == null)
            return true;

        if (Math.Abs(GetHeight(root.Left, 0) - GetHeight(root.Right, 0)) > 1)
            return false;

        return IsBalanced(root.Left) && IsBalanced(root.Right);
    }

    private static int GetHeight(Node? root, int height)
    {
        if (root == null)
            return height;

        height++;

        return Math.Max(GetHeight(root.Left, height), GetHeight(root.Right, height));
    }
}