using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.BuilderResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ChainsFabrics;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        string s = "connect /home/motp10/Itmo/test -m local";
        IEnumerator<string> enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        enumerator.MoveNext();
        var f = new ParserFabric();
        SimpleParser p = f.Make();
        ParseResultType r = p.Parse(enumerator);
        var connector = new FileSystemConnector();
        if (r is ParseResultType.Success q)
        {
            BuildResultType buildRes = q.Builder.Build();
            if (buildRes is BuildResultType.Success builSuc)
            {
                ICommand com = builSuc.Command;
                com.Execute(connector);
            }
        }

        s = "tree list -d 2";
        enumerator = s.Split(' ').AsEnumerable().GetEnumerator();
        enumerator.MoveNext();
        r = p.Parse(enumerator);
        if (r is ParseResultType.Success res)
        {
            BuildResultType buildRes = res.Builder.Build();
            if (buildRes is BuildResultType.Success builSuc)
            {
                ICommand com = builSuc.Command;
                com.Execute(connector);
            }
        }

        Console.WriteLine();
    }
}