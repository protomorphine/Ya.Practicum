namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Васе нужно распечатать свой список дел на сегодня.
/// Помогите ему: напишите функцию, которая печатает все его дела. Известно, что дел у Васи не больше 5000.
/// Внимание: в этой задаче не нужно считывать входные данные.
/// </summary>
public static class BTodoList
{
    public static void Execute()
    {
        var node3 = new Node<string>("node3");
        var node2 = new Node<string>("node2", node3);
        var node1 = new Node<string>("node1", node2);
        var node0 = new Node<string>("node0", node1);

        var head = node0;
        while (head != null)
        {
            Console.WriteLine(head.Value);
            head = head.Next;
        }
    }
}

public class Node<TValue>
{
    public TValue Value { get; }
    public Node<TValue>? Next { get; }

    public Node(TValue value, Node<TValue>? next = null)
    {
        Value = value;
        Next = next;
    }
}