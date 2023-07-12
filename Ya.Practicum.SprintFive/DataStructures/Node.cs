namespace Ya.Practicum.SprintFive.DataStructures;

/// <summary>
/// Узел бинарного дерева.
/// </summary>
public class Node
{
    /// <summary>
    /// Значение в узле
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Левый потомок
    /// </summary>
    public Node? Left { get; set; }

    /// <summary>
    /// Правый потомок
    /// </summary>
    public Node? Right { get; set; }

    /// <summary>
    /// Создает экземпляр <see cref="Node"/>
    /// </summary>
    /// <param name="value">Значение в узле</param>
    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}