namespace SortingEnemys.enemys
{
    class Enemy
    {
        private string Name;
        private int Level;
        private int Health;
        private int Attack;
        private int Defense;
        private int Speed;

        public Enemy(string Name, int Level, int Health, int Attack, int Defense, int Speed)
        {
            this.Name = Name;
            this.Level = Level;
            this.Health = Health;
            this.Attack = Attack;
            this.Defense = Defense;
            this.Speed = Speed;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public int GetLevel()
        {
            return Level;
        }

        public void SetLevel(int level)
        {
            Level = level;
        }

        public int GetHealth()
        {
            return Health;
        }

        public void SetHealth(int health)
        {
            Health = health;
        }

        public int GetAttack()
        {
            return Attack;
        }

        public void SetAttack(int attack)
        {
            Attack = attack;
        }

        public int GetDefense()
        {
            return Defense;
        }

        public void SetDefense(int defense)
        {
            Defense = defense;
        }

        public int GetSpeed()
        {
            return Speed;
        }

        public void SetSpeed(int speed)
        {
            Speed = speed;
        }

    }
}
