namespace Ya.Practicum.SprintTwo.DataStructures.Stack;

/// <summary>
/// Реализация стека, использующего внутри List{T}
/// </summary>
public class StackMax<T> where T : IComparable<T>
{
    /// <summary>
    /// List для хранения значений
    /// </summary>
    private readonly IList<T> _list = new List<T>();

    /// <summary>
    /// Максимальное значение на стеке
    /// </summary>
    private T? _max;

    /// <summary>
    /// Добавляет значение в стек.
    /// <br /> Если добавляется число больше максимума, максимум перезаписывается
    /// </summary>
    /// <param name="value">Значение</param>
    public void Push(T value)
    {
        if (value.CompareTo(_max) > 0)
            _max = value;

        _list.Add(value);
    }

    /// <summary>
    /// Удаляет последнее добавленное значение из стека.
    /// <br /> Если удаляется число, равное максимальному значению на стеке,
    /// максимум пересчитывается как IEnumerable.Max()
    /// </summary>
    /// <returns>Код выполнения операции (0 - успех, 1 - неудача)</returns>
    public int Pop()
    {
        if (_list.Count == 0)
            return 1;

        var last = _list[^1];

        _list.RemoveAt(_list.Count - 1);

        if (last.CompareTo(_max) is 0)
            _max = _list.Count is not 0 ? _list.Max() : default;

        return 0;
    }

    /// <summary>
    /// Возвращает максимальное значение из стека. Если стек пуст - возвращается null
    /// </summary>
    /// <returns>Мауксимальнео значение, хранящееся на стеке</returns>
    public T? GetMax()
    {
        if (_list.Count is 0)
            throw new InvalidOperationException("Stack contains no elements");
        return _max;
    }
}