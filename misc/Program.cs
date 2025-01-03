using System;

namespace Playground
{

    // Extension methods.
    static class MyExtensionMethods
    {
        // NOTE: The first parameter of an extension method must be of the type that you 
        // want to extend, which would be an object instance in this case. See the 'this' keyword.
        public static decimal MultiplyTwoNumbers(this Program p, int x, int y)
        {
            return x * y;
        }
    }

    // Interfaces.
    interface IPersonalInfo
    {
        protected string username { get; set; }

        protected int age { get; set; }

        public void DisplayInfo();
    }

    public class Person : IPersonalInfo
    {
        // This should be unique to the class.
        public string username { get; set; }
        public int age { get; set; }
        public string occupation { get; set; }

        public Person(string username, int age, string occupation)
        {
            this.username = username;
            this.age = age;
            this.occupation = occupation;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("{0,10} {1,4} {2,-20}", username, age, occupation);
        }
    }

    // Indexers.
    public class Company
    {
        private Person[] employees = new Person[5];
        public Company(Person[] people)
        {
            this.employees = people;
        }

        public Person this[int index]
        {
            // return the value of the indexer.
            get
            {
                return employees[index];
            }
            // set the value of the indexer. value is a Person object.
            set
            {
                foreach (Person p in employees)
                {
                    if (p.username == value.username)
                    {
                        Console.WriteLine("Username already exists.");
                        return;
                    }
                }
                employees[index] = value;
            }
        }

        public Person this[int index, string username]
        {
            // set value of username at index 
            set
            {
                foreach (Person p in employees)
                {
                    if (p.username == username)
                    {
                        Console.WriteLine("Username {0} already exists.", username);
                        return;
                    }
                }
                Console.WriteLine("Updated Username {0}.", username);
                employees[index].username = username;
            }
        }

        public Person this[string username, int age]
        {
            // set value of age at index 
            set
            {
                foreach (Person p in employees)
                {
                    if (p.username == username)
                    {
                        Console.WriteLine("Updated username: {0}.", username);
                        p.age = age;
                        return;
                    }
                }
                Console.WriteLine("Username {0} does not exist.", username);
            }
        }

        public void DisplayEmployees()
        {
            foreach (Person p in employees)
            {
                p.DisplayInfo();
            }
        }
    }

    /// <summary>
    /// This is a program that demonstrates various C# concepts. 
    /// </summary>
    class Program
    {

        /****************************************
        * Delegates. 
        *****************************************/

        // (1) Delegate: Define the delegate.
        public delegate decimal MathDelegate(int x, int y);

        // (2) Delegate: Define the delegate instance.
        private static MathDelegate? mathDelegate = null;

        // (3) Delegate: Define the methods that will be assigned to the delegate.
        decimal AddTwoNumbers(int x, int y)
        {
            return x + y;
        }

        decimal SubtractTwoNumbers(int x, int y)
        {
            return x - y;
        }

        // Delegate: Used when a return value is not needed. 
        void PrintTwoNumbers(int x, int y)
        {
            Console.WriteLine($"Playing with Action delegate: The value of x is {x} and the value of y is {y}");
        }

        void PlaywithDelegates()
        {
            // (4) Delegate: Assign the methods to the delegate.
            mathDelegate += new MathDelegate(AddTwoNumbers);
            mathDelegate += SubtractTwoNumbers;
            mathDelegate += ((int x, int y) => { return (x * y); });

            // (5) Delegate: Invoke the delegate.
            foreach (MathDelegate md in mathDelegate.GetInvocationList())
            {
                Console.WriteLine($"Playing with delegates: {md(5, 10)}");
            }

            // (6) Delegate: Using a delegate with an Action when a return value is not needed.
            Action<int, int> SomeAction = PrintTwoNumbers;
            SomeAction(5, 10);
        }

        /****************************************
        * Enums. 
        *****************************************/

        // Define an enum.
        public enum MathOperation
        {
            // The compiler will assign indices to enum members based on the first value 
            // preceding a series of enums without a value. 
            // Add = 16, Subtract = 17, Multiply = 3, Divide = 4
            Add = 16,
            Subtract,
            Multiply = 3,
            Divide
        }

        void PlaywithEnums()
        {
            // Working with enums. 
            foreach (int i in Enum.GetValues(typeof(MathOperation)))
            {
                Console.WriteLine($"Playing with enums: Enum value: {i}, Enum name: {Enum.GetName(typeof(MathOperation), i)}");
            }

            foreach (string s in Enum.GetNames(typeof(MathOperation)))
            {
                Console.WriteLine($"Playing with enums: Enum name: {s}, Enum value: {Enum.Parse(typeof(MathOperation), s)}");
            }
        }

        /****************************************
        * Generics 
        *****************************************/
        // NOTE: To avoid CS0693 warnings, ensure that the class type is 
        // different from the method type, because the class type may be
        // different from the method type.
        public class MyGenericClass<U>
        {
            public T GetGreaterValue<T>(T x, T y) where T : IComparable<T>
            {
                if ((x.CompareTo(y)) <= 0)
                {
                    return y;
                }
                else
                {
                    return x;
                }
            }
        }

        void PlayingwithGenerics()
        {
            MyGenericClass<int> mgc = new MyGenericClass<int>();
            Console.WriteLine($"Playing with Generics; using int: {mgc.GetGreaterValue(5, 10)}");
            Console.WriteLine($"Playing with Generics; using decimal: {mgc.GetGreaterValue(5.0, 11.0)}");
            Console.WriteLine($"Playing with Generics; using string: {mgc.GetGreaterValue("a", "z")}");
        }

        /****************************************
        * Extension methods. 
        *****************************************/
        static void PlayingWithExtensionMethods(Program p)
        {
            // Extension methods are always static.
            // Makes it convenient to add methods to existing classes without recompiling the class. 
            Console.WriteLine($"Playing with extension methods: {p.MultiplyTwoNumbers(5, 10)}");
        }

        /****************************************
        * Interfaces
        *****************************************/

        // Interfaces are used to define a contract that a class must implement. 
        // Interfaces can contain methods, properties, events, and indexers. 
        // Interfaces cannot contain fields, constructors, destructors, or static members. 
        // Interfaces can inherit from other interfaces. 
        // A class can inherit
        void PlayingwithInterfaces()
        {
            Person[] people = new Person[5];
            people[0] = new Person("John", 25, "Software Engineer");
            people[1] = new Person("Jane", 30, "Doctor");
            people[2] = new Person("Jack", 35, "Lawyer");
            people[3] = new Person("Jill", 40, "Teacher");
            people[4] = new Person("James", 45, "Pilot");
            foreach (Person p in people)
            {
                p.DisplayInfo();
            }
        }

        void PlayingwithIndexers()
        {
            Console.WriteLine("Playing with indexers:");
            Person[] people = new Person[5];
            people[0] = new Person("Alice", 28, "Data Scientist");
            people[1] = new Person("Bob", 32, "Architect");
            people[2] = new Person("Charlie", 38, "Chef");
            people[3] = new Person("Diana", 42, "Nurse");
            people[4] = new Person("Eve", 50, "Artist");
            Company c = new Company(people);
            c.DisplayEmployees();
            // Change "Eve" to "Rhonda".
            c[4, "Rhonda"] = new Person("Rhonda", 55, "Artist");
            // Attempt to update "Bobi", who doesn't exist. 
            c["Bobi", 100] = new Person("Bob", 100, "Architect");
            c.DisplayEmployees();
        }

        // Main method.
        static void Main(string[] args)
        {
            // Non-static
            Program p = new Program();
            p.PlaywithDelegates();
            p.PlaywithEnums();
            p.PlayingwithGenerics();

            // Static
            PlayingWithExtensionMethods(p);

            // Interfaces
            p.PlayingwithInterfaces();

            // Indexers
            p.PlayingwithIndexers();
        }

    }

}