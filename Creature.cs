abstract class Creature
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }

        
        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        
        public abstract void Attack();

        
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[Имя: {Name} | HP: {Health}]");
        }

        
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} получает {damage} урона. Осталось HP: {Health}");
        }
    }

    
    class Warrior : Creature
    {
        public int Armor { get; set; }

        
        public Warrior(string name, int health, int armor) 
            : base(name, health)
        {
            Armor = armor;
        }

        
        public override void Attack()
        {
            Console.WriteLine($" Воин {Name} рубит врага тяжелым мечом!");
        }

       
        public override void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - Armor);
            Console.WriteLine($" Броня Воина ({Armor}) поглощает урон!");
            
            
            base.TakeDamage(actualDamage);
        }

        
        public override void DisplayInfo()
        {
            base.DisplayInfo(); 
            Console.WriteLine($"   Класс: Воин | Броня: {Armor}");
        }
    }

    
    class Mage : Creature
    {
        public int Mana { get; set; }

        
        public Mage(string name, int health, int mana) 
            : base(name, health)
        {
            Mana = mana;
        }

        
        public override void Attack()
        {
            if (Mana >= 10)
            {
                Mana -= 10;
                Console.WriteLine($" Маг {Name} кастует Огненный Шар! (Осталось маны: {Mana})");
            }
            else
            {
                Console.WriteLine($"У Мага {Name} закончилась мана, он бьет посохом!");
            }
        }

        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"   Класс: Маг  | Мана: {Mana}");
        }
    }