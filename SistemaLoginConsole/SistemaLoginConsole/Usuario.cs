using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;// Para coneção com banco de dados

namespace SistemaLoginConsole
{
    internal class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha {  get; set; }

        private string conecaoBanco = "Server=DESKTOP-JIBJ4K6\\SQLEXPRESS;Database=SistemaLoginDB;Trusted_connection=True";// Nessa string coloquei os parametros para acessar meu banco de dados

        public void Cadastar()
        {
            Console.WriteLine("Nome: ");
            Nome = Console.ReadLine();

            Console.WriteLine("Email: ");
            Email = Console.ReadLine();

            Console.WriteLine("Senha ");
            Senha = Console.ReadLine();

            using (SqlConnection conexao = new SqlConnection(conecaoBanco)) //String para abrir conecção com o banco
            {
                string query = " INSERT INTO Usuario (Nome,Email,Senha) VALUES (@Nome,@Email,@Senha)";// Utilizando INSERT para inserir valores ao banco

                SqlCommand comando = new SqlCommand(query, conexao);// comando com a instrução que estou utilizando

                comando.Parameters.AddWithValue("@Nome", Nome);
                comando.Parameters.AddWithValue("@Email", Email);//comandos para dizer que os valores reais vão subestituir os Values inicias
                comando.Parameters.AddWithValue("@Senha", Senha);

                conexao.Open();//abre a conecção
                comando.ExecuteNonQuery();//executar sem esperar algum retorno
                conexao.Close();// fechar conecção

                Console.WriteLine("cadastrado com sucesso");


            }


        }

        public bool FazerLogin()
        {
            Console.WriteLine("Email: ");
            string Email = Console.ReadLine();

            Console.WriteLine("Senha: ");
            string Senha = Console.ReadLine();

            using (SqlConnection conexao = new SqlConnection(conecaoBanco)) //String para abrir conecção com o banco
            {
                string query = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email AND Senha = @Senha";
                SqlCommand comando = new SqlCommand(query, conexao);

                comando.Parameters.AddWithValue("@Email", Email);
                comando.Parameters.AddWithValue("@Senha", Senha);

                conexao.Open();
                int count = (int)comando.ExecuteScalar();
                conexao.Close();
                return count > 0;

            }
        }
        

    }
}
