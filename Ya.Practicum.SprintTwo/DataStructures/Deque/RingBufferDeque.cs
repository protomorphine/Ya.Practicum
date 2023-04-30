namespace Ya.Practicum.SprintTwo.DataStructures.Deque;

/// <summary>Реализация дека через кольцевой буффер</summary>
public class RingBufferDeque<T>
{
    /// <summary>Массив для хранения элементов дека.</summary>
    private readonly T?[] _deque;

    /// <summary>Максимальный размер дека.</summary>
    private readonly int _maxSize;

    /// <summary>Индекс начала ("головы") дека.</summary>
    private int _head;

    /// <summary>Индекс конца ("хвоста") дека.</summary>
    private int _tail;

    /// <summary>Размер дека.</summary>
    private int _size;

    /// <summary>
    /// Создает новый экземпляр класса <see cref="RingBufferDeque{T}"/>.
    /// </summary>
    /// <param name="maxSize">Максимальный размер дека.</param>
    public RingBufferDeque(int maxSize)
    {
        _maxSize = maxSize;
        _tail = _maxSize - 1;
        _deque = new T?[maxSize];
    }

    /// <summary>Вставляет элемент в конец дека.</summary>
    /// <param name="x">Элемент.</param>
    public void PushBack(T x)
    {
        CheckSizeThrowIfEquals(_maxSize);

        _deque[_tail] = x;
        _tail = (_tail - 1 + _maxSize) % _maxSize;
        _size++;
    }

    /// <summary>Вставляет элемент в начала дека.</summary>
    /// <param name="x">Элемент.</param>
    public void PushFront(T x)
    {
        CheckSizeThrowIfEquals(_maxSize);

        _deque[_head] = x;
        _head = (_head + 1 + _maxSize) % _maxSize;
        _size++;
    }

    /// <summary>Возвращает элемент из начала дека и удаляет его.</summary>
    /// <returns>Элемент из начала дека.</returns>
    public T PopFront()
    {
        CheckSizeThrowIfEquals(0);

        _head = (_head - 1 + _maxSize) % _maxSize;
        var value = _deque[_head];
        _deque[_head] = default;
        _size--;

        return value!;
    }

    /// <summary>Возвращает элемент из конца дека и удаляет его.</summary>
    /// <returns>Элемент из конца дека.</returns>
    public T PopBack()
    {
        CheckSizeThrowIfEquals(0);

        _tail = (_tail + 1 + _maxSize) % _maxSize;
        var value = _deque[_tail];
        _deque[_tail] = default;
        _size--;

        return value!;
    }

    /// <summary>
    /// Проверяет текущай размер дека, сравнивая его с переданным размером.
    /// </summary>
    /// <param name="size">Размер.</param>
    /// <exception cref="Exception">Возникает если текущий размер дека равен переданному.</exception>
    private void CheckSizeThrowIfEquals(int size)
    {
        if (_size == size)
            throw new Exception("error");
    }
}