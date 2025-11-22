using Itmo.ObjectOrientedProgramming.Lab3.Battles;
using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Potions;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.TableBuilders;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class BattleSimulatorTests
{
    public class DefaultBuildTests
    {
        [Fact]
        public void BattleAnalystDefaultBuild()
        {
            // Arrange
            ICreature creature = new BattleAnalystFactory().MakeBuilder().Build();

            // Assert
            Assert.Equal(creature.Attack, new Damage(2));
            Assert.Equal(creature.Health, new Health(4));
        }

        [Fact]
        public void AmuletMasterDefaultBuild()
        {
            // Arrange
            ICreature creature = new AmuletMasterFactory().MakeBuilder().Build();

            // Assert
            Assert.Equal(creature.Attack, new Damage(5));
            Assert.Equal(creature.Health, new Health(2));
        }

        [Fact]
        public void ImmortalFearDefaultBuild()
        {
            // Arrange
            ICreature creature = new ImmortalFearFactory().MakeBuilder().Build();

            // Assert
            Assert.Equal(creature.Attack, new Damage(4));
            Assert.Equal(creature.Health, new Health(4));
        }

        [Fact]
        public void MimicDefaultBuild()
        {
            // Arrange
            ICreature creature = new MimicFactory().MakeBuilder().Build();

            // Assert
            Assert.Equal(creature.Attack, new Damage(1));
            Assert.Equal(creature.Health, new Health(1));
        }

        [Fact]
        public void ViciousBattlerDefaultBuild()
        {
            // Arrange
            ICreature creature = new ViciousBattlerFactory().MakeBuilder().Build();

            // Assert
            Assert.Equal(creature.Attack, new Damage(1));
            Assert.Equal(creature.Health, new Health(6));
        }
    }

    public class ViciousBattlerTests
    {
        [Fact]
        public void TakingDamageDoublesAttack()
        {
            // Arrange
            ICreature fighter = new ViciousBattlerFactory().MakeBuilder().Build();

            // Act
            fighter.ReceiveDamage(new Damage(2));

            // Assert
            Assert.Equal(fighter.Attack, new Damage(2));
        }

        [Fact]
        public void TakingFatalDamageNoDoubleAttack()
        {
            // Arrange
            ICreature fighter = new ViciousBattlerFactory().MakeBuilder().Build();

            // Act
            fighter.ReceiveDamage(new Damage(20));

            // Assert
            Assert.True(fighter.IsDead());
            Assert.Equal(fighter.Attack, new Damage(1));
        }
    }

    public class MimicTests
    {
        [Fact]
        public void CopiesMaxStatsFromOpponent()
        {
            // Arrange
            ICreature mimic = new MimicFactory().MakeBuilder().Build();
            ICreature target = new BattleAnalystFactory().MakeBuilder().Build();
            ICreature fighter = new ViciousBattlerFactory().MakeBuilder().Build();

            // Act
            mimic.CauseDamage(target);

            // Assert
            Assert.Equal(mimic.Attack, new Damage(2));
        }
    }

    public class ImmortalFearTests
    {
        [Fact]
        public void FirstDeathResurrectsWithOneHealth()
        {
            // Arrange
            ICreature creature = new ImmortalFearFactory().MakeBuilder().Build();

            // Act
            creature.ReceiveDamage(new Damage(100));

            // Assert
            Assert.Equal(1, creature.Health.Value);
        }

        [Fact]
        public void SecondDeathKillsCreature()
        {
            // Arrange
            ICreature creature = new ImmortalFearFactory().MakeBuilder().Build();

            // Act
            creature.ReceiveDamage(new Damage(100));
            creature.ReceiveDamage(new Damage(100));

            // Assert
            Assert.True(creature.IsDead());
        }
    }

    public class FightTests
    {
        [Fact]
        public void FirstHasCreatureSecondHAsNothingFIrstWins()
        {
            // Arrange
            ICreature creature = new BattleAnalystFactory().MakeBuilder().Build();
            PlayerTable player1 = new TableBuilder().AddCreature(creature).WithPeacker(new CreaturePeaker()).Build();
            PlayerTable player2 = new TableBuilder().WithPeacker(new CreaturePeaker()).Build();

            // Act
            var battle = new Battle(player1, player2);
            BattleResult result = battle.Fight();

            // Assert
            Assert.Equal(result, new BattleResult.FirstWinner());
        }

        [Fact]
        public void BattleAnalystVsAmuletMasterBattleAnalystWins()
        {
            // Arrange
            PlayerTable player1 = new TableBuilder().AddCreature(new BattleAnalystFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();
            PlayerTable player2 = new TableBuilder().AddCreature(new AmuletMasterFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();
            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.IsType<BattleResult.SecondWinner>(result);
        }

        [Fact]
        public void ImmortalFearVsViciousBattlerImmortalFearWins()
        {
            // Arrange
            PlayerTable player1 = new TableBuilder().AddCreature(new ImmortalFearFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();
            PlayerTable player2 = new TableBuilder().AddCreature(new ViciousBattlerFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();

            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.IsType<BattleResult.FirstWinner>(result);
        }

        [Fact]
        public void MimicVsBattleAnalystMimicWins()
        {
            // Arrange
            PlayerTable player1 = new TableBuilder().AddCreature(new MimicFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();
            PlayerTable player2 = new TableBuilder().AddCreature(new BattleAnalystFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();

            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.IsType<BattleResult.SecondWinner>(result);
        }

        [Fact]
        public void ViciousBattlerVsAmuletMasterAmuletMasterWins()
        {
            // Arrange
            PlayerTable player1 = new TableBuilder().AddCreature(new ViciousBattlerFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();
            PlayerTable player2 = new TableBuilder().AddCreature(new AmuletMasterFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();

            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.IsType<BattleResult.SecondWinner>(result);
        }

        [Fact]
        public void ImmortalFearVsImmortalFearImmortalFearWins()
        {
            // Arrange
            PlayerTable player1 = new TableBuilder().AddCreature(new ImmortalFearFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();
            PlayerTable player2 = new TableBuilder().AddCreature(new BattleAnalystFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();

            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.IsType<BattleResult.FirstWinner>(result);
        }

        [Fact]
        public void AmuletMasterVsViciousBattlerAmuletMasterWins()
        {
            // Arrange
            PlayerTable player1 = new TableBuilder().AddCreature(new AmuletMasterFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();
            PlayerTable player2 = new TableBuilder().AddCreature(new ViciousBattlerFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();

            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void EmptyTeamVsEmptyTeamDraw()
        {
            // Arrange
            var player1 = new PlayerTable(new List<ICreature>(), new CreaturePeaker());
            var player2 = new PlayerTable(new List<ICreature>(), new CreaturePeaker());
            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.IsType<BattleResult.Draw>(result);
        }

        [Fact]
        public void SingleCreatureVsMultipleTeamWithMoreCreaturesWins()
        {
            // Arrange
            PlayerTable player1 = new TableBuilder().AddCreature(new BattleAnalystFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();
            PlayerTable player2 = new TableBuilder().AddCreature(new AmuletMasterFactory().MakeBuilder().Build())
                                                    .AddCreature(new ViciousBattlerFactory().MakeBuilder().Build()).WithPeacker(new CreaturePeaker()).Build();

            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.IsType<BattleResult.SecondWinner>(result);
        }
    }

    public class SpellsTests
    {
        [Fact]
        public void MirrorSpellTest()
        {
            // Arrange
            ICreature creature = new BattleAnalystFactory().MakeBuilder().WithHealth(new Health(5)).WithAttack(new Damage(1)).Build();

            // Act
            var spell = new MirrorSpell();
            ICreature newCreature = spell.Apply(creature);

            // Assert
            Assert.Equal(newCreature.Attack, new Damage(5));
            Assert.Equal(newCreature.Health, new Health(1));
        }
    }

    public class CreatureFactoryTests
    {
        [Fact]
        public void CreatureWithModifiers()
        {
            // Arrange
            ICreature baseCreature = new BattleAnalystFactory().MakeBuilder().Build();
            IModificatorFactory shieldMock = Substitute.For<IModificatorFactory>();
            IModificatorFactory attackMock = Substitute.For<IModificatorFactory>();

            // Act
            ICreature creature = new BattleAnalystFactory().MakeBuilder().AddModificator(shieldMock).AddModificator(attackMock).Build();

            // Assert
            shieldMock.Received(1).ImposeModification(Arg.Is<ICreature>(c => c == creature));
            attackMock.Received(1).ImposeModification(Arg.Is<ICreature>(c => c == creature));
        }
    }
}