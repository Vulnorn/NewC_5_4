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
                        DeleteDossierByFullName(dossiers);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        ReportAnError("");
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, List<string>> dossiers)
        {
            Console.Clear();
            Console.WriteLine($"Введите ФИО Сотрудника:");
            string inputUserFullName = Console.ReadLine().ToLower();

            Console.WriteLine($"Введите должность для этого сотрудника:");
            string inputUserPosition = Console.ReadLine().ToLower();

            if (dossiers.ContainsKey(inputUserPosition))
                dossiers[inputUserPosition].Add(inputUserFullName);
            else
                dossiers.Add(inputUserPosition, [inputUserFullName]);
        }

        static void ShowAllDossiers(Dictionary<string, List<string>> dossiers)
        {
            Console.Clear();

            if (dossiers.LongCount() == 0)
            {
                ReportAnError("Досье пустое, заполните досье!");
            }
            else
            {
                foreach (var item in dossiers.Keys)
                {
                    Console.Write($"Должность: {item} - ");

                    foreach (var item2 in dossiers[item])
                    {
                        Console.Write($"{item2}; ");
                    }

                    Console.WriteLine();
                }

                Console.ReadKey();
            }
        }

        static void DeleteDossierByFullName(Dictionary<string, List<string>> dossiers)
        {
            Console.Clear();
            Console.WriteLine($"Введите ФИО Сотрудника для удаления.");
            string inputUser = Console.ReadLine().ToLower();
            bool deletePosition = false;
            bool deleteFullName = false;

            foreach (var item in dossiers.Keys)
            {
                foreach (var item2 in dossiers[item])
                {
                    if (item2 == inputUser)
                    {
                        dossiers[item].Remove(item2);
                        deleteFullName = true;

                        if (dossiers[item] == null)
                            deletePosition = true;
                    }
                }

                if (deletePosition)
                    dossiers.Remove(item);
            }

            if (deleteFullName)
                Console.WriteLine($"Сотрудник удален.");
            else
                ReportAnError("Нет такого сотрудника");

            Console.ReadKey();
        }

        static void ReportAnError(string causeOfError)
        {
            Console.WriteLine($"Ошибка ввода. {causeOfError}");
            Console.ReadKey();
        }
    }
}