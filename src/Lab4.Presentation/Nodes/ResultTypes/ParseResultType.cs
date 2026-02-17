using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

public class ParseResultType
{
    public class Success : ParseResultType
    {
        public ICommandBuilder Builder { get; }

        public Success(ICommandBuilder builder)
        {
            Builder = builder;
        }
    }

    public class Failure : ParseResultType { }
}