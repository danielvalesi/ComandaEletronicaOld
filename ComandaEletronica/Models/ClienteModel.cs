using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using ComandaEletronica.Entity;

namespace ComandaEletronica.Models
{
    public class ClienteModel : Model
    {

        // CADASTRAR Cliente
        public void Create(Cliente c)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "cadCliente";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@senha", c.Senha);
            cmd.Parameters.AddWithValue("@cpf", c.Cpf);
            cmd.Parameters.AddWithValue("@imagem", c.Imagem);
            cmd.Parameters.AddWithValue("@porcenatgemDesconto", c.PorcentagemDesconto);

            cmd.ExecuteNonQuery();

        }

        // LISTANDO ClienteS (SELECT)

        public List<Cliente> Read()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from ClientesVIP";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                //cliente.ClienteId = reader.GetInt32(0);
                cliente.Pessoa_id                   = (int)reader["pessoa_id"];
                cliente.Nome                        = (string)reader["nome"];
                cliente.Email                       = (string)reader["email"];
                cliente.Senha                       = (string)reader["senha"];
                cliente.Cpf                         = (string)reader["cpf"];
                cliente.Imagem                      = (string)reader["imagem"];
                cliente.PorcentagemDesconto         = (decimal)reader["porcentagemDesconto"];

                lista.Add(cliente);
            }

            return lista;
        }

        // BUSCA DE CLIENTE POR NOME

        internal List<Cliente> Read(string nome)
        {
            List<Cliente> lista = new List<Cliente>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select * from Cliente where Nome like @nome";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                //cliente.ClienteId = reader.GetInt32(0);
                cliente.Pessoa_id           = (int)reader["pessoa_id"];
                cliente.Nome                = (string)reader["nome"];
                cliente.Email               = (string)reader["email"];
                cliente.Senha               = (string)reader["senha"];
                cliente.Cpf                 = (string)reader["cpf"];
                cliente.Imagem              = (string)reader["imagem"];
                cliente.PorcentagemDesconto = (decimal)reader["porcentagemDesconto"];

                lista.Add(cliente);
            }

            return lista;

        }

        // BUSCA POR ID

        internal Cliente Read(int pessoa_id)
        {
            Cliente cliente = new Cliente();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select * from ClientesVIP where pessoa_id = @pessoa_id";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@pessoa_id", pessoa_id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                
                //cliente.ClienteId = reader.GetInt32(0);
                cliente.Pessoa_id = (int)reader["pessoa_id"];
                cliente.Nome = (string)reader["nome"];
                cliente.Email = (string)reader["email"];
                cliente.Senha = (string)reader["senha"];
                cliente.Cpf = (string)reader["cpf"];
                cliente.Imagem = (string)reader["imagem"];
                cliente.PorcentagemDesconto = (decimal)reader["porcentagemDesconto"];
            }

            return cliente;

        }

        // ATUALIZAR CLIENTE
        public void Update(Cliente c)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                    UPDATE ClienteSVIP set
                    nome = @nome, email = @email, senha = @senha, Cpf = @cpf, imagem = @imagem, porcentagemDesconto = @porcentagemDesconto
                    WHERE
                    pessoa_id = @pessoa_id;
            ";

            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@senha", c.Senha);
            cmd.Parameters.AddWithValue("@cpf", c.Cpf);
            cmd.Parameters.AddWithValue("@imagem", c.Imagem);
            cmd.Parameters.AddWithValue("@porcenatgemDesconto", c.PorcentagemDesconto);
            cmd.Parameters.AddWithValue("@pessoa_id", c.Pessoa_id);

            cmd.ExecuteNonQuery();

        }

        // APAGAR CLIENTE
        public void Delete (int idCliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                    DELETE from ClientesVIP
                    WHERE
                    pessoa_id = @pessoa_id;
            ";

            cmd.Parameters.AddWithValue("@pessoa_id", idCliente);

            cmd.ExecuteNonQuery();

        }

    }

    /*public decimal gastos (int cliente)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"select	sum(co.valor)	Gastos

                            from Pessoas p, ClientesVIP c, Contas co

                            where	p.id = c.pessoa_id and
		                    c.pessoa_id = co.cliente_id and
                            c.dataFechamento is not null

                            group by c.pessoa_id, p.nome";
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return (decimal)reader["Gastos"];
        }
        // cmd.Parameters.AddWithValue("@idCliente", desconto);
        return 0;        

    }*/
}
