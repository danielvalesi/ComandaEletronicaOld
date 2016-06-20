using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComandaEletronica.Models;

namespace ComandaEletronica.Entity
{
    public class Pedido
    {
        // campo:
        private int id;

        // propriedades:
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public int Conta_Id { get; set; }

        public StatusPedido Status { get; set; }

        public DateTime DataEntrega { get; set; }

        

    }
}
