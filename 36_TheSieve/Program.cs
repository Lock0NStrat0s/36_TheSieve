namespace _36_TheSieve;

class Program
{
    static void Main(string[] args)
    {
        int selection = GetFilter();
        FilterWithSieve(selection);
    }

    static int GetFilter()
    {
        int selection;
        do
        {
            Console.Write("Filters:\n1 - Even\n2 - Positive\n3 - Multiple of Ten\nYour selection: ");
            int.TryParse(Console.ReadLine(), out selection);
        } while (selection < 1 || selection > 3);

        return selection;
    }

    static void FilterWithSieve(int selection)
    {
        Sieve sieve = selection switch
        {
            1 => new Sieve(IsEven),
            2 => new Sieve(IsPositive),
            3 => new Sieve(IsMultipleOfTen)
        };

        AskForNumber(sieve);
    }

    static void AskForNumber(Sieve sieve)
    {
        int number;
        bool toContinue;

        do
        {
            Console.Write("Enter number (non-number to exit): ");
            toContinue = int.TryParse(Console.ReadLine(), out number);

            if (toContinue)
            {
                Console.WriteLine(sieve.IsGood(number) ? "PASS!" : "FAIL!"); 
            }

        } while (toContinue);
    }

    static bool IsEven(int number) => number % 2 == 0;
    static bool IsPositive(int number) => number > 0;
    static bool IsMultipleOfTen(int number) => number % 10 == 0;
}
