using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MethodLibrary;

namespace PracticalWork_15
{
    internal class Program
    {
        static int TaskCount;
        static int CyclesCount;

        static void Main(string[] args)
        {
            MenuSelection();
        }

        /// <summary>
        /// Управленние главным меню
        /// </summary>
        static void MenuSelection()
        {
            bool menuActive = true;

            while (menuActive)
            {
                Console.Clear();
                PrintMenuSelection();
                int input = Input();

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Введите количество потоков");
                        TaskCount = Input();
                        break;

                    case 2:
                        if(TaskCount == 0) TaskCount = 1;

                        Console.WriteLine("Введите количество выполнений");
                        CyclesCount = Input();
                        ProgramStart();
                        break;

                    case 0:
                        menuActive = false;
                        break;

                    default:
                        Console.WriteLine("Такого пункта не существует");
                        break;
                }
            }
        }

        /// <summary>
        /// Вывод в консоль меню выбора
        /// </summary>
        static void PrintMenuSelection()
        {
            Console.WriteLine("1 - Количество потоков");
            Console.WriteLine("2 - Запусить выполнение");
            Console.WriteLine("0 - Выход");
        }

        /// <summary>
        /// Запуск программы
        /// </summary>
        static void ProgramStart()
        {
            Task[] tasks = new Task[TaskCount];

            for (int i = 0; i < TaskCount; i++)
            {
                tasks[i] = Task.Factory.StartNew(VoidMethod.Print,CyclesCount);
            }

            Task.WaitAll(tasks);

            Console.ReadKey();
        }

        /// <summary>
        /// Проверка ввода
        /// </summary>
        /// <returns></returns>
        static int Input()
        {
            while(true)
            {
                int result;
                string input = Console.ReadLine();

                if (int.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Некоректный ввод");
                }
            }
        }
    }
}
