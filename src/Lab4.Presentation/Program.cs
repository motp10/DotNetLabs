using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ChainsFabrics;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        string s = "connect /home/motp10/Itmo -m local";
        IEnumerator<string> enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        enumerator.MoveNext();
        var f = new ParserFabric();
        SimpleParser p = f.Make();
        ParseResultType r = p.Parse(enumerator);
        var connector = new FileSystemConnector();
        if (r is ParseResultType.Success q)
        {
            ICommand com = q.Builder.Build();
            com.Execute(connector);
        }

        s = "tree list -kj -uu -d 1";
        enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        enumerator.MoveNext();
        r = p.Parse(enumerator);
        if (r is ParseResultType.Success res)
        {
            ICommand com = res.Builder.Build();
            com.Execute(connector);
        }

        Console.WriteLine();
    }
}