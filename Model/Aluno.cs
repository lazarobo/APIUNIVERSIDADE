using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiUniversidade.Model
{
    public class Aluno
    {
        public int ID { get; set; }

        public String? Nome { get; set; }

        public DateTime dataNascimento { get; set; }

        public String? CPF { get; set; }
    }
}