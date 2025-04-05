using System;
using System.Data.SqlClient;
using System.Linq.Expressions;//Para coneção com Banco de dados

namespace SistemaLoginConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario();
            bool sair = false;

            while(! sair)
            {
                Console.WriteLine("\n1 Cadastrar");
                Console.WriteLine("2 fazer Login");
                Console.WriteLine("0 Sair");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case"1":
                        usuario.Cadastar();
                        break;
                    case"2":
                        if (usuario.FazerLogin())
                            Console.WriteLine("Login realizado com sucesso");
                        else
                            Console.WriteLine("Login o senha inválida");                                              
                        break;
                    case"0":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("opção Inválida");
                        break;
                       

                   
                }
            }

        }
    }
}
