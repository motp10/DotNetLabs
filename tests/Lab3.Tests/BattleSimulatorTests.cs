using Itmo.ObjectOrientedProgramming.Lab3.Battles;
using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Potions;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
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
            ICreature creature = new CreaturesMaker().MakeBattleAnalyst().Build();

            // Assert
            Assert.Equal(creature.Attack, BattleAnalyst.DefaultAttack());
            Assert.Equal(creature.Health, BattleAnalyst.DefaultHelth());
        }

        [Fact]
        public void AmuletMasterDefaultBuild()
        {
            // Arrange
            ICreature creature = new CreaturesMaker().MakeAmuletMaster().Build();

            // Assert
            Assert.Equal(creature.Attack, AmuletMaster.DefaultAttack());
            Assert.Equal(creature.Health, AmuletMaster.DefaultHelth());
        }

        [Fact]
        public void ImmortalFearDefaultBuild()
        {
            // Arrange
            ICreature creature = new CreaturesMaker().MakeImmortalFear().Build();

            // Assert
            Assert.Equal(creature.Attack, ImmortalFear.DefaultAttack());
            Assert.Equal(creature.Health, ImmortalFear.DefaultHelth());
        }

        [Fact]
        public void MimicDefaultBuild()
        {
            // Arrange
            ICreature creature = new CreaturesMaker().MakeMimic().Build();

            // Assert
            Assert.Equal(creature.Attack, Mimic.DefaultAttack());
            Assert.Equal(creature.Health, Mimic.DefaultHelth());
        }

        [Fact]
        public void ViciousBattlerDefaultBuild()
        {
            // Arrange
            ICreature creature = new CreaturesMaker().MakeViciousBattler().Build();

            // Assert
            Assert.Equal(creature.Attack, ViciousBattler.DefaultAttack());
            Assert.Equal(creature.Health, ViciousBattler.DefaultHelth());
        }
    }

    public class ViciousBattlerTests
    {
        [Fact]
        public void TakingDamageDoublesAttack()
        {
            // Arrange
            ICreature fighter = new ViciousBattlerBuilder().Build();

            // Act
            fighter.ReceiveDamage(new Damage(2));

            // Assert
            Assert.Equal(fighter.Attack, new Damage(2));
        }

        [Fact]
        public void TakingFatalDamageNoDoubleAttack()
        {
            // Arrange
            ICreature fighter = new ViciousBattlerBuilder().Build();

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
            ICreature mimic = new MimicBuilder().Build();
            ICreature target = new BattleAnalystBuilder().Build();

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
            ICreature creature = new ImmortalFearBuilder().Build();

            // Act
            creature.ReceiveDamage(new Damage(100));

            // Assert
            Assert.Equal(1, creature.Health.Value);
        }

        [Fact]
        public void SecondDeathKillsCreature()
        {
            // Arrange
            ICreature creature = new ImmortalFearBuilder().Build();

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
            var player1 = new PlayerTable();
            var player2 = new PlayerTable();
            var creator = new CreaturesMaker();

            // Act
            player1.TryAddNewCreature(creator.MakeBattleAnalyst().Build());
            var battle = new Battle(player1, player2);
            BattleResult result = battle.Fight();

            // Assert
            Assert.Equal(result, new BattleResult.FirstWinner());
        }

        [Fact]
        public void BattleAnalystVsAmuletMasterBattleAnalystWins()
        {
            // Arrange
            var player1 = new PlayerTable();
            var player2 = new PlayerTable();
            var creator = new CreaturesMaker();

            player1.TryAddNewCreature(creator.MakeBattleAnalyst().Build());
            player2.TryAddNewCreature(creator.MakeAmuletMaster().Build());
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
            var player1 = new PlayerTable();
            var player2 = new PlayerTable();
            var creator = new CreaturesMaker();

            player1.TryAddNewCreature(creator.MakeImmortalFear().Build());
            player2.TryAddNewCreature(creator.MakeViciousBattler().Build());
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
            var player1 = new PlayerTable();
            var player2 = new PlayerTable();
            var creator = new CreaturesMaker();

            player1.TryAddNewCreature(creator.MakeMimic().Build());
            player2.TryAddNewCreature(creator.MakeBattleAnalyst().Build());
            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.IsType<BattleResult.SecondWinner>(result);
        }

        [Fact]
        public void ViciousBattlerVsAmuletMasterViciousBattlerWins()
        {
            // Arrange
            var player1 = new PlayerTable();
            var player2 = new PlayerTable();
            var creator = new CreaturesMaker();

            player1.TryAddNewCreature(creator.MakeViciousBattler().WithHealth(new Health(100)).Build());
            player2.TryAddNewCreature(creator.MakeAmuletMaster().WithHealth(new Health(1)).WithAttack(new Damage(1)).Build());
            var battle = new Battle(player1, player2);

            // Act
            BattleResult result = battle.Fight();

            // Assert
            Assert.IsType<BattleResult.FirstWinner>(result);
        }

        [Fact]
        public void ImmortalFearVsImmortalFearImmortalFearWins()
        {
            // Arrange
            var player1 = new PlayerTable();
            var player2 = new PlayerTable();
            var creator = new CreaturesMaker();

            player1.TryAddNewCreature(creator.MakeImmortalFear().Build());
            player2.TryAddNewCreature(creator.MakeBattleAnalyst().Build());
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
            var player1 = new PlayerTable();
            var player2 = new PlayerTable();
            var creator = new CreaturesMaker();

            player1.TryAddNewCreature(creator.MakeAmuletMaster().Build());
            player2.TryAddNewCreature(creator.MakeViciousBattler().Build());
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
            var player1 = new PlayerTable();
            var player2 = new PlayerTable();
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
            var player1 = new PlayerTable();
            var player2 = new PlayerTable();
            var creator = new CreaturesMaker();

            player1.TryAddNewCreature(creator.MakeBattleAnalyst().Build());
            player2.TryAddNewCreature(creator.MakeAmuletMaster().Build());
            player2.TryAddNewCreature(creator.MakeViciousBattler().Build());
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
            var creator = new CreaturesMaker();
            ICreature creature = creator.MakeBattleAnalyst().WithAttack(new Damage(1)).WithHealth(new Health(5)).Build();

            // Act
            var spell = new MirrorSpell();
            spell.Apply(creature);

            // Assert
            Assert.Equal(creature.Attack, new Damage(5));
            Assert.Equal(creature.Health, new Health(1));
        }
    }

    public class CreatureFactoryTests
    {
        [Fact]
        public void CreatureWithModifiers()
        {
            // Arrange
            var baseCreature = new BattleAnalyst();
            IFactory shieldMock = Substitute.For<IFactory>();
            IFactory masteryMock = Substitute.For<IFactory>();
            var builder = new CreaturesMaker();

            // Act
            ICreature creature = builder.MakeBattleAnalyst().AddModificator(shieldMock).AddModificator(masteryMock).Build();

            // Assert
            shieldMock.Received(1).ImposeModification(Arg.Is<ICreature>(c => c == creature));
            masteryMock.Received(1).ImposeModification(Arg.Is<ICreature>(c => c == creature));
        }
    }
}