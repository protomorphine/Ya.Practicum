namespace Ya.Practicum.SprintEight.Finals;

public static class BCheatSheet
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var text = reader.ReadLine()!;
        var acceptedWordsCount = int.Parse(reader.ReadLine()!);
        
        var trie = new Trie();
        for (var i = 0; i < acceptedWordsCount; i++)
            trie.Add(reader.ReadLine()!);
        
        Console.WriteLine(trie.IsPresent(text) ? "YES" : "NO");
    }
}

/// <summary>
/// Перечисление типов нод.
/// </summary>
public enum TrieNodeType
{
    /// <summary>
    /// Терминальные ноды.
    /// Ноды, соответствующие словам, добавленным в префиксное дерево. 
    /// </summary>
    Terminal,
    
    /// <summary>
    /// Промежуточные узлы.
    /// не соответствуют никакому слову, но являются префиксами для одного или нескольких слов,
    /// находящихся в префиксном дереве.
    /// </summary>
    Intermediate 
}

/// <summary>
/// Нода префиксного дерева.
/// </summary>
public class TrieNode
{
    /// <summary>
    /// Дочерние ноды.
    /// </summary>
    public Dictionary<char, TrieNode> Children { get; } = new();

    /// <summary>
    /// Содержимое ноды.
    /// </summary>
    public char Content { get; set; }

    /// <summary>
    /// Тип ноды. По умолчанию ноду считаем промежуточной.
    /// </summary>
    public TrieNodeType NodeType { get; set; } = TrieNodeType.Intermediate;
}

/// <summary>
/// Префиксное дерево.
/// </summary>
public class Trie
{
    /// <summary>
    /// Корень дерева.
    /// </summary>
    private readonly TrieNode _root = new();

    /// <summary>
    /// Добавляет слово в дерево.
    /// </summary>
    /// <param name="word">Слово.</param>
    public void Add(string word)
    {
        var current = _root;

        foreach (var ch in word)
        {
            if (!current.Children.ContainsKey(ch))
            {
                var newNode = new TrieNode { Content = ch };
                current.Children.Add(ch, newNode);
            }

            current = current.Children[ch];
        }

        current.NodeType = TrieNodeType.Terminal;
    }

    /// <summary>
    /// Возвращает индикатор возможности разбиения текста на составные части дерева.
    /// </summary>
    /// <param name="text">Текст.</param>
    /// <returns>Индикатор.</returns>
    public bool IsPresent(string text)
    {
        var dp = new bool[text.Length + 1];
        dp[0] = true;

        for (var i = 0; i < text.Length; i++)
        {
            var current = _root;

            if (!dp[i])
                continue;
            
            for (var j = i; j < text.Length + 1; j++)
            {
                if (current.NodeType is TrieNodeType.Terminal)
                    dp[j] = true;

                if (j == text.Length || !current.Children.ContainsKey(text[j]))
                    break;
                current = current.Children[text[j]];
            }
        }

        return dp[text.Length];
    }
}