using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios
{
    class Funcionario
    {
        public string Nome;
        public double Salario;
        public double Imposto;

        public double SalarioLiquido()
        {
            return Salario - Imposto;
        }

        public void AumentarSalario(double porcentagem)
        {
            if(porcentagem > 0)
            {
                Salario += Salario * porcentagem / 100;
            }
            
        }
    }
}
