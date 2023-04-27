using System.Text.RegularExpressions;

namespace Ya.Practicum.SprintTwo;

/// <summary>
/// Вот какую задачу Тимофей предложил на собеседовании одному из кандидатов.
/// Если вы с ней ещё не сталкивались, то наверняка столкнётесь –— она довольно популярная.
///
/// Дана скобочная последовательность. Нужно определить, правильная ли она.
/// Будем придерживаться такого определения:
///     пустая строка —– правильная скобочная последовательность;
///     правильная скобочная последовательность, взятая в скобки одного типа, –— правильная скобочная последовательность;
///     правильная скобочная последовательность с приписанной слева или справа правильной скобочной последовательностью —– тоже правильная.
///
/// На вход подаётся последовательность из скобок трёх видов: [], (), {}.
/// Напишите функцию is_correct_bracket_seq, которая принимает на вход скобочную последовательность и возвращает True,
/// если последовательность правильная, а иначе False.
///
/// Спасибо кодварсу :)
/// https://github.com/protomorphine/CodeWars.Training/blob/master/CodeWars.Tests/KataTrainer.cs#L236
/// </summary>
public static class HValidParentheses
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var input = reader.ReadLine()!;

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(ValidParentheses(input));
    }

    private static bool ValidParentheses(string input)
    {
        // пустая строка - валидная последовательность;
        if (input.Length == 0)
            return true;

        // Вариант 1: через string.Replace(...)
        // const string roundBracketsValidCombination = "()";
        // const string squareBracketsValidCombination = "[]";
        // const string curlyBracketsValidCombination = "{}";

        // массив "разрешенных" символов
        var allowed = new[] {')', '(', ']', '[', '}', '{'};

        // строка, состаящая только из разрешенных символов
        // на случай, если в строке есть еще и другие символы
        var clearString = string.Join("", input.Where(it => allowed.Contains(it)));

        // Вариант 2: через RegEx
        var bracketRegEx = new Regex(@"[(][)]|[\[][\]]|[\{][\}]");
        var replaced = bracketRegEx.Replace(clearString, string.Empty);
            // clearString.Replace(roundBracketsValidCombination, "")
            // .Replace(squareBracketsValidCombination, "")
            // .Replace(curlyBracketsValidCombination, "");

        return clearString.Length != replaced.Length && ValidParentheses(replaced);
    }
}