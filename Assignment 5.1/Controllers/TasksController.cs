using Microsoft.AspNetCore.Mvc;
using Assignment_5_1.Models;

namespace Assignment8.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
    }

    private static readonly List<NewTaskModel> taskList = new()
    {
        new NewTaskModel("Create SRS SDS", true),
        new NewTaskModel("Modify Code", false),
        new NewTaskModel("Fix Bug", true)
    };

    [HttpPost]
    public ActionResult<NewTaskModel> Create([FromBody] CreateNewTaskModel createModel)
    {
        if (createModel != null)
        {
            var newTask = new NewTaskModel(createModel.Title, false);
            taskList.Add(newTask);
            return CreatedAtRoute(new { id = newTask.Id.ToString() }, newTask);
        }
        return BadRequest();
    }

    [HttpPost("Create-multiple")]
    public ActionResult<IEnumerable<NewTaskModel>> CreateManyTask([FromBody] List<CreateNewTaskModel> createModels)
    {
        if (createModels != null)
        {
            var newTasks = createModels.ConvertAll(task => new NewTaskModel(task.Title, false));
            taskList.AddRange(newTasks);
            return Ok(newTasks);
        }

        return BadRequest();
    }

    [HttpGet]
    public ActionResult<IEnumerable<NewTaskModel>> GetAll()
    {
        return Ok(taskList);
    }

    [HttpGet("{id}")]
    public ActionResult<NewTaskModel> GetTaskById(Guid id)
    {
        var obj = taskList.Find(obj => obj.Id == id);

        if (obj != null)
        {
            return Ok(obj);
        }

        return NotFound();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var obj = taskList.Find(obj => obj.Id == id);

        if (obj != null)
        {
            taskList.Remove(obj);
            return Ok();
        }

        return NotFound();
    }
}