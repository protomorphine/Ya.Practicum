namespace Ya.Practicum.SprintTwo.DataStructures.Queue;

/// <summary>
/// Реализация LIFO очереди с кольцевым буффером
/// </summary>
public class CircleBufferQueue
{
    /// <summary>
    /// Массив для хранения элементов очереди.
    /// </summary>
    private readonly int[] _queue;

    /// <summary>
    /// Максимальный размер очереди.
    /// </summary>
    private readonly int _maxSize;

    /// <summary>
    /// Индекс "головы" очереди.
    /// Нужен для считывания данных из начала.
    /// </summary>
    private int _head;

    /// <summary>
    /// Индекс "хвоста" очереди.
    /// Нужен для добавления элементов в конец очереди.
    /// </summary>
    private int _tail;

    /// <summary>
    /// Размер очереди.
    /// </summary>
    private int _size;

    public CircleBufferQueue(int maxSize)
    {
        _maxSize = maxSize;
        _queue = new int[maxSize];
    }

    /// <summary>
    /// Добавляет элемент в конец очереди.
    ///
    /// После добавления элемента увеличиваем значение поля tail,
    /// и новый элемент будет записываться в следующую ячейку.
    /// Значение tail берётся по модулю _maxSize.
    /// Это делается для того, чтобы первая ячейка следовала за последней.
    /// </summary>
    /// <param name="x">Элемент.</param>
    /// <exception cref="InvalidOperationException">
    /// Возникает когда очереди заполнена, и не может вместить еще один элемент
    /// </exception>
    public void Push(int x)
    {
        if (_size == _maxSize)
            throw new InvalidOperationException("CircleBufferQueue is full");

        _queue[_tail] = x;
        _tail = (_tail + 1) % _maxSize;
        _size++;
    }

    /// <summary>
    /// Возвращает первый элемент из очереди, и удаляет его.
    /// При удалении элемента "голова" смещается на единицу вперед, но не превосходя максимальный размер очереди
    /// (аналогично полю _tail при добавлении элемента в очередь).
    /// </summary>
    /// <returns>Первый элемент очереди.</returns>
    /// <exception cref="IndexOutOfRangeException">Возникает когда в очереди нет элементов.</exception>
    public int Pop()
    {
        if (_size == 0)
            throw new Exception("CircleBufferQueue contains no elements");

        var value = _queue[_head];
        _queue[_head] = 0;
        _head = (_head + 1) % _maxSize;
        _size--;

        return value;
    }

    /// <summary>
    /// Возвращает первый элемент очереди, не удаляя его.
    /// </summary>
    /// <returns>Первый элемент очереди.</returns>
    /// <exception cref="IndexOutOfRangeException">Возникает когда в очереди нет элементов.</exception>
    public int Peek()
    {
        if (_size == 0)
            throw new Exception("CircleBufferQueue is empty");

        return _queue[_head];
    }

    /// <summary>
    /// Возвращает размер очереди.
    /// </summary>
    /// <returns>Размер очереди.</returns>
    public int Size() => _size;
}