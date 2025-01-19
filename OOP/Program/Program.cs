using System;

namespace Program
{
    interface IAnimal
    {
        void Eat();
    }

    public class Animal : IAnimal
    {
        protected string Name { get; set; }

        protected string Sound { get; set; }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}");
        }
        public void Eat()
        {
            Console.WriteLine("Animal is eating");
        }

    }

    public class Dog : Animal
    {
        public Dog(string name)
        {
            this.Name = name;
            this.Sound = "Woof";
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}");
        }

        public void Eat()
        {
            Console.WriteLine("Dog is eating");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name)
        {
            this.Name = name;
            this.Sound = "Meow";
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}");
        }

        public void Eat()
        {
            Console.WriteLine("Cat is eating");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void Greet()
        {
            Console.WriteLine("{0}, {1}", Name, Age);
        }
    }


    public class Program
    {
        public static void Main()
        {
            Animal dog = new Dog("Doggy");
            dog.MakeSound();
            dog.Eat();

            Animal cat = new Cat("Kitty");
            cat.MakeSound();
            cat.Eat();

            Person person = new Person("John", 30);
            person.Greet();
            Person person2 = new Person("Jane", 25);
            person2.Greet();
        }
    }
}