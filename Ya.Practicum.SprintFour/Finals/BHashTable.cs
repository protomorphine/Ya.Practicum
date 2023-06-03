using Ya.Practicum.SprintFour.Finals.DataStructures;

namespace Ya.Practicum.SprintFour.Finals;

/// <summary>
/// Тимофей, как хороший руководитель, хранит информацию о зарплатах своих сотрудников
/// в базе данных и постоянно её обновляет. Он поручил вам написать реализацию хеш-таблицы,
/// чтобы хранить в ней базу данных с зарплатами сотрудников.<br/><br/>
///
/// Хеш-таблица должна поддерживать следующие операции:<br/>
///     put key value —– добавление пары ключ-значение. Если заданный ключ уже есть в таблице,
///         то соответствующее ему значение обновляется.<br/>
///     get key –— получение значения по ключу. Если ключа нет в таблице, то вывести «None».
///         Иначе вывести найденное значение.<br/>
///     delete key –— удаление ключа из таблицы. Если такого ключа нет, то вывести «None»,
///         иначе вывести хранимое по данному ключу значение и удалить ключ.<br/>
/// В таблице хранятся уникальные ключи.<br/><br/>
///
/// Требования к реализации:<br/>
///     Нельзя использовать имеющиеся в языках программирования реализации
///         хеш-таблиц (std::unordered_map в С++, dict в Python, HashMap в Java, и т. д.)<br/>
///     Разрешать коллизии следует с помощью метода цепочек или с помощью открытой адресации.<br/>
///     Все операции должны выполняться за O(1) в среднем.<br/>
///     Поддерживать рехеширование и масштабирование хеш-таблицы не требуется.<br/>
///     Ключи и значения, id сотрудников и их зарплата, —– целые числа.
///         Поддерживать произвольные хешируемые типы не требуется.<br/>
/// </summary>
public static class BHashTable
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var count = int.Parse(reader.ReadLine()!);

        // преднамеренный вызов коллизий
        var hashTable = new HashTable(count > 10 ? count / 10 : 1);

        for (var i = 0; i < count; i++)
        {
            ProcessCommand(
                hashTable,
                ParseCommand(reader.ReadLine()!),
                res => Console.WriteLine(res.HasValue ? res.Value : "None")
            );
        }
    }

    /// <summary>
    /// Преобразует строку в <see cref="InputCommand"/>
    /// </summary>
    /// <param name="str">Строка.</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если в строке менее двух составляющий, разделенных символом пробела.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Выбрасывается при попытке передать в аргументы команды не целочисленный тип.
    /// </exception>
    /// <returns>Команда.</returns>
    private static InputCommand ParseCommand(string str)
    {
        var commandComponents = str.Split(' ');

        if (commandComponents.Length < 2)
            throw new ArgumentException("Input string must contains at least 2 components separated by ' '",
                nameof(str));

        return new InputCommand(
            commandComponents[0],
            commandComponents[1..]
                .Select(it =>
                    int.TryParse(it, out var parsed)
                        ? parsed
                        : throw new InvalidOperationException("Args must be only integers"))
                .ToArray()
        );
    }

    /// <summary>
    /// Обрабатывает команду.
    /// </summary>
    /// <param name="hashTable">Тестируемая хеш-таблица.</param>
    /// <param name="command">Команда.</param>
    /// <param name="callback">
    /// Коллбек операции. (Выполяется только для <see cref="HashTable.Get"/> и <see cref="HashTable.Delete"/> операций)
    /// </param>
    private static void ProcessCommand(HashTable hashTable, InputCommand command, Action<int?> callback)
    {
        var (commandName, args) = command;

        switch (commandName)
        {
            case "get":
                callback.Invoke(hashTable.Get(args[0]));
                break;
            case "put":
                hashTable.Put(args[0], args[1]);
                break;
            case "delete":
                callback.Invoke(hashTable.Delete(args[0]));
                break;
        }
    }
}

/// <summary>
/// Представление введенной команды.
/// </summary>
/// <param name="CommandName">Имя команды.</param>
/// <param name="Args">Аргументы команды.</param>
internal record InputCommand(string CommandName, int[] Args);