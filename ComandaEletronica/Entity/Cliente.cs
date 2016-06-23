using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComandaEletronica.Models;

namespace ComandaEletronica.Entity
{
    public class Cliente : Pessoa
    {
        public string PorcentagemDesconto { get; set; }             

    }
}
