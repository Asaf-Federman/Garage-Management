using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public static class ValidationMethods
    {
        public static int GetValidIndexInputFromUser(int i_MaximumIndex)
        {
            int indexOfChoice = 0;
            bool v_IsValidIndex = false;
            int minimumIndex = 1;

            while (!v_IsValidIndex)
            {
                if (int.TryParse(Console.ReadLine(), out indexOfChoice))
                {
                    if (indexOfChoice <= i_MaximumIndex && indexOfChoice >= minimumIndex)
                    {
                        v_IsValidIndex = !v_IsValidIndex;
                    }
                }

                if (!v_IsValidIndex)
                {
                    Console.WriteLine("Bad input. Please enter a number between {0} to {1}.", minimumIndex, i_MaximumIndex);
                }
            }

            return indexOfChoice;
        }

        public static string ValidNameInput(int i_NumberOfSpacesAllowed, int i_NumberOfLettersAllowed, bool i_IsDigitValidInput)
        {
            bool v_IsValidName = false;
            bool v_IlligalChar = false;
            string name;
            int countOfLetters, countOfSpaces;

            do
            {
                countOfLetters = 0;
                countOfSpaces = 0;
                if (v_IlligalChar)
                {
                    v_IlligalChar = !v_IlligalChar;
                }

                name = Console.ReadLine();
                validateNameString(name, i_IsDigitValidInput, ref countOfLetters, ref countOfSpaces, ref v_IlligalChar);
                if (countOfLetters >= 3 && countOfLetters <= i_NumberOfLettersAllowed && countOfLetters > 0 && countOfSpaces <= i_NumberOfSpacesAllowed && !v_IlligalChar)
                {
                    v_IsValidName = !v_IsValidName;
                }

                if (!v_IsValidName)
                {
                    Console.WriteLine("Please enter a legal name.");
                }
            }
            while (!v_IsValidName);

            return name;
        }

        private static void validateNameString(string i_Name, bool i_IsDigitValidInput, ref int io_CountOfLetters, ref int io_CountOfSpaces, ref bool io_IlligalChar)
        {
            foreach (char letterOrSpace in i_Name)
            {
                if (letterOrSpace <= 'z' && letterOrSpace >= 'a')
                {
                    io_CountOfLetters++;
                }
                else if (letterOrSpace <= 'Z' && letterOrSpace >= 'A')
                {
                    io_CountOfLetters++;
                }
                else if (letterOrSpace == ' ')
                {
                    io_CountOfSpaces++;
                }
                else if (i_IsDigitValidInput && (letterOrSpace > '9' || letterOrSpace < '0'))
                {
                    io_IlligalChar = !io_IlligalChar;
                    break;
                }
                else if (!i_IsDigitValidInput)
                {
                    io_IlligalChar = !io_IlligalChar;
                    break;
                }
            }
        }

        public static string ValidPhoneNumberInput()
        {
            bool v_IsValidPhoneNumber = false;
            bool v_UnrelatedMarks = false;
            string phoneNumber;
            int countAmountOfDigits, countAmountOfHypen;

            do
            {
                countAmountOfHypen = 0;
                countAmountOfDigits = 0;
                if (v_UnrelatedMarks)
                {
                    v_UnrelatedMarks = !v_UnrelatedMarks;
                }

                phoneNumber = Console.ReadLine();
                validatePhoneNumberString(phoneNumber, ref countAmountOfDigits, ref countAmountOfHypen, ref v_UnrelatedMarks);
                if (countAmountOfDigits <= 10 && countAmountOfDigits >= 9 && countAmountOfHypen <= 1 && !v_UnrelatedMarks)
                {
                    v_IsValidPhoneNumber = !v_IsValidPhoneNumber;
                }

                if (!v_IsValidPhoneNumber)
                {
                    Console.WriteLine("Please enter a legal phone number.");
                }
            }
            while (!v_IsValidPhoneNumber);

            return phoneNumber;
        }

        private static void validatePhoneNumberString(string i_PhoneNumber, ref int io_CountAmountOfDigits, ref int io_CountAmountOfHypen, ref bool io_UnrelatedMarks)
        {
            foreach (char charOfString in i_PhoneNumber)
            {
                if (charOfString >= '0' && charOfString <= '9')
                {
                    io_CountAmountOfDigits++;
                }
                else if (charOfString == '-')
                {
                    io_CountAmountOfHypen++;
                }
                else
                {
                    io_UnrelatedMarks = !io_UnrelatedMarks;
                    break;
                }
            }
        }
    }
}
