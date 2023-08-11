namespace Ya.Practicum.SprintEight;

/// <summary>
/// Представьте, что вы работаете пограничником и постоянно проверяете документы людей по записи из базы.
/// При этом допустима ситуация, когда имя человека в базе отличается от имени в паспорте на одну замену,
/// одно удаление или одну вставку символа. Если один вариант имени может быть получен из другого удалением
/// одного символа, то человека пропустят через границу. А вот если есть какое-либо второе изменение,
/// то человек грустно поедет домой или в посольство.
/// Например, если первый вариант —– это «Лена», а второй — «Лера», то девушку пропустят. Также человека пропустят,
/// если в базе записано «Коля», а в паспорте — «оля»
/// Однако вариант, когда в базе числится «Иннокентий», а в паспорте написано «ннакентий», уже не сработает.
/// Не пропустят также человека, у которого в паспорте записан «Иинннокентий», а вот «Инннокентий» спокойно пересечёт границу.
/// Напишите программу, которая сравнивает имя в базе с именем в паспорте и решает, пропускать человека или нет.
/// В случае равенства двух строк — путешественника, естественно, пропускают.
/// </summary>
public static class BBorderControl
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var firstString = reader.ReadLine()!;
        var secondString = reader.ReadLine()!;
        
        Console.WriteLine(isOneEditDistance(firstString, secondString) ? "OK" : "FAIL");
    }

    private static bool isOneEditDistance(string first, string second)
    {
        if (Math.Abs(first.Length - second.Length) > 1)
            return false;

        if (first.Length > second.Length)
            return isOneEditDistance(second, first);

        var hasEdit = false;

        var i = 0;
        var j = 0;
        while (i < first.Length && j < second.Length)
        {
            if (first[i] == second[j])
            {
                i++;
                j++;
            }
            else
            {
                if (hasEdit)
                    return false;
                
                hasEdit = true;

                if (first.Length == second.Length)
                {
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }
        }

        return true;
    }
}