﻿namespace Ya.Practicum.SprintSeven.Finals;

/// <summary>
/// На Алгосах устроили турнир по настольному теннису.
/// Гоша выиграл n партий, получив при этом некоторое количество очков за каждую из них.
/// Гоше стало интересно, можно ли разбить все заработанные им во время турнира очки на две части так,
/// чтобы сумма в них была одинаковой.
/// </summary>
/// ====================================================================================================================
/// https://contest.yandex.ru/contest/25597/run-report/89515706/
/// ====================================================================================================================
/// -- Принцип работы алгоритма --
/// Алгоритм работает за счет составления массива из булевых значений.
/// dp[i] обозначает можем ли мы собрать сумма i из просмотренных очков.
///
/// Длина массива - половины суммы всех заработанных очков.
///
/// -- Доказательство корректности --
/// Алгоритм реализован с помощью динамического программироания.
/// Для того, чтобы узнать можем ли мы разделить все очки на две группы, сумма в которых будет одинакова
/// достаточно  оперделить что существует сумма, равная половине сумме очков.
///
/// Так же рассмотрены некоторые случаи, поволяющие дать ответ заранее:
/// 1) сумма очков - нечетное число - в таком случа можно сразу сказать что невозможно разделить элементы на две части
/// , так чтобы сумма в них была одинакова
/// 2) один из элементов исходного массива очков - больше половины суммы - в таком случает так же можно сделалть вывод,
/// о невозможности разделить элементы на две части, так чтобы сумма в них была одинакова
/// 3) один из элементов - равен половине суммы очков - в таком случае исходный массив можно разделить на две части,
/// суммы очков в которых будут одинаковыми
///
/// -- Временная сложноть --
/// Временная сложность алгоритма - O(N * Sum(N)/2)
///
/// -- Пространственная сложность --
/// Пространственная сложность алгоритма - O(Sum(N)/2) - такое количество памяти потребуется для хранения
/// массива булевых значений
public static class BEqualSums
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var _ = int.Parse(reader.ReadLine()!);
        var scores = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        
        Console.WriteLine(CanSplitIntoEqualHeaps(scores));
    }

    private static bool CanSplitIntoEqualHeaps(List<int> scores)
    {
        var sum = scores.Sum();

        if (sum % 2 is not 0)
            return false;

        var dp = Enumerable.Range(0, sum / 2 + 1).Select(_ => false).ToArray();
        dp[0] = true;

        foreach (var score in scores)
        {
            switch (score.CompareTo(sum / 2))
            {
                case 0:
                    return true;
                
                case > 0:
                    return false;
               
                default:
                    for (var i = sum / 2; i > score - 1; i--) 
                        dp[i] = dp[i - score] || dp[i];
                    break;
            }
        }

        return dp[^1];
    }
}