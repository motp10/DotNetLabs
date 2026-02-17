using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.BuilderResultType;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

public interface ICommandBuilder
{
    BuildResultType Build();
}