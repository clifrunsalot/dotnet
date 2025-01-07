using System;
using Xunit;

namespace CaesarCipher.Tests
{
    public class ProgramTest
    {
        [Fact]
        public void EncryptMessage_ShiftsCharactersCorrectly()
        {
            // Arrange
            string message = "hello";
            string expected = "khoor";

            // Act
            string result = EncryptMessage(message);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EncryptMessage_PreservesSpaces()
        {
            // Arrange
            string message = "hello world";
            string expected = "khoor zruog";

            // Act
            string result = EncryptMessage(message);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EncryptMessage_IgnoresNonAlphabeticCharacters()
        {
            // Arrange
            string message = "hello, world!";
            string expected = "khoor, zruog!";

            // Act
            string result = EncryptMessage(message);

            // Assert
            Assert.Equal(expected, result);
        }

        private string EncryptMessage(string message)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] secretMessage = message.ToCharArray();
            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                char plainChar = secretMessage[i];
                int alphabetIdx = Array.IndexOf(alphabet, plainChar);
                int encryptedIdx = -1;
                char encryptedChar = ' ';

                if (alphabetIdx > -1)
                {
                    encryptedIdx = alphabetIdx + 3;
                    if (encryptedIdx >= alphabet.Length)
                    {
                        encryptedIdx = encryptedIdx % alphabet.Length;
                    }
                    encryptedChar = alphabet[encryptedIdx];
                    encryptedMessage[i] = encryptedChar;
                }
                else
                {
                    encryptedMessage[i] = plainChar;
                }
            }

            return new string(encryptedMessage);
        }
    }
}