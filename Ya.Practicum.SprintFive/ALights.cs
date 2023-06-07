namespace Ya.Practicum.SprintFive;

/// <summary>
/// Гоша повесил на стену гирлянду в виде бинарного дерева, в узлах которого находятся лампочки.
/// У каждой лампочки есть своя яркость. Уровень яркости лампочки соответствует числу, расположенному
/// в узле дерева. Помогите Гоше найти самую яркую лампочку в гирлянде, то есть такую,
/// у которой яркость наибольшая.
/// </summary>
public static class ALights
{
    public static void Execute()
    {
        var root = new TreeNode<int>(1,
            new TreeNode<int>(3,
                new TreeNode<int>(8,
                    new TreeNode<int>(14),
                    new TreeNode<int>(15)),
                new TreeNode<int>(10,
                    null,
                    new TreeNode<int>(3)
                )
            ),
            new TreeNode<int>(5,
                new TreeNode<int>(2),
                new TreeNode<int>(6,
                    new TreeNode<int>(0),
                    new TreeNode<int>(1)
                )
            )
        );

        Console.WriteLine(GetMaxFromTree(root));
    }

    private static int GetMaxFromTree(TreeNode<int> root, int max = 0)
    {
        switch (root)
        {
            case { Right: null, Left: null }:
                return Math.Max(root.Value, max);

            case { Left: not null, Right: not null }:
            {
                var calculatedMax = GetMax(max, root.Value, root.Left.Value, root.Right.Value);

                return GetMax(
                    GetMaxFromTree(root.Left, calculatedMax),
                    GetMaxFromTree(root.Right, calculatedMax)
                );
            }

            case { Left: not null, Right: null }:
            {
                var calculatedMax = GetMax(max, root.Value, root.Left.Value);

                return GetMaxFromTree(root.Left, calculatedMax);
            }

            case { Left: null, Right: not null }:
            {
                var calculatedMax = GetMax(max, root.Value, root.Right.Value);

                return GetMaxFromTree(root.Right, calculatedMax);
            }
            default:
                return root.Value;
        }
    }

    private static int GetMax(params int[] args) => args.Max();
}

public class TreeNode<T>
{
    public TreeNode<T>? Left { get; set; }

    public TreeNode<T>? Right { get; set; }

    public T Value { get; }

    public TreeNode(T value, TreeNode<T>? left = null, TreeNode<T>? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}