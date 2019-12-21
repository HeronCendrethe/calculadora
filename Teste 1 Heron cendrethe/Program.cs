using System;
using System.Data.SqlClient;
namespace Teste_1_Heron_cendrethe
{
    class Program
    {
        static void Main(string[] args)
        {
            Select select = new Select();
            Save save = new Save();
            Console.WriteLine("Digite o primeiro fator");
            save.numero1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("digite o segundo fator");
            save.numero2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("O resultado da soma e:" + (save.numero1 + save.numero2));
            Console.WriteLine("O resultado da subatração e:" + (save.numero1 - save.numero2));
            Console.WriteLine("O Resultado da multiplicação e:" + (save.numero1 * save.numero2));
            Console.WriteLine("O resultado da divisão e:" + (save.numero1 / save.numero2));

            save.resultadoSoma = (save.numero1 + save.numero2);
            save.resultadoDiv = (save.numero1 / save.numero2);
            save.resultadoMul = (save.numero1 * save.numero2);
            save.resultadoSub = (save.numero1 - save.numero2);

           
          
            SqlConnection cone = new SqlConnection(@"Data Source=DESKTOP-CUIAB6G;Initial Catalog=calculadora;User ID=sa;Password=***********");
           


            cone.ConnectionString = @"Data Source=DESKTOP-CUIAB6G;Initial Catalog=calculadora;User ID=sa;Password=123";
            string sql = "insert into salvarNumeros(numero1, numero2, resultadoDiv, resultadoMul, resultadoSoma, resultadoSub) values(@numero1,@numero2,@resultadoDiv,@resultadoMul,@resultadoSoma,@resultadoSub)";
            try
            {
                SqlCommand Command = new SqlCommand(sql,cone);
                Command.Parameters.Add(new SqlParameter("@numero1", save.numero1));
                Command.Parameters.Add(new SqlParameter("@numero2", save.numero2));
                Command.Parameters.Add(new SqlParameter("@resultadoSoma", save.resultadoSoma));
                Command.Parameters.Add(new SqlParameter("@resultadoDiv", save.resultadoDiv));
                Command.Parameters.Add(new SqlParameter("@resultadoSub", save.resultadoSub));
                Command.Parameters.Add(new SqlParameter("@resultadoMul", save.resultadoMul));
                cone.Open();
                Command.ExecuteNonQuery();
                cone.Close();
                Console.WriteLine("deu bom");
            }
            catch
            {
                Console.WriteLine("deu ruim porra");
            }

            Console.WriteLine("Digite o id que deseja buscar");
            int id;
            id = Convert.ToInt32(Console.ReadLine());

            
            string sqlSelect = "select* from salvarNumeros where idConta = @idConta";

         

                 cone.Open();
            SqlCommand command = new SqlCommand(sqlSelect,cone);


               
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    select.numero1 = Convert.ToInt32(reader["numero1"]);
                    select.numero2 = Convert.ToInt32(reader["numero2"]);
                    select.resultadoDiv = Convert.ToInt32(reader["resultadoDiv"]);
                    select.resultadoSoma = Convert.ToInt32(reader["resultadoSoma"]);
                    select.resultadoMul = Convert.ToInt32(reader["resultadoMul"]);
                    select.resultadoSub = Convert.ToInt32(reader["resultadoSub"]);

                    Console.WriteLine(select.numero1);
                    

                }
                command.ExecuteReader();
                command.ExecuteNonQuery();
                cone.Close();
               
                



           



        }
    }
}