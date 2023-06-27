using Ya.Practicum.SprintFive.DataStructures;

namespace Ya.Practicum.SprintFive.Finals;

/// <summary>
/// Дано бинарное дерево поиска, в котором хранятся ключи. Ключи — уникальные целые числа.
/// Найдите вершину с заданным ключом и удалите её из дерева так, чтобы дерево осталось корректным
/// бинарным деревом поиска. Если ключа в дереве нет, то изменять дерево не надо.
/// На вход вашей функции подаётся корень дерева и ключ, который надо удалить.
/// Функция должна вернуть корень изменённого дерева. Сложность удаления узла должна составлять 
/// O(h), где h –— высота дерева.
///
/// https://contest.yandex.ru/contest/24810/run-report/88571346/
///=======================================================================
/// -- ПРИНЦИП РАБОТЫ --
/// Для удаления элемента рассматривается два случая:
///  - если у удаляемой ноды есть только один "ребенок" - удаляемая нода заменяется на "ребенка"
///  - если у удяляемой ноды 2 "ребенка" - значение удаляемой ноды зменяется на самое левое значение правого поддерева.
/// Данный алгоритм позволяет сохранить корректность расположения элементов в бинарном дереве поиска: элементы меньше корня всегда находятся слева,
/// а элементы больше корня находятся справа.
/// 
/// -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
/// O(h), где h - высота бинарного дерева поиска. 
///
/// -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
/// O(h), где h - высота бинарного дерева поиска.
/// 
/// </summary>
public static class BRemoveTreeNode
{
    public static void Execute()
    {
        var node1 = new Node(2);
        var node2 = new Node(3)
        {
            Left = node1
        };

        var node3 = new Node(1)
        {
            Right = node2
        };

        var node4 = new Node(6);
        var node5 = new Node(8)
        {
            Left = node4
        };

        var node6 = new Node(10)
        {
            Left = node5
        };

        var node7 = new Node(5)
        {
            Left = node3,
            Right = node6
        };

        var newHead = Remove(node7, 1);

        Console.WriteLine(newHead!.Value == 5);
        Console.WriteLine(newHead.Right == node5);
        Console.WriteLine(newHead.Right!.Value == 8);
    }

    /// <summary>
    /// Удаляет узел из дерева.
    /// </summary>
    /// <param name="root">Корень дерева.</param>
    /// <param name="key">Ключ дял удаления.</param>
    /// <returns>Обновленный корень дерева.</returns>
    private static Node? Remove(Node? root, int key)
    {
        if (root == null)
            return null;

        if (root.Value > key)
            return DeleteInSubtree(NodeSide.Left, root, key);

        return root.Value < key ? DeleteInSubtree(NodeSide.Right, root, key) : DeleteRoot(root);
    }

    /// <summary>
    /// Удаляет ключ в поддереве.
    /// </summary>
    /// <param name="side">Поддерево.</param>
    /// <param name="root">Корень дерева.</param>
    /// <param name="key">Ключ для удаления.</param>
    /// <returns>Обновленный корень дерева.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private static Node DeleteInSubtree(NodeSide side, Node root, int key)
    {
        var newSubtreeRoot = Remove(side == NodeSide.Left ? root.Left : root.Right, key);

        switch (side)
        {
            case NodeSide.Left:
                root.Left = newSubtreeRoot;
                break;
            case NodeSide.Right:
                root.Right = newSubtreeRoot;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(side), side, "Algorithm works only with BST!");
        }

        return root;
    }

    /// <summary>
    /// Удаляет корень дерева.
    /// Вмето корневого узла вставляется значение самого левого листа правого поддерева.
    /// </summary>
    /// <param name="root">Корень.</param>
    /// <returns>Обновленный корень дерева.</returns>
    private static Node DeleteRoot(Node root)
    {
        if (root.Left == null)
            return root.Right!;

        if (root.Right == null)
            return root.Left;

        var rightLastLeftValue = MostLeftValue(root.Right);

        root.Value = rightLastLeftValue;
        return DeleteInSubtree(NodeSide.Right, root, rightLastLeftValue);
    }

    /// <summary>
    /// Возвращает самое левое значение дерева.
    /// </summary>
    /// <param name="root">Корень.</param>
    /// <returns>Самое левое значение в дереве.</returns>
    private static int MostLeftValue(Node root) => root.Left == null ? root.Value : MostLeftValue(root.Left);

    /// <summary>
    /// Определяет поддерево.
    /// </summary>
    private enum NodeSide
    {
        /// <summary>
        /// Левое поддерево.
        /// </summary>
        Left,
        
        /// <summary>
        /// Правое поддерево.
        /// </summary>
        Right
    }
}