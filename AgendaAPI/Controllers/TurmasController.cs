
using System.Linq;
using AgendaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    public class TurmasController : Controller
    {
        public AgendaContext Context { get; private set; }

        public TurmasController(AgendaContext context)
        {
            Context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(Context.Turmas
                    .Include("Professor")
                    .Include("Curso")
                    .Where(a => a.Id.Equals(id)));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(Context.Turmas
                    .Include("Professor")
                    .Include("Curso"));
        }
    }
}