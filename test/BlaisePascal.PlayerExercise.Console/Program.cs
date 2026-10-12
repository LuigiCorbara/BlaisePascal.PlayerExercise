using BlaisePascal.PlayerExercise.Domain;
using static System.Console;

public class Program
{
    public static void Main()
    {
        Player player = new Player("Pippo", 1, 100, 0);
        WriteLine($"Name {player.Name}");
        WriteLine($"Level {player.Level}");
        WriteLine($"Max health {player.MaxHealth}");
        WriteLine($"Health {player.Health}");
        WriteLine($"player is alive: {player.IsAlive()}");
        player.TakeDamage(100);
        player.Healing(49);
        WriteLine($"Health after taking damage and healing {player.Health}");
        player.ResetHealth();
        WriteLine($"Health after reset {player.Health}");
    }
}