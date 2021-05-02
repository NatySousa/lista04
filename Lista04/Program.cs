using Lista04.Entities;
using Lista04.Repositories;
using System;
using System.Linq;

namespace Lista04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n*** CADASTRO DE CLIENTES ***\n");

            try
            {
                var cliente = new Cliente();

                cliente.IdCliente = Guid.NewGuid();

                Console.Write("\nInforme o nome do cliente: ");
                cliente.Nome = Console.ReadLine();

                Console.Write("\nInforme o cpf do cliente: ");
                cliente.Cpf = Console.ReadLine();

                Console.Write("\nInforme a data de nascimento do cliente: ");
                cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

                Console.Write("\nInforme o email do cliente: ");
                cliente.Email = Console.ReadLine();

                var clienteRepository = new ClienteRepository();
                clienteRepository.Inserir(cliente);

                Console.WriteLine("\nCliente cadastrado com sucesso! ");
               
                Console.WriteLine("\n*** CONSULTA DE CLIENTES ***\n ");

                foreach (var item in clienteRepository.Consultar())
                {

                    Console.Write("\nId do Cliente..........................:" + item.IdCliente);
                    Console.Write("\nNome do Cliente........................:" + item.Nome);
                    Console.Write("\nCpf do Cliente.........................:" + item.Cpf);
                    Console.Write("\nData de Nascimento do Cliente..........:" + item.DataNascimento);
                    Console.Write("\nEmail do Cliente.......................:" + item.Email);
                    Console.WriteLine();

                }
               

                Console.Write("\nEmail invalido.Por favor informe um novo email: ");
                cliente.Email = Console.ReadLine();

                clienteRepository.Atualizar(cliente);

                Console.WriteLine("\n*** CONSULTA DE CLIENTES ***\n ");

                foreach (var item in clienteRepository.Consultar())
                {

                    Console.Write("\nId do Cliente..........................:" + item.IdCliente);
                    Console.Write("\nNome do Cliente........................:" + item.Nome);
                    Console.Write("\nCpf do Cliente.........................:" + item.Cpf);
                    Console.Write("\nData de Nascimento do Cliente..........:" + item.DataNascimento);
                    Console.Write("\nEmail do Cliente.......................:" + item.Email);
                    Console.WriteLine();
                }
                Console.WriteLine("\nDeseja excluir o ultimo cliente cadastrado? Sim ou Não? ");

                if (Console.ReadLine()=="Sim")
                {
                    clienteRepository.Excluir(cliente);

                    Console.WriteLine("\nCadastro excluido com sucesso! ");
                }


            }

            catch(Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }

            Console.ReadKey();
        }   


    }
}
