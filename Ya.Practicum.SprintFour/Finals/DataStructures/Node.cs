namespace Ya.Practicum.SprintFour.Finals.DataStructures;

/// <summary>
/// Нода двусвязного списка
/// </summary>
/// <typeparam name="TValue">Тип значения ноды</typeparam>
public class Node<TValue>
{
    /// <summary>
    /// Значение ноды
    /// </summary>
    public TValue Value { get; set; }

    /// <summary>
    /// Ссылка на следующий элемент списка
    /// </summary>
    public Node<TValue>? Next { get; set; }

    /// <summary>
    /// Ссылка на предыдущий элемент списка
    /// </summary>
    public Node<TValue>? Previous { get; set; }

    public Node(TValue value, Node<TValue>? next = null, Node<TValue>? prev = null)
    {
        Value = value;
        Next = next;
        Previous = prev;
    }
}