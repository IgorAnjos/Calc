using System;
using System.Collections.Generic;

namespace Calculadora.Classe
{
    /// <summary>
    /// Classe principal da Calculadora que gerencia operações
    /// Demonstra ENCAPSULAMENTO completo e uso de POLIMORFISMO
    /// </summary>
    public class Calculadora
    {
        // ENCAPSULAMENTO: Campos privados
        private string _nome;
        private Dictionary<string, OperacaoBase> _operacoesDisponiveis;

        // ENCAPSULAMENTO: Propriedade pública com validação
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome não pode ser vazio");
                _nome = value;
            }
        }

        // Construtor que inicializa a calculadora
        public Calculadora(string nome)
        {
            Nome = nome;
            InicializarOperacoes();
        }

        // ENCAPSULAMENTO: Método privado para inicializar operações
        private void InicializarOperacoes()
        {
            _operacoesDisponiveis = new Dictionary<string, OperacaoBase>
            {
                { "+", new Adicao() },
                { "-", new Subtracao() },
                { "*", new Multiplicacao() },
                { "/", new Divisao() }
            };
        }

        // Método público para executar operações (POLIMORFISMO em ação)
        public double ExecutarOperacao(string operador, double numero1, double numero2, bool calcularResto = false)
        {
            if (!_operacoesDisponiveis.ContainsKey(operador))
                throw new InvalidOperationException($"Operação '{operador}' não suportada");

            // POLIMORFISMO: Usa a classe base para trabalhar com qualquer operação
            OperacaoBase operacao = _operacoesDisponiveis[operador];
            operacao.PrimeiroNumero = numero1;
            operacao.SegundoNumero = numero2;

            // Tratamento especial para divisão
            if (operacao is Divisao divisao)
            {
                divisao.CalcularResto = calcularResto;
            }

            return operacao.Calcular();
        }

        // Método para obter descrição da operação
        public string ObterDescricaoOperacao(string operador, double numero1, double numero2, bool calcularResto = false)
        {
            if (!_operacoesDisponiveis.ContainsKey(operador))
                return "Operação não suportada";

            OperacaoBase operacao = _operacoesDisponiveis[operador];
            operacao.PrimeiroNumero = numero1;
            operacao.SegundoNumero = numero2;

            if (operacao is Divisao divisao)
            {
                divisao.CalcularResto = calcularResto;
            }

            return operacao.ObterDescricao();
        }

        // Método para listar operações disponíveis
        public List<string> ObterOperacoesDisponiveis()
        {
            return new List<string>(_operacoesDisponiveis.Keys);
        }

        // Método para apresentação da calculadora
        public string ApresentarSe()
        {
            return $"Olá, eu me chamo {_nome}";
        }

        // ENCAPSULAMENTO: Valida se uma operação é válida
        public bool OperacaoValida(string operador)
        {
            return _operacoesDisponiveis.ContainsKey(operador);
        }
    }
}
