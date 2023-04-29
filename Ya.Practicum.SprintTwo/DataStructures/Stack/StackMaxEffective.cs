using Ya.Practicum.SprintTwo.DataStructures.LinkedList.Nodes;

namespace Ya.Practicum.SprintTwo.DataStructures.Stack;

/// <summary>
/// Реализация стека с операциями за О(1)
/// </summary>
public class StackMaxEffective<T> where T : IComparable<T>
{
    /// <summary>
    /// Связный список значений стека.
    /// Обновляется каждый раз при добавлении (Push) и удалении (Pop) элементов.
    /// </summary>
    private Node<T>? _last;

    /// <summary>
    /// Связный список максимальных значений стека.
    /// Обновляется при добавлении (Push) и удалении (Pop) максимального значения.
    /// </summary>
    private Node<T>? _max;

    /// <summary>
    /// Добавляет значение в стек.
    /// <br /> Если добавляемое значение больше или равно макисмальному в стеке,
    /// в связный список максимальных значений добавляется новый элемент
    /// </summary>
    /// <param name="value">Значение</param>
    public void Push(T value)
    {
        if (_max == null || value.CompareTo(_max.Value) >= 0)
            _max = new Node<T>(value, _max);

        _last = new Node<T>(value, _last);
    }

    /// <summary>
    /// Удаляет последнее добавленное значение из стека.
    /// Если удаляемое значение равно максимальному значению в стеке,
    /// из связного списка максиалмьных значений удаляется последний элемент
    /// </summary>
    /// <returns>Код выполнения операции (0 - успех, 1 - неудача)</returns>
    public int Pop()
    {
        if (_last == null)
            return 1;

        if (_max != null && _last.Value.CompareTo(_max.Value) is 0)
            _max = _max.Next;

        _last = _last.Next;
        return 0;
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