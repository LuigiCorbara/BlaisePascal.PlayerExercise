using System.ComponentModel.DataAnnotations;
using System.Net.Security;

namespace BlaisePascal.PlayerExercise.Domain
{
    public class Player
    {

        public int Experience { get; private set; }

        public int MaxHealth { get; private set; }

        public int Gold { get; private set; }

        public string Name { get; set; }

        //attribute
        private int _level;
        public int Level
        {
            get
            {
                return _level;
            }
            private set
            {
                if (value < 0)
                {
                    _level = 1;
                }
                else
                {
                    _level = value;
                }
            }
        }

        public int Health { get; private set; }

        //costruttore
        public Player(string name, int level, int maxHealth)
        {
            Name = name;
            Level = level;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Gold = 0;
            Experience = 0;

        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                Health -= damage;
            }
        }

        public void AddExp(int exp)
        {
            if (exp > 0)
            {
                Experience += exp;
            }
            else
            {
                throw new Exception("Experience cannot be negative.");
            }
        }
        public void ResetExperience()
        {
            if (Experience == 0)
            {
                throw new Exception("Experience is already at zero.");
            }
            Experience = 0;
        }

        public void Healing(int HpCured)
        {
            if (Health <= 0)
            {
                throw new Exception("Player is dead and cannot be healed.");
            }
            else if (HpCured <= 0)
            {
                throw new Exception("Healing amount cannot be zero or negative.");
            }
            else if (Health + HpCured > MaxHealth)
            {
                Health = MaxHealth;
            }
            else if(HpCured > 0 && Health < MaxHealth)
            {
                Health += HpCured;
            }
        }

        public void ResetHealth()
        {
            if (Health == MaxHealth)
            {
                throw new Exception("Health is already at maximum.");
            }
            Health = MaxHealth;

        }

        public void LevelUp() 
        {
            int expRequiredToLevelUp = 100;

            if (Experience < expRequiredToLevelUp)
            {
                throw new Exception("Not enough exp to level up.");
            }
           
            while (Experience >= expRequiredToLevelUp)
            {
                Level++;
                Experience -= expRequiredToLevelUp;
                expRequiredToLevelUp = Level * 100;
            }
        }
    }
}
