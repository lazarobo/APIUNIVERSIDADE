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
    public class CursoController : ControllerBase
    {

        [HttpGet(Name = "cursos")]

        public List<Curso> GetCursos()
        {

            List<Aluno> alunos = new List<Aluno>();
            List<Disciplina> disciplinas = new List<Disciplina>();
            List<Curso> cursos = new List<Curso>();

            disciplinas.Add(new Disciplina{
                Nome = "Português",
                CargaHoraria = 80,
                Semestre = 4
            });

            disciplinas.Add(new Disciplina{
                Nome = "Matemática",
                CargaHoraria = 80,
                Semestre = 4
            });

            disciplinas.Add(new Disciplina{
                Nome = "História",
                CargaHoraria = 80,
                Semestre = 4
            });

            cursos.Add(new Curso{
                Nome = "Linguagem",
                Area = "Letras",
                Duracao = 4,
                Disciplinas = disciplinas,
                Alunos = alunos
            });

            cursos.Add(new Curso{
                Nome = "Calcúlos",
                Area = "Matemática",
                Duracao = 4,
                Disciplinas = disciplinas,
                Alunos = alunos
            });

            cursos.Add(new Curso{
                Nome = "História",
                Area = "História",
                Duracao = 4,
                Disciplinas = disciplinas,
                Alunos = alunos
            });

            alunos.Add(new Aluno {
                Nome = "Jardson",
                dataNascimento = DateTime.Now,
                CPF = "444-444"
            });

            alunos.Add(new Aluno {
                Nome = "Maria",
                dataNascimento = DateTime.Now,
                CPF = "444-455"
            });

            return cursos;
        }
    }
}