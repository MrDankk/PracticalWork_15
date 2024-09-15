using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MethodLibrary
{
    public class VoidMethod
    {

        /// <summary>
        /// Вывести в консоль информацию о потоке
        /// </summary>
        /// <param name="count"> Количество выполнений </param>
        public static void Print(object count)
        {
            Random random = new Random();

            Console.WriteLine($"Поток {Task.CurrentId} Начал работу.");

            int cyclesCount = (int)count;

            for (int i = 0; i < cyclesCount; i++)
            {
                Console.WriteLine($"Поток {Task.CurrentId} - выполнился {i + 1} раз(а)");
                Thread.Sleep(random.Next(100,250));
            }

            Console.WriteLine($"Поток {Task.CurrentId} Закончил работу.");
        }
    }
}
