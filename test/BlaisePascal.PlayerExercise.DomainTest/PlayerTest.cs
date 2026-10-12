using BlaisePascal.PlayerExercise.Domain;

namespace BlaisePascal.PlayerExercise.DomainTest
{
    public class PlayerTest
    {
        [Fact]
        public void Player_ShouldStartAtLevel1()
        {
            Player player = new Player("TestPlayer", 1, 100);

            Assert.Equal(1, player.Level);
        }

        [Fact]
        public void Player_ShouldStartWith100Hp()
        {
            Player player = new Player("TestPlayer", 1, 100);

            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void IsAlive_WhenThePlayerIsCreatedHeIsAlive()
        {
            Player player = new Player("TestPlayer", 1, 100);

            Assert.True(player.IsAlive());
        }

        [Fact]
        public void TakeDamage_WhenThePlayerHas100HpAndHeTake1DamgeHeHas99Hp()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.TakeDamage(1);

            Assert.Equal(99, player.Health);
        }

        [Fact]
        public void IsAlive_WhenThePlayerHas0HpHeIsDead()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.TakeDamage(100);

            Assert.False(player.IsAlive());
        }

        [Fact]
        public void AddExo_WhenThePlayerHas0ExpAndAdd1HeHas1Exp()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.AddExp(1);

            Assert.Equal(1, player.Experience);
        }

        [Fact]
        public void LevelUp_WhenThePlayerHas100ExpHeLevelUpByOne()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.AddExp(100);
            player.LevelUp();

            Assert.Equal(2, player.Level);

        }

        [Fact]
        public void LevelUp_WhenThePlayerHas200ExpHeLevelUpByTwo()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.AddExp(200);
            player.LevelUp();

            Assert.Equal(2, player.Level);

        }

        [Fact]
        public void LevelUp_WhenThePlayerHasLessThan100ExpHeCannotLevelUp()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.AddExp(99);

            Assert.Throws<Exception>(player.LevelUp);
            /* Non ho idea del perché fuznioni ma vabbé, senza parentesi vale come system.atcion, con le parentesi lo conta
               come void e quindi non va, ma perché se è void non va?
            */
        }

        [Fact]
        public void Healing_WhenPlayerHas100HpAndTake2DamageAndHealsBy1HpHeHas99Hp()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.TakeDamage(2);
            player.Healing(1);

            Assert.Equal(99, player.Health);
        }

        [Fact]
        public void Healing_WhenPlayerHas100HpAndTake2DamageAndHealsBy3HpHeHas100Hp()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.TakeDamage(2);
            player.Healing(3);

            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void Healing_InsertingANegativeValueInHealingThrowsAnException()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.TakeDamage(2);
            Assert.Throws<Exception>(() => player.Healing(-1));
        }

        [Fact]
        public void Healing_WhenPlayerIsDeadHeCannotHeal()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.TakeDamage(100);

            Assert.Throws<Exception>(() => player.Healing(1));
            // La soluzione me l'ha data l'AI, in classe approfondisco, ho provato in altri modi che conosco ma non andava
        }

        [Fact]
        public void ResetExperience_AfterResettingExperienceIfYouHadAtLeast1ItReturnTo0()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.AddExp(1);
            player.ResetExperience();

            Assert.Equal(0, player.Experience);
        }

        [Fact]
        public void ResetExperience_YouCannotResetExperienceIfItIsAlready0()
        {
            Player player = new Player("TestPlayer", 1, 100);
            Assert.Throws<Exception>(() => player.ResetExperience());
        }

        [Fact]
        public void ResetHealth_YouCannotResetHealthIfItIsAlreadyAtMaximum()
        {
            Player player = new Player("TestPlayer", 1, 100);

            Assert.Throws<Exception>(() => player.ResetHealth());
        }

        [Fact]
        public void ResetHealth_AfterResettingHealthIfYouHadLessThanTheMaximumHealthItReturnToMax()
        {
            Player player = new Player("TestPlayer", 1, 100);
            player.TakeDamage(1);
            player.ResetHealth();

            Assert.Equal(100, player.Health);
        }
    }
}
