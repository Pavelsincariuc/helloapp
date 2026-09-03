using System;

    
    class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person2(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Человек: {Name}, Возраст: {Age}");
        }
    }
    
