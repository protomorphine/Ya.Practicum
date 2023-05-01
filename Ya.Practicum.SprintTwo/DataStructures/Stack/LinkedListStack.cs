using Ya.Practicum.SprintTwo.DataStructures.LinkedList.Nodes;

namespace Ya.Practicum.SprintTwo.DataStructures.Stack;

/// <summary>Реализация стека с операциями за О(1)</summary>
public class LinkedListStack<T> where T : IComparable<T>
{
    /// <summary>
    /// Связный список значений стека.
    /// </summary>
    private Node<T>? _last;

    /// <summary>
    /// Связный список максимальных значений стека.
    /// </summary>
    private Node<T>? _max;

    /// <summary>
    /// Добавляет значение в стек.
    /// </summary>
    /// <param name="value">Значение</param>
    public void Push(T value)
    {
        if (_max == null || value.CompareTo(_max.Value) >= 0)
            _max = new Node<T>(value, _max);

        _last = new Node<T>(value, _last);
    }

    /// <summary>Возвращает и удаляет последнее добавленное значение из стека.</summary>
    /// <returns>Значение с вершины стека.</returns>
    public T Pop()
    {
        if (_last == null)
            throw new InvalidOperationException("Stack is empty");

        if (_max != null && _last.Value.CompareTo(_max.Value) is 0)
            _max = _max.Next;

        var value = _last.Value;
        _last = _last.Next;
        return value;
    }

    /// <summary>
    /// Пытается получить значение с вершины стека.
    /// </summary>
    /// <param name="value">Значение с вершины стека.</param>
    /// <returns>Флаг успешности операции.</returns>
    public bool TryPop(out T? value)
    {
        try
        {
            value = Pop();
            return true;
        }
        catch
        {
            value = default;
            return false;
        }
    }

    /// <summary>
    /// Возвращает максимальное значение из стека
    /// </summary>
    /// <exception cref="InvalidOperationException">Возникает если в стеке нет элементов</exception>
    /// <returns>Мауксимальнео значение, хранящееся на стеке</returns>
    public T GetMax()
    {
        if (_max == null)
            throw new InvalidOperationException("Stack contains no elements");
        return _max.Value;
    }
}