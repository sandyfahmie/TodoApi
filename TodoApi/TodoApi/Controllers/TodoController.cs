using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Diagnostics.Trace.Writeline;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Nama = "Item1" });
                _context.SaveChanges();
            }
        }
        #region snipet_GetAll
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }
        #endregion

        #region
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection MyConnection = new SqlConnection(MyConnectionString))
            {
                using (SqlCommand MyCommand = new SqlCommand("SELECT * FROM Flowers", MyConnection))
                {
                    using (SqlDataReader MyReader = MyCommand.ExecuteReader())
                    {
                        // read flowers and process ...
                    }
                }
            }
        }
        #endregion
        // create
        #region snippet_Create 
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic obj = js.Deserialize < dynamic>(item);

            return CreatedAtRoute("GetTodo", new { id = item.id }, item); 
        }
        #endregion
        // update
        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.id != id)
            {
                return BadRequest();
            }

            var todo = _context.TodoItems.FirstOrDefault(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Nama = item.Nama;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();

            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic obj = js.Deserialize < dynamic>(item);

            return new NoContentResult();
        }
        #endregion

        // delete
        #region snippet_Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.First(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();

            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic obj = js.Deserialize<dynamic>(todo);

            return new NoContentResult();
        }
        #endregion
    }
}