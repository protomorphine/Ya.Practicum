namespace Ya.Practicum.Common;

/// <summary>
/// Представление участника олимпиады.
/// <remarks>
/// В данном классе переопеределены операторы сравнения и метод Equals.
/// Переопередление операторов необходимо для их корректной работы, т.к.
/// CLR не будет использовать по умолчанию метод CompareTo.
/// </remarks>
/// </summary>
public class Participant : IComparable<Participant>
{
    /// <summary>
    /// Униклаьный логин учатника.
    /// </summary>
    public string Login { get; }

    /// <summary>
    /// Количество решенных задач участником.
    /// </summary>
    public int SolvedTasks { get; }

    /// <summary>
    /// Штрафные баллы участника.
    /// </summary>
    public int Fine { get; }

    /// <summary>
    /// Создает новый экземпляр <see cref="Participant"/>
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="solvedTasks">Количество решенных задач.</param>
    /// <param name="fine">Штраф.</param>
    public Participant(string login, int solvedTasks, int fine)
    {
        Login = login;
        SolvedTasks = solvedTasks;
        Fine = fine;
    }

    /// <inheritdoc />
    public int CompareTo(Participant? other)
    {
        if (ReferenceEquals(this, other))
            return 0;

        if (ReferenceEquals(null, other))
            return 1;

        if (SolvedTasks == other.SolvedTasks)
            return Fine == other.Fine
                ? string.Compare(Login, other.Login, StringComparison.CurrentCulture)
                : Fine.CompareTo(other.Fine);

        return other.SolvedTasks.CompareTo(SolvedTasks);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is not Participant other)
            return false;
        
        return CompareTo(other) == 0;
    }

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(Login, SolvedTasks, Fine);

    /// <summary>
    /// Оператор равенства.
    /// </summary>
    /// <param name="left">Экземпляр "слева".</param>
    /// <param name="right">Экземпляр "справа".</param>
    public static bool operator == (Participant left, Participant right) =>
        left?.Equals(right) ?? ReferenceEquals(right, null);

    /// <summary>
    /// Оператор больше.
    /// </summary>
    /// <param name="left">Экземпляр "слева".</param>
    /// <param name="right">Экземпляр "справа".</param>
    public static bool operator > (Participant left, Participant right) => left.CompareTo(right) > 0;

    /// <summary>
    /// Оператор больше или равно.
    /// </summary>
    /// <param name="left">Экземпляр "слева".</param>
    /// <param name="right">Экземпляр "справа".</param>
    public static bool operator >= (Participant left, Participant right) => left.CompareTo(right) >= 0;

    /// <summary>
    /// Оператор меньше.
    /// </summary>
    /// <param name="left">Экземпляр "слева".</param>
    /// <param name="right">Экземпляр "справа".</param>
    public static bool operator < (Participant left, Participant right) => left.CompareTo(right) < 0;

    /// <summary>
    /// Оператор меньше или равно.
    /// </summary>
    /// <param name="left">Экземпляр "слева".</param>
    /// <param name="right">Экземпляр "справа".</param>
    public static bool operator <= (Participant left, Participant right) => left.CompareTo(right) <= 0;

    /// <summary>
    /// Оператор не равенства.
    /// </summary>
    /// <param name="left">Экземпляр "слева".</param>
    /// <param name="right">Экземпляр "справа".</param>
    public static bool operator != (Participant left, Participant right) => !(left == right);
}