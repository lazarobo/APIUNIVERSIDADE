using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiUniversidade.Model;

namespace apiUniversidade.Context
{
    public class apiUniversidadeContext : DbContext
    {
        public apiUniversidadeContext(DbContextOptions options) : base(options) { }

        public DbSet<Aluno>? Alunos { get; set; }

        public DbSet<Curso>? Cursos { get; set; }

        public DbSet<Disciplina>? Disciplinas { get; set; }
    }
}