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
    public class DisciplinaController : ControllerBase
    {

        [HttpGet(Name = "disciplinas")]

        public List<Disciplina> GetDisciplinas()
        {
            List<Disciplina> d = new List<Disciplina>();

            Disciplina d1 = new Disciplina();
            //d1.ID = 1;
            d1.Nome = "Programação para Internet";
            d1.CargaHoraria = 80;
            d1.Semestre = 8;

            Disciplina d2 = new Disciplina();
            //d2.ID = 2;
            d2.Nome = "Português";
            d2.CargaHoraria = 60;
            d2.Semestre = 4;

            Disciplina d3 = new Disciplina();
            //d3.ID = 3;
            d3.Nome = "Matemática";
            d3.CargaHoraria = 40;
            d3.Semestre = 7;

            d.Add(d1);
            d.Add(d2);
            d.Add(d3);

            return d;
        }
    }
}