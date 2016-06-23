using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComandaEletronica.Entity
{
    public class Pessoa
    {
        public int Pessoa_id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Imagem { get; set; }
        public string Tipo { get; set; }
    }
}