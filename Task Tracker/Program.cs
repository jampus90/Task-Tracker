using System;
using System.Text.Json;
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
            CRUDManager crudManager = new CRUDManager();

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
                    Console.WriteLine("Type your new task description: ");
                    string description = Console.ReadLine();
                    string createTask = crudManager.CreateTask(description);
                    break;

                case 1:
                    Console.WriteLine("Which task do you want o update:");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Whats the new description?");
                    string newDescription = Console.ReadLine();

                    Console.WriteLine("What's the new status?");
                    string newStatus = Console.ReadLine();

                    string updateTask = crudManager.UpdateTask(id, newDescription, newStatus);
                    break;

                case 2:
                    Console.WriteLine("Which task do you want to delete?");
                    id = Convert.ToInt32(Console.ReadLine());

                    string deleteTask = crudManager.DeleteTask(id);
                    break;

                case 3:
                    List<TaskProperties> listTasks = crudManager.ListAllTasks();
                    string json = JsonSerializer.Serialize(listTasks, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(json);
                    break;

                case 4:
                    List<TaskProperties> listDoneTasks = crudManager.ListDoneTasks();
                    string doneJson = JsonSerializer.Serialize(listDoneTasks, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(doneJson);
                    break;

                case 5:
                    List<TaskProperties> listNotDoneTasks = crudManager.ListNotDoneTasks();
                    string notDoneJson = JsonSerializer.Serialize(listNotDoneTasks, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(notDoneJson);
                    break;

                case 6:
                    List<TaskProperties> listInProgressTasks = crudManager.ListInProgressTasks();
                    string inProgressJson = JsonSerializer.Serialize(listInProgressTasks, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(inProgressJson);
                    break;
            }
        }
    }
}
