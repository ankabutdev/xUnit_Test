namespace xUnit_Demo.MathExtensions;

public static class MathExtension
{
    public static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i < number; i++)
        {
            if (i % 2 == 0)
            {
                return false;
            }
        }

        return true;
    }
}
