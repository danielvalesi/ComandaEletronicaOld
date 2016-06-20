using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComandaEletronica.Models;

namespace ComandaEletronica.Entity
{
    public class Funcionario
    {
        // campo:
        private int pessoa_id;

        // propriedades:
        public int Pessoa_id
        {
            get { return pessoa_id; }
            set { pessoa_id = value; }
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
        
        public string Cpf { get; set; }
        
        public string Cargo { get; set; }
        
        public DateTime HorarioEntrada { get; set; }
        
        public DateTime HorarioSaida { get; set; }

    }
}
