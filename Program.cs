using System;

namespace NewC_5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandOutputDossier = "2";
            const string CommandDeliteDossier = "3";
            const string CommandExit = "4";

            Dictionary<string, List<string>> dossiers = new Dictionary<string, List<string>>();

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"{CommandAddDossier}. Добавить досье." +
                    $"\n{CommandOutputDossier}. Вывести все досье." +
                    $"\n{CommandDeliteDossier}. Удалить досье." +
                    $"\n{CommandExit}. Выход.");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case CommandAddDossier:
                        AddDossier(dossiers);
                        break;

                    case CommandOutputDossier:
                        ShowAllDossiers(dossiers);
                        break;

                    case CommandDeliteDossier:
                        DeleteDossierFullName(dossiers);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        ReportError("");
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, List<string>> dossiers)
        {
            Console.Clear();
            Console.WriteLine($"Введите ФИО Сотрудника:");
            string inputUserFullName = Console.ReadLine().ToLower();

            Console.WriteLine($"Введите должность сотрудника:");
            string inputUserPosition = Console.ReadLine().ToLower();


            if (dossiers.ContainsKey(inputUserPosition) == false)
                dossiers.Add(inputUserPosition, new List<string>());

            dossiers[inputUserPosition].Add(inputUserFullName);
        }

        static void ShowAllDossiers(Dictionary<string, List<string>> dossiers)
        {
            Console.Clear();

            if (dossiers.Count == 0)
            {
                ReportError("Досье пустое, заполните досье!");
            }
            else
            {
                foreach (var position in dossiers.Keys)
                {
                    Console.Write($"Должность: {position} - ");
                    int fullNamePosition = 1;

                    foreach (var fullName in dossiers[position])
                    {
                        Console.Write($"{fullNamePosition}) {fullName}; \n");
                        fullNamePosition++;
                    }
                }

                Console.ReadKey();
            }
        }

        static void DeleteDossierFullName(Dictionary<string, List<string>> dossiers)
        {
            Console.WriteLine($"Введите должность сотрудника:");
            string inputUserPosition = Console.ReadLine().ToLower();

            if (dossiers.ContainsKey(inputUserPosition) == false)
            {
                ReportError("Нет такой должности");
            }
            else
            {
                int firstPosition = 1;
                int userInput = Utilite.GetNumber(firstPosition, dossiers[inputUserPosition].Count);

                dossiers[inputUserPosition].RemoveAt(userInput);
                Console.WriteLine($"Сотрудник удален.");

                if (dossiers[inputUserPosition].Count == 0)
                    dossiers.Remove(inputUserPosition);
            }

            Console.ReadKey();
        }

        static void ReportError(string errorCause)
        {
            Console.WriteLine($"Ошибка ввода. {errorCause}");
            Console.ReadKey();
        }
    }

    class Utilite
    {
        public static int GetNumber(int lowerLimitRangeNumbers = Int32.MinValue, int upperLimitRangeNumbers = Int32.MaxValue)
        {
            bool isEnterNumber = true;
            int enterNumber = 0;
            string userInput;

            while (isEnterNumber)
            {
                Console.WriteLine($"Введите число.");

                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out enterNumber) == false)
                    Console.WriteLine("Не корректный ввод.");
                else if (VerifyForAcceptableNumber(enterNumber, lowerLimitRangeNumbers, upperLimitRangeNumbers))
                    isEnterNumber = false;
            }

            return enterNumber;
        }

        private static bool VerifyForAcceptableNumber(int number, int lowerLimitRangeNumbers, int upperLimitRangeNumbers)
        {
            if (number < lowerLimitRangeNumbers)
            {
                Console.WriteLine($"Число вышло за нижний предел допустимого значения.");
                return false;
            }
            else if (number > upperLimitRangeNumbers)
            {
                Console.WriteLine($"Число вышло за верхний предел допустимого значения.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}