using System;
using System.Collections.Generic;
using System.Linq;

namespace NewC_5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CommandAddDossier = 1;
            const int CommandOutputDossier = 2;
            const int CommandDeliteDossier = 3;
            const int CommandExit = 4;

            bool isWork = true;
            int userChoice;


            Dictionary<string, List <string>> dossiers = new Dictionary<string, List<string>>();

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"\n{CommandAddDossier}. Добавить досье. \n{CommandOutputDossier}. Вывести все досье.\n {CommandDeliteDossier}. Удалить досье.\n{CommandExit}. Выход.");
                userChoice = Convert.ToInt32(Console.ReadLine());

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
            string userCreateFullName = Console.ReadLine().ToLower();

            Console.WriteLine($"Введите должность для этого сотрудника:");
            string userCreatePosition = Console.ReadLine().ToLower();

            if (dossiers.ContainsKey(userCreatePosition))
                dossiers[userCreatePosition].Add(userCreateFullName);
            else
                dossiers.Add(userCreatePosition, [userCreateFullName]);
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
                for (int i = 0; i < dossiers.LongCount(); i++)
                {

                }

                Console.ReadKey();
            }
        }

        static void DeleteDossierByFullName(Dictionary<string, List<string>> dossiers)
        {

        }

        static void ReportAnError(string causeOfError)
        {
            Console.WriteLine($"Ошибка ввода. {causeOfError}");
            Console.ReadKey();
        }
    }
}