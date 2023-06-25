using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluno
{
    public class Alunos
    {
        public void Insert(string[] obj)
        {
            Nome= obj[0];
            RA = obj[1];
            Idade= int.Parse(obj[2]);
        }
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public string? RA { get; set; }
    }

}
