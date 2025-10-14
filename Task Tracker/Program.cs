using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your ToDo List!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("" +
                "[0]: Add task" +
                "\n[1]: Update task" +
                "\n[2]: Delete task" +
                "\n[3]: List all tasks" +
                "\n[4]: List done tasks" +
                "\n[5]: List not done tasks" +
                "\n[6]: List in progress task");

            int selectedOption = Convert.ToInt32(Console.ReadLine());

            switch(selectedOption)
            {
                case 0:
                    Console.WriteLine("Task adicionada");
                    break;
                case 1:
                    Console.WriteLine("Task atualizada");
                    break;
                case 2:
                    Console.WriteLine("Task deletada");
                    break;
                case 3:
                    Console.WriteLine("Listagem de todas task");
                    break;
                case 4:
                    Console.WriteLine("Listagem de task feitas");
                    break;
                case 5:
                    Console.WriteLine("Listagem de tasks não iniciadas");
                    break;
                case 6:
                    Console.WriteLine("Listagem de tasks em progresso");
                    break;
            }
        }
    }
}
