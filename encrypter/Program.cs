/**
This program is a trivial encryption program that uses the Caesar cipher to encrypt a message. 
The Caesar cipher is a substitution cipher that shifts the alphabet by a fixed number of positions. 
In this case, the shift is 3 positions. The program takes a message as input and encrypts it using 
the Caesar cipher. The encrypted message is then displayed on the console.

TODO:
1. Implement the decryption logic to decrypt the encrypted message.
2. Add error handling to handle invalid input.
3. Add support for both encryption and decryption in the same program.
4. Add support for non-alphabetic characters in the message, of which only the spaces are preserved
   in the encrypted message.
*/
using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the alphabet
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            // Get the message from the user
            Console.Write("Please enter the message: ");
            string message = Console.ReadLine();

            // Convert the message to a character array
            char[] secretMessage = message.ToCharArray();
            char[] encryptedMessage = new char[secretMessage.Length];

            // Cycle through each character in the message
            for (int i = 0; i < secretMessage.Length; i++)
            {

                // Get the index of the character in the alphabet
                char plainChar = secretMessage[i];
                int alphabetIdx = Array.IndexOf(alphabet, plainChar);

                // Define default values for an encrypted character index of '-1', which 
                // represents a non-alphabetic character
                int encryptedIdx = -1;
                char encryptedChar = ' ';

                // Only encrypt alphabetic characters
                if (alphabetIdx > -1)
                {

                    // Encrypt the character by shifting it by 3 positions
                    // TODO: Make this a configurable parameter
                    encryptedIdx = alphabetIdx + 3;

                    // Handle wrap-around for the alphabet
                    if (encryptedIdx > alphabet.Length)
                    {
                        encryptedIdx = encryptedIdx % alphabet.Length;
                    }

                    // Build the encrypted message
                    encryptedChar = alphabet[encryptedIdx];
                    encryptedMessage[i] = encryptedChar;

                }
                else
                {   // Preserve spaces in the encrypted message
                    encryptedMessage[i] = ' ';
                }

                // Display the encryption process
                Console.WriteLine($"{plainChar} => {alphabetIdx} => {encryptedIdx} => {encryptedChar}");

            }

            // Display the original and encrypted messages
            Console.WriteLine($"Orig Msg => {message}");
            Console.WriteLine($"Encr Msg => {String.Join("", encryptedMessage)}");

        }
    }
}