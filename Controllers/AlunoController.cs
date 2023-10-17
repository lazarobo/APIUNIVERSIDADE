using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Model;

namespace apiUniversidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {

        [HttpGet(Name = "aluno")]

        public List<Aluno> GetAlunos()
        {
            List<Aluno> a = new List<Aluno>();

            Aluno a1 = new Aluno();
            a1.ID = 1;
            a1.Nome = "Ana";
            a1.CPF = "333-333";
            a1.dataNascimento = DateTime.Now;

            Aluno a2 = new Aluno();
            a2.ID = 2;
            a2.Nome = "Lázaro";
            a2.CPF = "222-222";
            a2.dataNascimento = DateTime.Now;

            Aluno a3 = new Aluno();
            a3.ID = 3;
            a3.Nome = "Matheus";
            a3.CPF = "444-444";
            a3.dataNascimento = DateTime.Now;

            a.Add(a1);
            a.Add(a2);
            a.Add(a3);

            return a;
        }
    }
}