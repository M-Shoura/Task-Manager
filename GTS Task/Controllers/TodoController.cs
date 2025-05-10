using AutoMapper;
using GTS_Task.Data;
using GTS_Task.Data.Models;
using GTS_Task.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GTS_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly SystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public TodoController(SystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllTasksDTO>>> GetAllTasks()
        {
            var tasks = await _dbContext.TodoTasks.AsNoTracking().ToListAsync();
            var Dtos = _mapper.Map<IEnumerable<GetAllTasksDTO>>(tasks);
            return Ok(Dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTaskDTO>> GetTasksById(Guid id)
        {
            var task = await _dbContext.TodoTasks.FindAsync(id);
            
            if (task == null)
                return NotFound($"No tasks found with id '{id}'.");
            
            return Ok(_mapper.Map<TodoTaskDTO>(task));
        }

        [HttpPost]
        public async Task<ActionResult> AddTask(TodoTaskDTO taskDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            taskDto.LastModifiedDate = DateTime.UtcNow;
            taskDto.CreatedDate = DateTime.UtcNow;

            var task = _mapper.Map<TodoTask>(taskDto);
            await _dbContext.TodoTasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(Guid id , [FromBody] TodoTaskDTO taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ourTask = await _dbContext.TodoTasks.FindAsync(id);
            if (ourTask == null)
                return NotFound($"No task found with ID '{id}'.");

            _mapper.Map(taskDto, ourTask);
            ourTask.LastModifiedDate = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            
            return Ok("Task updated successfully.");
        }

        [HttpPut("complete/{id}")]
        public async Task<ActionResult> UpdateTask(Guid id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ourTask = await _dbContext.TodoTasks.FindAsync(id);
            if (ourTask == null)
                return BadRequest("No Task With this ID");

            ourTask.Status = Status.Completed;
            ourTask.LastModifiedDate = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
            return Ok("Task Completed !");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ourTask = await _dbContext.TodoTasks.FindAsync(id);
            if (ourTask == null)
                return BadRequest("Bad Request!!");
            
            _dbContext.Remove(ourTask);
            await _dbContext.SaveChangesAsync();
            return Ok("Delete Done");
        }
    }
}
