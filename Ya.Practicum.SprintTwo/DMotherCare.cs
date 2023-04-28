using Ya.Practicum.SprintTwo.DataStructures.LinkedList.Nodes;

namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Мама Васи хочет знать, что сын планирует делать и когда.
///
/// Помогите ей: напишите функцию solution,
/// определяющую индекс первого вхождения передаваемого ей на вход значения в связном списке, если значение присутствует.
/// </summary>
public static class DMotherCare
{
    public static void Execute()
    {
        var node3 = new Node<string>("node3");
        var node2 = new Node<string>("node2", node3);
        var node1 = new Node<string>("node1", node2);
        var node0 = new Node<string>("node0", node1);

        Console.WriteLine(Solve(node0, "node5"));
    }

    private static int Solve<T>(Node<T> head, T item) where T : class
    {
        var idx = 0;

        var current = head;
        while (current.Next is not null) // В Яндекс.Контесте не схавало эту строку. 'is not null' надо заменить на '!= null'
        {
            if (current.Value == item)
                return idx;

            idx++;
            current = current.Next;
        }

        return -1;
    }
}