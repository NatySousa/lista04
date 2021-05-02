using Lista04.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Lista04.Repositories
{
    public class ClienteRepository
    {
        private string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDLista04;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Inserir(Cliente cliente)
        {
            var sql = @"
                    INSERT INTO CLIENTE(IDCLIENTE, NOME, CPF, DATANASCIMENTO, EMAIL)
                    VALUES(@IdCliente, @Nome, @Cpf, @DataNascimento, @Email)
                ";
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(sql, cliente);
            }

        }   
        public void Atualizar (Cliente cliente)
        {
            var sql = @"
                    UPDATE CLIENTE
                    SET
                       NOME = @Nome,
                       CPF = @Cpf,
                       DATANASCIMENTO = @DataNascimento,
                       EMAIL = @Email 
                   WHERE
                       IDCLIENTE = @IdCliente
                 ";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(sql, cliente);

            }
             

        }
        
        public void Excluir (Cliente cliente)
        {
            var sql = @"
                    DELETE FROM CLIENTE
                    WHERE IDCLIENTE = @IdCliente
               ";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(sql, cliente);
            }
        }


        public List<Cliente> Consultar()
        { 
            var sql = @" 
                     SELECT * FROM CLIENTE
                     ORDER BY NOME
              ";
            using ( var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Cliente>(sql).ToList();
            }

        }

        public Cliente ConsultarEmail(Cliente cliente)
        {
            var sql = @" 
                     SELECT * FROM CLIENTE
                     WHERE EMAIL = @Email
                     ORDER BY NOME
              ";
            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Cliente>(sql).FirstOrDefault();
            }

        }
    }
}



