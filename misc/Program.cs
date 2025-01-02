using System;

namespace trashthis
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

        }

    }

}