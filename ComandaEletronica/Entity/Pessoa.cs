using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComandaEletronica.Models;

namespace ComandaEletronica.Entity
{
    public class Pessoa
    {
        // campo:
        private int id;

        // propriedades:
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public decimal Senha { get; set; }

        public decimal Cpf { get; set; }

    }
}
