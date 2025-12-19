using System;

namespace Calculadora.Classe
{
    /// <summary>
    /// Classe que implementa a operação de adição
    /// Demonstra HERANÇA (herda de OperacaoBase) e POLIMORFISMO (implementa Calcular)
    /// </summary>
    public class Adicao : OperacaoBase
    {
        // POLIMORFISMO: Implementação específica do método abstrato
        public override double Calcular()
        {
            if (!ValidarNumeros())
                throw new InvalidOperationException("Números inválidos para operação");

            return PrimeiroNumero + SegundoNumero;
        }

        // POLIMORFISMO: Sobrescrevendo método virtual da classe base
        public override string ObterDescricao()
        {
            return $"Adição: {PrimeiroNumero} + {SegundoNumero} = {Calcular()}";
        }
    }
}
