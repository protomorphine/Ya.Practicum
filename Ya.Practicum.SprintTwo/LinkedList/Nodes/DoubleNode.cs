namespace Ya.Practicum.SprintTwo.LinkedList.Nodes;

/// <summary>
/// Нода двусвязного списка
/// </summary>
/// <typeparam name="TValue">Тип значения ноды</typeparam>
public class DoubleNode<TValue>
{
    /// <summary>
    /// Значение ноды
    /// </summary>
    public TValue Value { get; }

    /// <summary>
    /// Следующая нода в списке
    /// </summary>
    public DoubleNode<TValue>? Next { get; set; }

    /// <summary>
    /// Предыдущая нода в списке
    /// </summary>
    public DoubleNode<TValue>? Prev { get; set; }

    public DoubleNode(TValue value, DoubleNode<TValue>? next = null, DoubleNode<TValue>? prev = null)
    {
        Value = value;
        Next = next;
        Prev = prev;
    }
}