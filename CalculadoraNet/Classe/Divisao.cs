using System;

namespace Calculadora.Classe
{
    /// <summary>
    /// Classe que implementa a operação de divisão
    /// Demonstra HERANÇA (herda de OperacaoBase) e POLIMORFISMO (implementa Calcular)
    /// ENCAPSULAMENTO: Propriedade privada para controlar tipo de divisão
    /// </summary>
    public class Divisao : OperacaoBase
    {
        // ENCAPSULAMENTO: Campo privado com propriedade pública
        private bool _calcularResto;

        public bool CalcularResto
        {
            get { return _calcularResto; }
            set { _calcularResto = value; }
        }

        // POLIMORFISMO: Implementação específica do método abstrato
        public override double Calcular()
        {
            if (!ValidarNumeros())
                throw new InvalidOperationException("Números inválidos para operação");

            // Validação específica da divisão (ENCAPSULAMENTO)
            if (SegundoNumero == 0)
                throw new DivideByZeroException("Não é possível dividir por zero");

            // POLIMORFISMO: Comportamento diferente baseado na propriedade
            if (_calcularResto)
                return PrimeiroNumero % SegundoNumero;
            else
                return PrimeiroNumero / SegundoNumero;
        }

        // POLIMORFISMO: Sobrescrevendo método virtual da classe base
        public override string ObterDescricao()
        {
            string operacao = _calcularResto ? "Resto da divisão" : "Divisão";
            string simbolo = _calcularResto ? "%" : "÷";
            return $"{operacao}: {PrimeiroNumero} {simbolo} {SegundoNumero} = {Calcular()}";
        }
    }
}
