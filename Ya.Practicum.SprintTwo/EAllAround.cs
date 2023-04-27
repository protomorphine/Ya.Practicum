using Ya.Practicum.SprintTwo.LinkedList.Nodes;

namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Вася решил запутать маму —– делать дела в обратном порядке.
/// Список его дел теперь хранится в двусвязном списке.
///
/// Напишите функцию, которая вернёт список в обратном порядке.
/// </summary>
public static class EAllAround
{
    public static void Execute()
    {
        var node3 = new DoubleNode<string>("node3");
        var node2 = new DoubleNode<string>("node2", node3);
        var node1 = new DoubleNode<string>("node1", node2);
        var node0 = new DoubleNode<string>("node0", node1);

        var newHead = Solve(node0);

        while (newHead != null)
        {
            var val = newHead.Value;
            const string nullString = "null";
            Console.WriteLine($"{val}.Prev = {newHead.Prev?.Value ?? nullString}; {val}.Next = {newHead.Next?.Value ?? nullString};");
            newHead = newHead.Next;
        }
    }

    private static DoubleNode<T> Solve<T>(DoubleNode<T> head)
    {
        var current = head;
        DoubleNode<T>? tmp = null;
        while (current != null)
        {
            current.Prev = current.Next;
            current.Next = tmp;

            tmp = current;

            current = current.Prev;
        }

        return tmp!;
    }
}