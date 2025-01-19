using System;

namespace Playground
{

    // Extension methods.
    public static class MyExtensionMethods
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

        protected string age { get; set; }

        protected string occupation { get; set; }

        public void DisplayInfo();
    }

    public class Person : IPersonalInfo
    {
        // This should be unique to the class.
        public string username { get; set; }
        public string age { get; set; }
        public string occupation { get; set; }

        public Person(string username, string age, string occupation)
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

    public enum EmployeeAttributes
    {
        Username,
        Age,
        Occupation
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
                employees[index] = value;
                Console.WriteLine("Employee added.");
            }
        }

        public string this[int index, EmployeeAttributes choice]
        {
            // set value of username at index 
            set
            {
                switch (choice)
                {
                    case EmployeeAttributes.Username:
                        employees[index].username = Convert.ToString(value);
                        break;
                    case EmployeeAttributes.Age:
                        employees[index].age = Convert.ToString(value);
                        break;
                    case EmployeeAttributes.Occupation:
                        employees[index].occupation = Convert.ToString(value);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
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
    public class Program
    {

        /****************************************
        * Delegates. These act like function pointers in python/c++ 
        *****************************************/

        // (1) Delegate: Define the delegate.
        public delegate decimal MathDelegate(int x, int y);

        // (2) Delegate: Define the delegate instance.
        private static MathDelegate? mathDelegate = null;

        // (3) Delegate: Define the methods that will be assigned to the delegate.
        public decimal AddTwoNumbers(int x, int y)
        {
            return x + y;
        }

        public decimal SubtractTwoNumbers(int x, int y)
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
        * Generics. Acts just like c++ templates.
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
        * Extension methods. - Allows you to add methods to existing classes without recompiling the class. 
        *                      - Always static.
        *****************************************/
        static void PlayingWithExtensionMethods(Program p)
        {
            // Extension methods are always static.
            // Makes it convenient to add methods to existing classes without recompiling the class. 
            Console.WriteLine($"Playing with extension methods: {p.MultiplyTwoNumbers(5, 10)}");
        }

        /****************************************
        * Interfaces. Act just like abstract classes in c++.
        *****************************************/

        void PlayingwithInterfaces()
        {
            Person[] people = new Person[5];
            people[0] = new Person("John", "25", "Software Engineer");
            people[1] = new Person("Jane", "30", "Doctor");
            people[2] = new Person("Jack", "35", "Lawyer");
            people[3] = new Person("Jill", "40", "Teacher");
            people[4] = new Person("James", "45", "Pilot");
            foreach (Person p in people)
            {
                p.DisplayInfo();
            }
        }

        void PlayingwithIndexers()
        {
            Console.WriteLine("Playing with indexers:");
            Person[] people = new Person[5];
            people[0] = new Person("Alice", "28", "Data Scientist");
            people[1] = new Person("Bob", "32", "Architect");
            people[2] = new Person("Charlie", "38", "Chef");
            people[3] = new Person("Diana", "42", "Nurse");
            people[4] = new Person("Eve", "50", "Artist");
            Company c = new Company(people);

            try
            {
                Console.WriteLine("Before changes");
                c.DisplayEmployees();
                // Change "Eve" to "Rhonda".
                c[4, EmployeeAttributes.Username] = "Rhonda";
                // Attempt to update "Bobi", who doesn't exist. 
                c[5, EmployeeAttributes.Age] = "100";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("After changes");
                c.DisplayEmployees();
                Console.WriteLine("Playing with indexers: Done.");
            }
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