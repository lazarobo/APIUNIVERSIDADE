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
    
    public class AlunoController : ControllerBase 
    {
         private readonly ILogger<AlunoController> _logger;
        private readonly apiUniversidadeContext _context;

        public AlunoController(ILogger<AlunoController> logger, apiUniversidadeContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            var alunos = _context.Alunos.ToList();
            if(alunos is not null)
                return NotFound();  

            return alunos;
        }

       /* [HttpPost]
        public ActionResult Post (Aluno aluno){
            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            return new CreatedAtActionResult ("GetAluno", new{id = aluno.ID}, aluno);
        }*/
    }
}