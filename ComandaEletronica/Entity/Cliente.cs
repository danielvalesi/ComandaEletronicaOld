using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComandaEletronica.Models;

namespace ComandaEletronica.Entity
{
    public class Cliente
    {
        // campo:
        private int idCliente;

        // propriedades:
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

    }
}
