using System;

namespace TratamentoDeErro
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        static void TryCatch()           //Tratar erros sempre do mais específico para o mais genérico 
        {
            var arr = new int[3];

            try     //tente executar o for
            {

                // for (var index = 0; index < 10; index++)
                // {
                //     //System.IndexOutOfRangeException           // tipo da exceção
                //     Console.WriteLine(arr[index]);
                // }

                Cadastrar("");
            }
            catch (IndexOutOfRangeException ex)       //se algo der errado, execute:
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);                              //mensagem diz qual é o erro
                Console.WriteLine("Não encontrei o índice na lista");
            }
            catch (ArgumentNullException ex)       //se algo der errado, execute:
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Falha ao cadastrar texto");
            }
            catch (MinhaExcepition ex)       //se algo der errado, execute:
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.QuandoAconteceu);
                Console.WriteLine("Exceção customizada");
            }
            catch (Exception ex)       //se algo der errado, execute:
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ops, algo deu errado!");
            }
            finally     //sempre acontece independentemente da exception
            {           //Finally tambem usado para fechar o arquivo após a execução 
                Console.WriteLine("Chegou ao fim!");
            }
        }

        private static void Cadastrar(string texto)
        {
            if (string.IsNullOrEmpty(texto))        //Dispara uma Exceção 
            {
                throw new MinhaExcepition(DateTime.Now);
            }
        }

        public class MinhaExcepition : Exception        //Herança da exception
        {
            public MinhaExcepition(DateTime date)
            {
                QuandoAconteceu = date;
            }
            public DateTime QuandoAconteceu { get; set; }
        }
    }
}