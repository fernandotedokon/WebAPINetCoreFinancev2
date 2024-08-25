using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {

        public Titular Titular { get; set; }
        public int Conta { get; set; }

        private double saldo;

        private double taxaSaque = 3.50;



        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if (value < 0)
                {
                    saldo = value;
                }
                else
                {
                    saldo = value;
                }
            }
        }


        public void Depositar(double valor)
        {
            if (valor < 0)
            {
                return;
            }
            saldo = saldo + valor;
        }


        public void Sacar(double valor)
        {
            double valorTaxa = valor + taxaSaque;
            double _saldo = 0;

            if (valorTaxa <= Saldo)
            {
                Saldo -= valorTaxa;
            }
            else if (valorTaxa >= Saldo)
            {
                _saldo = Saldo - valorTaxa;
                Saldo = _saldo;

            }

        }



        public override string ToString()
        {

            return $"Conta: {this.Conta}, " +
                   $"Titular: {this.Titular.Nome}, " +
                   $"Saldo: $ {this.Saldo} ";

        }


    }
}
