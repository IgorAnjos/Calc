using System;
using Calculadora.Classe;

namespace Calculadora
{
    /// <summary>
    /// Programa principal que demonstra o uso dos 4 pilares da OOP:
    /// 1. ENCAPSULAMENTO: Dados protegidos e acesso controlado nas classes
    /// 2. HERANÇA: OperacaoBase é herdada por todas as operações
    /// 3. POLIMORFISMO: Diferentes implementações do método Calcular()
    /// 4. ABSTRAÇÃO: OperacaoBase define o contrato sem implementação específica
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string nome = "";
                string nomeCalculadora = "";
                
                Console.WriteLine("Antes de começarmos. Defina um nome para a calculadora: ");
                nomeCalculadora = Console.ReadLine();
                
                // Usando ENCAPSULAMENTO: criando uma instância da classe Calculadora
                Classe.Calculadora calc = new Classe.Calculadora(nomeCalculadora);
                
                Console.WriteLine($"{calc.Nome} diz: {calc.ApresentarSe()}");
                Console.WriteLine($"{calc.Nome} diz: E qual é o seu nome?");
                nome = Console.ReadLine();

                MostrarBoasVindas(calc.Nome, nome);
                MostrarOperacoes();

                bool continuar = true;
                while (continuar)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\n{calc.Nome} diz: {nome}, digite o primeiro número:");
                        double num1 = double.Parse(Console.ReadLine());

                        Console.WriteLine($"{calc.Nome} diz: Agora digite o segundo número:");
                        double num2 = double.Parse(Console.ReadLine());

                        Console.WriteLine($"\n{calc.Nome} diz: {nome}, escolha uma operação (+, -, *, /):");
                        string operador = Console.ReadLine();

                        bool calcularResto = false;
                        if (operador == "/")
                        {
                            Console.WriteLine($"{calc.Nome} diz: Quer o quociente (Q) ou o resto (R)?");
                            string opcao = Console.ReadLine().ToUpper();
                            calcularResto = opcao == "R";
                        }

                        if (calc.OperacaoValida(operador))
                        {
                            // POLIMORFISMO em ação: o método ExecutarOperacao usa a classe base
                            // mas executa o comportamento específico de cada operação
                            double resultado = calc.ExecutarOperacao(operador, num1, num2, calcularResto);
                            
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"\n{calc.ObterDescricaoOperacao(operador, num1, num2, calcularResto)}");
                            Console.WriteLine($"Resultado: {resultado}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{calc.Nome} diz: Operação '{operador}' não é válida!");
                        }
                    }
                    catch (DivideByZeroException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{calc.Nome} diz: {nome}, não é possível dividir por zero!");
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{calc.Nome} diz: Por favor, digite um número válido!");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{calc.Nome} diz: Erro: {ex.Message}");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n{calc.Nome} diz: Deseja fazer outra operação? (S/N)");
                    string resposta = Console.ReadLine().ToUpper();
                    continuar = resposta == "S";
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n{calc.Nome} diz: Até logo, {nome}! Foi um prazer calcular com você!");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro fatal: {ex.Message}");
            }
        }

        // Métodos auxiliares para manter a interface amigável
        public static void MostrarBoasVindas(string nomeCalculadora, string nome)
        {
            Console.WriteLine($"{nome} diz: Olá {nomeCalculadora}, eu me chamo {nome}.");
            Console.WriteLine($"{nomeCalculadora} diz: Vamos começar! {nome}.");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ");
            Console.WriteLine($"========== Calculadora {nomeCalculadora} em C# ==========");
            Console.WriteLine("========== Refatorada com os 4 Pilares da OOP ==========");
            Console.WriteLine($"{nomeCalculadora} diz: {nome}, você escolhe dois números");
            Console.WriteLine($"{nomeCalculadora} diz: E depois escolhe uma das operações disponíveis.");
            Console.WriteLine(" ");
        }

        public static void MostrarOperacoes()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ");
            Console.WriteLine("========== Operações Disponíveis ===========");
            Console.WriteLine("========== >   +  (Adição)       < ==========");
            Console.WriteLine("========== >   -  (Subtração)    < ==========");
            Console.WriteLine("========== >   *  (Multiplicação)< ==========");
            Console.WriteLine("========== >   /  (Divisão)      < ==========");
            Console.WriteLine(" ");
        }
    }
}