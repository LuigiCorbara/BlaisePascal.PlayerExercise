namespace BlaisePascal.PlayerExercise.Domain
{
    public class Player
    {
        //attribute
        private int _health;
        private int _level;

        public string Name { get; set; }



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

           

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else if (value > 100)
                {
                    _health = 100;
                }
                else
                {
                    _health = value;
                }
            }
        }

        public int Damage { get; private set; }

        //costruttore
        public Player(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public bool IsAlive()
        {
            return _health > 0;
        }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                Health -= damage;
            }
        }
    }

}

