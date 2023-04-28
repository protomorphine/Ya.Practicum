namespace Ya.Practicum.SprintTwo.DataStructures.LinkedList.Nodes;

/// <summary>
/// Нода односвязного списка
/// </summary>
/// <typeparam name="TValue">Тип значения ноды</typeparam>
public class Node<TValue>
{
    /// <summary>
    /// Значение ноды
    /// </summary>
    public TValue Value { get; }

    /// <summary>
    /// Ссылка на следующий элемент списка
    /// </summary>
    public Node<TValue>? Next { get; set; }

    public Node(TValue value, Node<TValue>? next = null)
    {
        Value = value;
        Next = next;
    }
}