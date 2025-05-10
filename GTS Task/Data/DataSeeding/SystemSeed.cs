using GTS_Task.Data.Models;
using System.Text.Json;

namespace GTS_Task.Data.DataSeeding
{
    public static class SystemSeed
    {
        public static void Seed(SystemDbContext _dbContext)
        {
            if (!_dbContext.TodoTasks.Any())
            {
                var TasksData = File.ReadAllText("Data/DataSeeding/seeding.json");
                var Tasks = JsonSerializer.Deserialize<List<TodoTask>>(TasksData);
                if (Tasks?.Count() > 0)
                {
                    foreach (var task in Tasks)
                    {
                        _dbContext.TodoTasks.Add(task);
                    }
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
