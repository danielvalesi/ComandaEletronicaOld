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
        public void Create(Cliente e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                    INSERT INTO Cliente
                    (Nome, Descricao, Preco)
                    VALUES
                    (@nome, @descricao, @preco)
            ";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@descricao", e.Descricao);
            cmd.Parameters.AddWithValue("@preco", e.Preco);


            cmd.ExecuteNonQuery();

        }

        // LISTANDO ClienteS (SELECT)

        public List<Cliente> Read()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Clientes";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                //cliente.ClienteId = reader.GetInt32(0);
                cliente.IdCliente = (int)reader["idCliente"];
                cliente.Nome = (string)reader["Nome"];
                cliente.Descricao = (string)reader["Descricao"];
                cliente.Preco = (decimal)reader["Preco"];
  


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
                cliente.IdCliente = (int)reader["idCliente"];
                cliente.Nome = (string)reader["Nome"];
                cliente.Descricao = (string)reader["Descricao"];
                cliente.Preco = (decimal)reader["Preco"];

                

                lista.Add(cliente);
            }

            return lista;

        }

        // BUSCA POR ID

        internal Cliente Read(int idCliente)
        {
            Cliente cliente = new Cliente();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select * from Cliente where IdCliente = @idCliente";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cliente.IdCliente = (int)reader["idCliente"];
                cliente.Nome = (string)reader["Nome"];
                cliente.Descricao = (string)reader["Descricao"];
                cliente.Preco = (decimal)reader["Preco"];
            }

            return cliente;

        }

        // ATUALIZAR CLIENTE
        public void Update(Cliente e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                    UPDATE Cliente set
                    Nome = @nome, Descricao = @descricao, Preco = @preco
                    WHERE
                    idCliente = @idCliente;
            ";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@descricao", e.Descricao);
            cmd.Parameters.AddWithValue("@preco", e.Preco);
            cmd.Parameters.AddWithValue("@idCliente", e.IdCliente);

            cmd.ExecuteNonQuery();

        }

        // APAGAR CLIENTE
        public void Delete (int idCliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                    DELETE from Cliente
                    WHERE
                    idCliente = @idCliente;
            ";

            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            cmd.ExecuteNonQuery();

        }

        }

    public decimal gastos (int cliente)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"select	sum(co.valor)	Gastos

                            from Pessoas p, ClientesVIP c, Contas co

                            where	p.id = c.pessoa_id and
		                    c.pessoa_id = co.cliente_id

                            group by c.pessoa_id, p.nome";
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return (decimal)reader["Gastos"];
        }
        // cmd.Parameters.AddWithValue("@idCliente", desconto);
        return 0;        

    }
    }
