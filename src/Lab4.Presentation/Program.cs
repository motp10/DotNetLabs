namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        string s = "file copy";
        IEnumerator<string> enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        int x = 0;
        while (enumerator.MoveNext())
        {
            ++x;
            Console.WriteLine(enumerator.Current);
        }

        Console.WriteLine(x);
    }
}