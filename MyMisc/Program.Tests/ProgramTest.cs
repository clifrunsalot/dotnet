using System;
using Xunit;
using Playground;

namespace Program.Tests
{
    public class ProgramTest
    {
        [Fact]
        public void TestAddTwoNumbers()
        {
            // Arrange
            Playground.Program p = new Playground.Program();
            decimal expected = 15;

            // Act
            decimal result = p.AddTwoNumbers(5, 10);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestSubtractTwoNumbers()
        {
            // Arrange
            Playground.Program p = new Playground.Program();
            decimal expected = -5;

            // Act
            decimal result = p.SubtractTwoNumbers(5, 10);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestMultiplyTwoNumbersExtensionMethod()
        {
            // Arrange
            Playground.Program p = new Playground.Program();
            decimal expected = 50;

            // Act
            decimal result = p.MultiplyTwoNumbers(5, 10);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestDisplayInfo()
        {
            // Arrange
            Person person = new Person("John", "25", "Software Engineer");
            string expected = "John   25 Software Engineer";

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                person.DisplayInfo();
                var result = sw.ToString().Trim();

                // Assert
                Assert.Equal(expected, result);
            }
        }

        [Fact]
        public void TestCompanyIndexer()
        {
            // Arrange
            Person[] people = new Person[5];
            people[0] = new Person("Alice", "28", "Data Scientist");
            people[1] = new Person("Bob", "32", "Architect");
            people[2] = new Person("Charlie", "38", "Chef");
            people[3] = new Person("Diana", "42", "Nurse");
            people[4] = new Person("Eve", "50", "Artist");
            Company company = new Company(people);

            // Act
            company[4, EmployeeAttributes.Username] = "Rhonda";
            string expected = "Rhonda";
            string result = company[4].username;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestCompanyIndexerUpdateAge()
        {

            // Arrange
            Person[] people = new Person[5];
            people[0] = new Person("Alice", "28", "Data Scientist");
            people[1] = new Person("Bob", "32", "Architect");
            people[2] = new Person("Charlie", "38", "Chef");
            people[3] = new Person("Diana", "42", "Nurse");
            people[4] = new Person("Eve", "50", "Artist");
            Company company = new Company(people);

            // Act
            company[1, EmployeeAttributes.Age] = "100";
            string expected = "100";
            string result = company[1].age;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGetGreaterValue()
        {
            // Arrange
            Playground.Program.MyGenericClass<int> mgc = new Playground.Program.MyGenericClass<int>();
            int expected = 10;

            // Act
            int result = mgc.GetGreaterValue(5, 10);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}