using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Model;
using apiUniversidade.Context;

namespace apiUniversidade.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class DisciplinaController : ControllerBase
    {
          private readonly ILogger<DisciplinaController> _logger;
        private readonly apiUniversidadeContext _context;

         public DisciplinaController(ILogger<DisciplinaController> logger, apiUniversidadeContext context)
        {
            _logger = logger;
            _context = context;
        }
       
           [HttpGet]
        public ActionResult<IEnumerable<Disciplina>> Get()
        {
            var disciplina = _context.Disciplinas.ToList();
            if(disciplina is null)
                return NotFound();  

            return disciplina;
        }

       [HttpPost]
        public ActionResult Post (Disciplina disciplina){
            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();

            return new CreatedAtRouteResult ("GetAluno", new{id = disciplina.ID}, disciplina);
        }
        [HttpGet ("{id:int}", Name ="GetDisciplina")]
        public ActionResult<Disciplina> Get(int id)
        {
            var disciplina = _context.Disciplinas.FirstOrDefault(p => p.ID == id);
            if(disciplina is null)
                return NotFound("Disciplina não encontado.");

                return disciplina;
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Disciplina disciplina){
            if(id != disciplina.ID)
                return BadRequest();

            _context.Entry(disciplina).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(disciplina);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete (int id){
            var disciplina = _context.Disciplinas.FirstOrDefault(p => p.ID == id);

            if(disciplina is null)
            return NotFound();

            _context.Disciplinas.Remove(disciplina);
            _context.SaveChanges();

            return Ok(disciplina);
        }
    }
}