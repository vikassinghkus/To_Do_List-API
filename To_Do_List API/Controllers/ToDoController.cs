using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.Model;
using To_Do_List_API.Repository.Interface;

namespace To_Do_List_API.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly IToDo _toDo;
        public ToDoController(IToDo toDo)
        {
            _toDo = toDo;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll() => Ok(_toDo.GetAll());

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int id)
        {
            var item = _toDo.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddTask([FromBody] ToDoItems toDoItems)
        {
            _toDo.Add(toDoItems);
            return CreatedAtAction(nameof(GetById), new { id = toDoItems.Id }, toDoItems);
        }
        [HttpPut]
        [Route("[action]/{id}")]
        public IActionResult UpdateTask(int id, [FromBody] ToDoItems toDoItems)
        {
            var existingItem = _toDo.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _toDo.Update(id, toDoItems);
            return NoContent();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var existingItem = _toDo.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _toDo.Delete(id);
            return NoContent();
        }
    }
}
