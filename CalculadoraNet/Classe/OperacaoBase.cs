using System;

namespace Calculadora.Classe
{
    /// <summary>
    /// Classe abstrata que representa a base para todas as operações matemáticas
    /// Implementa ABSTRAÇÃO e serve como base para HERANÇA
    /// </summary>
    public abstract class OperacaoBase
    {
        // ENCAPSULAMENTO: Propriedades privadas com acesso controlado
        private double _primeiroNumero;
        private double _segundoNumero;

        public double PrimeiroNumero
        {
            get { return _primeiroNumero; }
            set { _primeiroNumero = value; }
        }

        public double SegundoNumero
        {
            get { return _segundoNumero; }
            set { _segundoNumero = value; }
        }

        // Método abstrato que deve ser implementado pelas classes derivadas (POLIMORFISMO)
        public abstract double Calcular();

        // Método virtual que pode ser sobrescrito pelas classes derivadas
        public virtual string ObterDescricao()
        {
            return $"Operação com {_primeiroNumero} e {_segundoNumero}";
        }

        // Método protegido para validação (ENCAPSULAMENTO)
        protected bool ValidarNumeros()
        {
            return !double.IsNaN(_primeiroNumero) && !double.IsNaN(_segundoNumero);
        }
    }
}
