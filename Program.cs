using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace Calculadora

{

    class Program

    {
        static void Main(string[] args)

        {
            double num1, num2;
            int resul = 0;
            double total = 0;
            string resultado = null;

            Console.WriteLine("Digite o primeiro numero");
            num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o segundo numero");
            num2 = double.Parse(Console.ReadLine());

            Console.Clear();

            while (resul != 5)

            {
                Console.WriteLine("Para somar digite 1");
                Console.WriteLine("Para subtrair digite 2");
                Console.WriteLine("Para dividir digite 3");
                Console.WriteLine("Para multiplicar digite 4");
                Console.WriteLine("Para sair digite 5");
                resul = int.Parse(Console.ReadLine());

                if (resul == 1)

                {
                    Console.WriteLine("Soma = {0}", num1 + num2);
                    total = num1 + num2;
                    resultado = ($"{num1} + {num2} = {total}");
                }

                else if (resul == 2)

                {
                    Console.WriteLine("Subtração = {0}", num1 - num2);
                    total = num1- num2;
                    resultado = ($"{num1} - {num2} = {total}");
                }

                else if (resul == 3)

                {
                    Console.WriteLine("Divisão = {0}", num1 / num2);
                    total = num1 / num2;
                    resultado = ($"{num1} / {num2} = {total}");
                }

                else if (resul == 4)

                {
                    Console.WriteLine("Multiplicação = {0}", num1 * num2);
                    total = num1 * num2;
                    resultado = ($"{num1} * {num2} = {total}");
                }

                Console.WriteLine(resultado);
                Console.ReadLine();
                Console.Clear();
         
                //Conexão com o banco de dados e armazenando o valor da variavel 'resultado';
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=calculadora;Integrated Security=True"); // A propriedade Integrated Security instrui o SQL Client a se conectar ao SQL Server usando a Autenticação do Windows por meio da Security Support Provider Interface (SSPI) . Esta propriedade opcional aceita um valor booleano de true, false, yes e no. O valor padrão é falso.
                string query = "INSERT INTO respostas2 (resp2) VALUES('" + resultado + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Gravação inserida com sucesso");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Erro Gerado. Detalhes: " + e.ToString());
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
        }
    }
}

