namespace Ya.Practicum.SprintTwo.DataStructures.Stack;

/// <summary>
/// Реализация стека, использующего внутри List{int}
/// </summary>
public class StackMax
{
    /// <summary>
    /// List для хранения значений
    /// </summary>
    private readonly IList<int> _list = new List<int>();

    /// <summary>
    /// Максимальное значение на стеке
    /// </summary>
    private int _max = int.MinValue;

    /// <summary>
    /// Добавляет значение в стек.
    /// <br /> Если добавляется число больше максимума, максимум перезаписывается
    /// </summary>
    /// <param name="value">Значение</param>
    public void Push(int value)
    {
        if (value > _max)
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

        if (last == _max)
            _max = _list.Count is not 0 ? _list.Max() : int.MinValue;

        return 0;
    }

    /// <summary>
    /// Возвращает максимальное значение из стека. Если стек пуст - возвращается null
    /// </summary>
    /// <returns>Мауксимальнео значение, хранящееся на стеке</returns>
    public int? GetMax()
    {
        if (_list.Count is 0)
            return null;
        return _max;
    }
}