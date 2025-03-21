using static _36_TheSieve.Program;

namespace _36_TheSieve;

class Sieve
{
    public delegate bool FilterDelegate(int number);
    private FilterDelegate FilterDel;

    public Sieve(FilterDelegate filterDel)
    {
        FilterDel = filterDel;
    }

    public bool IsGood(int number)
    {
        return FilterDel.Invoke(number);
    }
}