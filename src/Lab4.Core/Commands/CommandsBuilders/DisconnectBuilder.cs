using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.BuilderResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class DisconnectBuilder : ICommandBuilder
{
    public BuildResultType Build()
    {
        return new BuildResultType.Success(new Disconnect());
    }
}