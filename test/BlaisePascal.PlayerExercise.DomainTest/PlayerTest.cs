using BlaisePascal.PlayerExercise.Domain;

namespace BlaisePascal.PlayerExercise.DomainTest
{
    public class PlayerTest
    {
        [Fact]
        public void Player_ShouldStartAtLevel1()
        {
            Player player = new Player("TestPlayer", 1, 100, 0);

            Assert.Equal(1, player.Level);
        }
    }
}
