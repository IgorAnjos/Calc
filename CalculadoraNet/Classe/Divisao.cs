using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Classe
{
    public class Divisao
    {

        public static float Div(float dividendo, float divisor)
        {
            float result;

            if (divisor.Equals(0))
                return result = -1;
            
            result = (dividendo / divisor);

            return result;
        }

        public static float Div(float dividendo, float divisor, bool resto)
        {
            float result;
            
            if (divisor.Equals(0))
                return result = -1;

            result = (dividendo % divisor);

            return result;
        }
    }
}
