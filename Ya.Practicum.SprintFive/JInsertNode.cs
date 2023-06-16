using Ya.Practicum.SprintFive.DataStructures;

namespace Ya.Practicum.SprintFive;

/// <summary>
/// Дано BST. Надо вставить узел с заданным ключом. Ключи в дереве могут повторяться.
/// На вход функции подаётся корень корректного бинарного дерева поиска и ключ,
/// который надо вставить в дерево. Осуществите вставку этого ключа.
/// Если ключ уже есть в дереве, то его дубликаты уходят в правого сына.
/// Таким образом вид дерева после вставки определяется однозначно.
/// Функция должна вернуть корень дерева после вставки вершины.
/// </summary>
public static class JInsertNode
{
    public static void Execute()
    {
        var node1 = new Node(7);
        var node2 = new Node(8) { Left = node1 };
        var head = new Node(7) { Right = node2 };
        
        var newHead = Insert(head, 7);
        
        Console.WriteLine(newHead == head);
        Console.WriteLine(newHead.Right?.Left?.Right != null 
                          && newHead.Right.Left != null 
                          && newHead.Right.Left.Right.Value == 7);
    }
    
    private static Node Insert(Node root, int key)
    {
        if (key < root.Value)
        {
            if (root.Left is null)
                root.Left = new Node(key);
            else
                Insert(root.Left, key);
        } 
        else
        {
            if (root.Right is null)
                root.Right = new Node(key);
            else
                Insert(root.Right, key);
        }

        return root;
    }
}
