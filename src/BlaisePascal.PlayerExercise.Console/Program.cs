using BlaisePascal.PlayerExercise.Domain;
using static System.Console;

public class Program
{
    public static void Main()
    {
       
        try
        {
            Player player = new Player("Pippo", 1, 100);
            WriteLine($"Name {player.Name}");
            WriteLine($"Level {player.Level}");
            WriteLine($"Max health {player.MaxHealth}");
            WriteLine($"Health {player.Health}");
            WriteLine($"player is alive: {player.IsAlive()}");
            player.AddExp(101);
            player.TakeDamage(50);
            player.Healing(49);
            WriteLine($"Health after taking damage and healing {player.Health}");
        }
        catch(Exception ex)
        {
            WriteLine(ex.Message);
        }
    }
}