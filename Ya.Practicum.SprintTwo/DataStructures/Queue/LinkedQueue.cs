using Ya.Practicum.SprintTwo.DataStructures.LinkedList.Nodes;

namespace Ya.Practicum.SprintTwo.DataStructures.Queue;

/// <summary>
/// Реализация очереди через односвязный список
/// </summary>
public class LinkedQueue
{
    /// <summary>
    /// Голова односвязного списка.
    /// </summary>
    private Node<int>? _head;

    /// <summary>
    /// Последний элемент списка.
    /// </summary>
    private Node<int>? _last;

    /// <summary>
    /// Размер очереди.
    /// </summary>
    private int _size;

    /// <summary>
    /// Возвращает первый элемент и удаляет его из очереди.
    /// </summary>
    /// <returns>Первый элемент очереди.</returns>
    /// <exception cref="InvalidOperationException">Возникает когда очередь пуста</exception>
    public int Get()
    {
        if (_head is null)
            throw new InvalidOperationException("Queue is empty");

        var value = _head.Value;
        _head = _head.Next;
        _size--;
        return value;
    }

    /// <summary>
    /// Добавляет элемент в конец очереди.
    /// </summary>
    /// <param name="value">Элемент.</param>
    public void Put(int value)
    {
        var node = new Node<int>(value);
        if (_head is null)
        {
            _head = node;
            _last = node;
        }
        else
        {
            _last!.Next = node;
            _last = node;
        }
        _size++;
    }

    /// <summary>
    /// Возвращает размер очереди.
    /// </summary>
    /// <returns>Размер очереди.</returns>
    public int Size() => _size;
}