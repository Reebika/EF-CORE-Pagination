using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")] // /api/Todo
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApiContext apiContext;

        public TodoController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        // GET: api/Todo
        [HttpGet("all/{page}")]
        public async Task<ActionResult<TodosResponse<Todo>>> GetTodos(int pageNumber = 1, int pageSize = 10)
        {

            pageSize = pageSize > 0 ? pageSize : 10;

            var todos = await apiContext.Todos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(todos);
        }
        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodoById(int id)
        {
            var todo = apiContext.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // POST api/<TodoController>
        [HttpPost]
            public ActionResult<Todo> Post([FromBody] Todo model)
            {
                apiContext.Todos.Add(model);
                apiContext.SaveChanges();

                return Ok(model);
            }

            // PUT api/<TodoController>/5
            [HttpPut("{id}")]
            public ActionResult Update(int id, [FromBody] Todo model)
            {
                if (model == null || id <= 0)
                {
                    return BadRequest();
                }

                var dbTodo = apiContext.Todos.FirstOrDefault((x) => x.Id == id);
                if (dbTodo == null)
                {
                    return NotFound();
                }

                dbTodo.Name = model.Name;
                dbTodo.Status = model.Status;

                apiContext.SaveChanges();
                return Ok(dbTodo);
            }

            // DELETE api/<TodoController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        }
    }

    
