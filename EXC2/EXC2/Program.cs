internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Soma(20));

        static int Soma(int number, int total = 0)
        {
            if (number == 1)
            {
                return 1 + total;
            }
            else if (number > 1)
            {
                total += 2 * number - 1;
                return Soma(number - 1, total);
            }
            return 0;
        }
    }
}