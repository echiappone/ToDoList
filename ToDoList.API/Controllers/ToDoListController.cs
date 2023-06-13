using ToDoList.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Services;

namespace ProvaToDoList.API.Controllers
{
    [Route("api/todolist")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ITaskItemService _service;
        public ToDoListController(ITaskItemService service) 
        { 
            _service = service;
        }

        [HttpGet] 
        public IActionResult GetAll() 
        {
            var result = _service.GetAll();            
            return Ok (result);
        }

        [HttpGet ("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _service.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskItemDTO item)
        {
            var result = _service.Create(item);            
            if(!result.Success) 
                return BadRequest(result);  
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] TaskItemDTO item)
        {
            var result = _service.Update(item);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _service.Delete(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
