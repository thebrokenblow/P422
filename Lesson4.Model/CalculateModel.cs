using System.Numerics;

namespace Lesson4.Model;

public class CalculateModel
{
    public static string Sum(string a, string b)
    {
        var (error, numberA) = ValidateNumber(nameof(a), a);

        if (error != string.Empty)
        {
            return error;
        }

        (error, var numberB) = ValidateNumber(nameof(b), b);

        if (error != string.Empty)
        {
            return error;
        }

        var sum = numberA + numberB;

        return sum.ToString();
    }

    private static (string, int) ValidateNumber(string nameVariable, string strNumber)
    {
        if (string.IsNullOrEmpty(strNumber))
        {
            return ($"Переменная {nameVariable} пуста", 0);
        }

        if (!int.TryParse(strNumber, out int number))
        {
            return ($"Переменная {nameVariable}, не число: {number}", 0);
        }

        return (string.Empty, number);
    }
}
