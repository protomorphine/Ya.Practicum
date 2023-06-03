namespace Ya.Practicum.SprintFour.Finals.DataStructures;

/// <summary>
/// Хеш-таблица, хранящая <see cref="KeyValuePair{TKey,TValue}"/> с целыми числами.
/// </summary>
public class HashTable
{
    /// <summary>
    /// Количество корзин.
    /// </summary>
    private readonly int _capacity;

    /// <summary>
    /// Корзины.
    /// </summary>
    private readonly Node<KeyValuePair<int, int>>?[] _buckets;

    /// <summary>
    /// Создает новый экземпляр <see cref="HashTable"/>
    /// </summary>
    public HashTable(int capacity)
    {
        _capacity = capacity;
        _buckets = new Node<KeyValuePair<int, int>>[_capacity];
    }

    /// <summary>
    /// Добавляет в таблицу пару ключ-значение.
    /// Есть пара с переданным ключом уже существует, перезаписывает значение.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <param name="value">Значение.</param>
    public void Put(int key, int value)
    {
        var keyHash = GetKeyHash(key);
        var bucket = _buckets[keyHash];
        var newEntry = new KeyValuePair<int, int>(key, value);
        var bucketEntry = new Node<KeyValuePair<int, int>>(newEntry);

        if (bucket is null)
        {
            _buckets[keyHash] = bucketEntry;
            return;
        }

        if (GetByKey(bucket, key) is { } existing)
        {
            existing.Value = newEntry;
            return;
        }

        bucketEntry.Next = bucket;
        bucket.Previous = bucketEntry;
        _buckets[keyHash] = bucketEntry;
    }

    /// <summary>
    /// Получет значение по ключу.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <returns>
    /// Значение.
    /// <remarks>Возвращаемое значение может быть null в случае если записи с искомым ключом не найдено.</remarks>
    /// </returns>
    public int? Get(int key)
    {
        var bucket = _buckets[GetKeyHash(key)];
        return bucket is null ? null : GetByKey(bucket, key)?.Value.Value;
    }

    /// <summary>
    /// Удаляет запись по ключу.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <returns>Значение.</returns>
    public int? Delete(int key)
    {
        var keyHash = GetKeyHash(key);
        var bucket = _buckets[keyHash];

        if (bucket is null || GetByKey(bucket, key) is not { } exists)
            return null;

        var value = exists.Value.Value;

        if (exists.Previous is not null)
            exists.Previous.Next = exists.Next;
        else
            _buckets[keyHash] = exists.Next;

        if (exists.Next is not null)
            exists.Next.Previous = exists.Previous;

        return value;
    }

    /// <summary>
    /// Возвращает ноду связного списка с искомым ключом.
    /// </summary>
    /// <param name="head">Связный список.</param>
    /// <param name="key">Искомый ключ.</param>
    /// <returns>Нода связного списка, либо null (в случае, если ключ не найден).</returns>
    private static Node<KeyValuePair<int, int>>? GetByKey(Node<KeyValuePair<int, int>>? head, int key)
    {
        while (head != null)
        {
            if (head.Value.Key == key)
                return head;

            head = head.Next;
        }

        return null;
    }

    /// <summary>
    /// Вычисляет хеш ключа.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <returns>Целочисленное значение хеша ключа.</returns>
    private int GetKeyHash(int key) => Math.Abs(key % _capacity);
}