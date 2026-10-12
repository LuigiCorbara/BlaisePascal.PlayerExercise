using System.ComponentModel.DataAnnotations;
using System;
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


        public int Damage { get; private set; }

        //costruttore
        public Player(string name, int level, int maxHealth, int gold)
        {
            Name = name;
            Level = level;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Gold = gold;
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
        }

        public void Healing(int HpCured)
        {
            if (Health == 0)
            {
                throw new ArgumentException("Player is dead, cannot healed.");

            } else if (HpCured > 0 && Health < MaxHealth)
            {
                Health += HpCured;
            }
        }

        public void ResetHealth()
        {
            Health = MaxHealth;
        }
    }
}

