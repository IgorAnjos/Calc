using System;
using System.IO;

namespace Calculadora
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo caracter;
            int num1 = 0;
            int num2 = 0;
            string nome = "";
            string nomeCalculadora = "";
            ConsoleKeyInfo r;
            bool resto = false;

            Console.WriteLine("Antes de comerçarmos. Defina um nome para a calculadora: ");
            nomeCalculadora = Console.ReadLine();
            Console.WriteLine($"{nomeCalculadora} diz: Olá, eu me chamo {nomeCalculadora}");
            Console.WriteLine($"{nomeCalculadora} diz: E qual é o seu nome?");
            nome = Console.ReadLine();

            Start(nomeCalculadora, nome);

            Operacoes();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{nomeCalculadora} diz: {nome} Digite o primeiro número para utilizar no cálculo.");
            Console.WriteLine("Primeiro número: ");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{nome} diz: {nomeCalculadora} pronto.");
            Console.WriteLine($"{nomeCalculadora} diz: Legal {nome}, agora digite o segundo número.");
            Console.WriteLine("Segundo número: ");
            num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{nome} diz: {nomeCalculadora} pronto.");

            Console.WriteLine($"{nomeCalculadora} diz: Digitando...");

            Console.WriteLine($"{nomeCalculadora} diz: {nome} agora você escolhe uma das 4 operações." +
                $"'+', '-', '*' ou '/'");
            
            do
            {
                caracter = Console.ReadKey();

                if (caracter.Key == ConsoleKey.Divide)
                {
                    Console.WriteLine($"{nomeCalculadora} diz: Muito bom {nome}, você escolheu a operação divisão");
                    Console.WriteLine($"{nomeCalculadora} diz: Quer saber o quociente ou o resto da divisão?");
                    Console.WriteLine($"{nomeCalculadora} diz: 'Q/q' para quociente e 'R/r' para resto.");
                    r = Console.ReadKey();
                    if (r.Key == ConsoleKey.R)
                        resto = true;
                }

                Console.WriteLine($"{nomeCalculadora} diz: Estamos quase lá {nome}. A operação escolhida é '{caracter.Key}'.");

                Console.WriteLine($"{nomeCalculadora} diz: Digitando...");
                Console.WriteLine();

                float result = 0;
                string operacao = "";
                switch (caracter.Key)
                {
                    case ConsoleKey.Add:
                        result = Classe.Adicao.Add(num1, num2);
                        operacao = "soma";
                        break;
                    case ConsoleKey.Subtract:
                        result = Classe.Subtracao.Sub(num1, num2);
                        operacao = "subtração";
                        break;
                    case ConsoleKey.Multiply:
                        result = Classe.Multiplicacao.Mul(num1, num2);
                        operacao = "multiplicação";
                        break;
                    case ConsoleKey.Divide:
                        switch (num2)
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{nomeCalculadora} diz: {nome} não é possível dividir por 'Zero'. Por gentileza, coloque um valor válido!");
                                break;
                            default:
                                if (resto)
                                {
                                    Console.WriteLine($"{nomeCalculadora} diz: Calculando ...");
                                    result = Classe.Divisao.Div(num1, num2, resto);
                                    operacao = "divisão";
                                }
                                else
                                {
                                    Console.WriteLine($"{nomeCalculadora} diz: Calculando ...");
                                    result = Classe.Divisao.Div(num1, num2);
                                    operacao = "divisão";
                                }

                                break;
                        }
                        break;
                    default:
                        //Console.WriteLine($"{nomeCalculadora} diz: Está indeciso {nome}, vamos lá escolha uma das operações");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{nomeCalculadora} diz: Legal {nome} temos um resultado.");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"A {operacao} de {num1} por {num2} é {result}");

                //do
                //{
                //    caracter = Console.ReadKey();
                //    if (ConsoleKey.S == caracter.Key)
                //    { }
                //} while (ConsoleKey.S != caracter.Key);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{nomeCalculadora} diz: {nome} tecle 'ESC' para sair.");
                num1 = 0; num2 = 0;
            } while (caracter.Key != ConsoleKey.Escape);

        }
        public static void Start(string nomeCalculadora, string nome)
        {
            Console.WriteLine($"{nome} diz: Olá {nomeCalculadora}, eu me chamo {nome}.");
            Console.WriteLine($"{nomeCalculadora} diz: Vamos começar! {nome}.");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ");
            Console.WriteLine($"========== Calculadora {nomeCalculadora} em C# ==========");
            Console.WriteLine($"{nomeCalculadora} diz: {nome} primeiro você escolhe dois números inteiros");
            Console.WriteLine($"{nomeCalculadora} diz: E depois você escolhe uma das operações disponíveis.");
            Console.WriteLine(" ");
        }

        public static void Operacoes()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ");
            Console.WriteLine("========== Operações Básicas ===========");
            Console.WriteLine("========== >     +     < ==========");
            Console.WriteLine("========== >     -     < ==========");
            Console.WriteLine("========== >     *     < ==========");
            Console.WriteLine("========== >     /     < ==========");
            Console.WriteLine(" ");
        }
    }
}