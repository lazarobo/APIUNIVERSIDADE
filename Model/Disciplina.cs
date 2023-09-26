using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiUniversidade.Model
{
    public class Disciplina
    {
        public int ID {get; set;}

        public String? Nome {get; set;}

        public int CargaHoraria {get; set;}

        public int Semestre {get; set;}
    }
}