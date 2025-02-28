using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.Repository.Interface;

namespace To_Do_List_API.Controllers
{
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
        public IActionResult GetById(int id)
        {
            var item = _toDo.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }
    }
}
