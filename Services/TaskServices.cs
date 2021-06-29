using Web_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Web_API.Services
{
    public static class TaskService
    {
        static List<TheTask> Tasks { get; }
        static int nextId = 3;
        static TaskService()
        {
            Tasks = new List<TheTask>
            {
                new TheTask { Id = 1, Title = "Title 1", IsWorking = false },
                new TheTask { Id = 2, Title = "Title 2", IsWorking = true }
            };
        }

        public static List<TheTask> GetAll() => Tasks;

        public static TheTask Get(int id) => Tasks.FirstOrDefault(p => p.Id == id);

        public static void Add(TheTask task)
        {
            task.Id = nextId++;
            Tasks.Add(task);
        }

        public static void Delete(int id)
        {
            var task = Get(id);
            if(task is null)
                return;

            Tasks.Remove(task);
        }

        public static void Update(TheTask task)
        {
            var index = Tasks.FindIndex(p => p.Id == task.Id);
            if(index == -1)
                return;

            Tasks[index] = task;
        }
    }
}
//////////////Mango- http://mango.viecrew.com ///////////////////