using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    [Serializable]
    class Schedule
    {
        public List<Task> Tasks { get; set; }

        public Schedule()
        {
            this.Tasks = new List<Task>();
        }

        public void AddTask(string nameTask, DateTime completionDate)
        {
            Tasks.Add(new Task(nameTask, completionDate));
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void DeleteTask(string nameTask)
        {
            var task = Tasks.Find(e => e.Name.Equals(nameTask));
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }

        public void DeleteTask(DateTime completionDate)
        {
            var task = Tasks.Find(e => e.CompletionDate.Equals(completionDate));
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }

        public void EditTask(string nameTask, Task newTask)
        {
            var task = Tasks.Find(e => e.Name.Equals(nameTask));
            if (task != null)
            {
                task.Name = newTask.Name;
                task.CompletionDate = newTask.CompletionDate;
            }
        }

        public void SortTasksByCreationDate()
        {
            Tasks.Sort((a, b) => a.CreationDate.CompareTo(b.CreationDate));
        }

        public void SortTasksByCompletionDate()
        {
            Tasks.Sort((a, b) => a.CompletionDate.CompareTo(b.CompletionDate));
        }

        public string PrintCurrentTasks()
        {
            string currentTasks = "";
            foreach (Task task in Tasks)
            {
                if (task.CompletionDate > DateTime.Now)
                {
                    currentTasks += task.ToString() + "\n";
                }
            }
            return currentTasks;
        }

        public string PrintOverdueTasks()
        {
            string overdueTasks = "";
            foreach (Task task in Tasks)
            {
                if (task.CompletionDate <= DateTime.Now)
                {
                    overdueTasks += task.ToString() + "\n";
                }
            }
            return overdueTasks;
        }

        public string PrintTasksList()
        {
            return Tasks.Aggregate("", (current, item) => current + item.ToString() + "\n");
        }
    }
}
