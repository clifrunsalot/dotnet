using System;
using Xunit;

namespace Program.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TestDogMakeSound()
        {
            // Arrange
            Animal dog = new Dog("Doggy");
            string expectedSound = "Doggy says Woof";

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                dog.MakeSound();
                var result = sw.ToString().Trim();

                // Assert
                Assert.Equal(expectedSound, result);
            }
        }

        [Fact]
        public void TestDogEat()
        {
            // Arrange
            Dog dog = new Dog("Doggy");
            string expectedEat = "Dog is eating";

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                dog.Eat();
                var result = sw.ToString().Trim();

                // Assert
                Assert.Equal(expectedEat, result);
            }
        }

        [Fact]
        public void TestCatMakeSound()
        {
            // Arrange
            Animal cat = new Cat("Kitty");
            string expectedSound = "Kitty says Meow";

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                cat.MakeSound();
                var result = sw.ToString().Trim();

                // Assert
                Assert.Equal(expectedSound, result);
            }
        }

        [Fact]
        public void TestCatEat()
        {
            // Arrange
            Cat cat = new Cat("Kitty");
            string expectedEat = "Cat is eating";

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                cat.Eat();
                var result = sw.ToString().Trim();

                // Assert
                Assert.Equal(expectedEat, result);
            }
        }

        [Fact]
        public void TestPersonGreet()
        {
            // Arrange
            Person person = new Person("John Doe", 30);
            string expectedGreeting = "John Doe, 30";

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                person.Greet();
                var result = sw.ToString().Trim();

                // Assert
                Assert.Equal(expectedGreeting, result);
            }
        }
    }
}