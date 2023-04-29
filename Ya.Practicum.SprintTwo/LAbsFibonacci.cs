namespace Ya.Practicum.SprintTwo;

/// <summary>
/// У Тимофея было n(0≤n≤32) стажёров.
/// Каждый стажёр хотел быть лучше своих предшественников,
/// поэтому i-й стажёр делал столько коммитов, сколько делали два предыдущих стажёра в сумме.
/// Два первых стажёра были менее инициативными —– они сделали по одному коммиту.
///
/// <br />Пусть Fi —– число коммитов, сделанных i-м стажёром (стажёры нумеруются с нуля).
/// <br />Тогда выполняется следующее: F0 = F1 = 1.
/// <br />Для всех i ≥ 2 выполнено Fi = Fi-1 + Fi-2.
/// <br />Определите, сколько кода напишет следующий стажёр –— найдите Fn.
/// <br /> <br />
/// <b>Как найти k последних цифр</b><br />
/// Чтобы вычислить k последних цифр некоторого числа x, достаточно взять остаток от его деления на число 10k.
/// Эта операция обозначается как x mod 10k. Узнайте, как записывается операция взятия остатка
/// по модулю в вашем языке программирования.
/// Также обратите внимание на возможное переполнение целочисленных типов, если в вашем языке такое случается.
/// </summary>
public static class LAbsFibonacci
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var nums = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();

        var lPointer = 1;
        var rPointer = 1;

        var pow = Math.Pow(10, nums[1]);
        for (var i = 2; i < nums[0] + 1; i++)
        {
            var res = (int) ((lPointer + rPointer) % pow);
            lPointer = rPointer;
            rPointer = res;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(rPointer);
    }
}