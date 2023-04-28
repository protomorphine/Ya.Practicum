using Ya.Practicum.SprintTwo.DataStructures.LinkedList.Nodes;

namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Вася размышляет, что ему можно не делать из того списка дел, который он составил.
/// Но, кажется, все пункты очень важные! Вася решает загадать число и удалить дело, которое идёт под этим номером.
/// Список дел представлен в виде односвязного списка.
///
/// Напишите функцию solution, которая принимает на вход голову списка
/// и номер удаляемого дела и возвращает голову обновлённого списка.
/// </summary>
// ReSharper disable once InconsistentNaming
public static class CIDontLikeIt
{
    public static void Execute()
    {
        var node3 = new Node<string>("node3");
        var node2 = new Node<string>("node2", node3);
        var node1 = new Node<string>("node1", node2);
        var node0 = new Node<string>("node0", node1);

        var newHead = Solve(node0, 1);

        while (newHead is not null)
        {
            Console.WriteLine(newHead.Value);
            newHead = newHead.Next;
        }
    }

    private static Node<T>? Solve<T>(Node<T> head, int idx)
    {
        if (idx == 0)
            return head.Next;

        var i = 0;
        var current = head;
        while (current != null)
        {
            if (i == idx - 1)
            {
                current.Next = current.Next?.Next;
                break;
            }

            i++;
            current = current.Next;
        }

        return head;
    }
}