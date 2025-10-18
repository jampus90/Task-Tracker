using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace Task_Tracker
{
    internal class CRUDManager
    {
        private string path = "todo.json";
        public string CreateTask(string description)
        {
            List<TaskProperties> tasks = new List<TaskProperties>();

            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonSerializer.Serialize(tasks));
            }

            string jsonData = File.ReadAllText(path);
            tasks = JsonSerializer.Deserialize<List<TaskProperties>>(jsonData) ?? new List<TaskProperties>();

            int newId = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            TaskProperties newTask = new TaskProperties
            {
                Id = newId,
                Description = description,
                Status = "Not started",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            tasks.Add(newTask);

            File.WriteAllText(path, JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true }));
            Console.WriteLine(Path.GetFullPath(path));


            return $"Task '{description}' created!";
        }

        public string UpdateTask(int id, string newDescription = null, string newStatus = null)
        {
            if (!File.Exists(path))
            {
                return "File not found.";
            }

            string jsonData = File.ReadAllText(path);
            List<TaskProperties> tasks = JsonSerializer.Deserialize<List<TaskProperties>>(jsonData) ?? new List<TaskProperties>();

            TaskProperties taskToUpdate = tasks.FirstOrDefault(t => t.Id == id);

            if (taskToUpdate == null)
            {
                return "Task not found";
            }

            if (!string.IsNullOrWhiteSpace(newDescription))
            {
                taskToUpdate.Description = newDescription;
            }

            if (!string.IsNullOrWhiteSpace(newStatus))
            {
                taskToUpdate.Status = newStatus;
            }

            taskToUpdate.UpdatedAt = DateTime.Now;

            File.WriteAllText(path, JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true }));

            return $"Task {taskToUpdate.Id} updated!";
        }

        public string DeleteTask(int id)
        {
            if (!File.Exists(path))
            {
                return "File not found";
            }

            string jsonData = File.ReadAllText(path);
            List<TaskProperties> tasks = JsonSerializer.Deserialize<List<TaskProperties>>(jsonData) ?? new List<TaskProperties>();

            TaskProperties taskToDelete = tasks.FirstOrDefault(t => t.Id == id);

            if (taskToDelete == null)
            {
                return "Task not found.";
            }

            tasks.Remove(taskToDelete);

            File.WriteAllText(path, JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true }));

            return $"Task '{taskToDelete.Description}' deleted successfully.";
        }

        public List<TaskProperties> ListAllTasks()
        {
            if (!File.Exists(path))
            {
                return new List<TaskProperties>();
            }

            string jsonData = File.ReadAllText(path);
            List<TaskProperties> tasks = JsonSerializer.Deserialize<List<TaskProperties>>(jsonData) ?? new List<TaskProperties>();

            return tasks;
        }

        public List<TaskProperties> ListDoneTasks()
        {
            if (!File.Exists(path))
            {
                return new List<TaskProperties>();
            }

            string jsonData = File.ReadAllText(path);
            List<TaskProperties> tasks = JsonSerializer.Deserialize<List<TaskProperties>>(jsonData) ?? new List<TaskProperties>();

            var doneTasks = tasks.Where(b => b.Status == "Done").ToList();

            return doneTasks;
        }

        public List<TaskProperties> ListNotDoneTasks()
        {
            if (!File.Exists(path))
            {
                return new List<TaskProperties>();
            }

            string jsonData = File.ReadAllText(path);
            List<TaskProperties> tasks = JsonSerializer.Deserialize<List<TaskProperties>>(jsonData) ?? new List<TaskProperties>();

            var doneTasks = tasks.Where(b => b.Status == "Not started").ToList();

            return doneTasks;
        }

        public List<TaskProperties> ListInProgressTasks()
        {
            if (!File.Exists(path))
            {
                return new List<TaskProperties>();
            }

            string jsonData = File.ReadAllText(path);
            List<TaskProperties> tasks = JsonSerializer.Deserialize<List<TaskProperties>>(jsonData) ?? new List<TaskProperties>();

            var inProgressTasks = tasks.Where(b => b.Status == "In Progress").ToList();

            return inProgressTasks;
        }
    }
}
