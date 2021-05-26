using System;
namespace DIO
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            //Cria a conta            
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public bool Sacar(double valorSaque)
        {
            //Validar saldo insuficiente
            if(this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                Console.ReadKey();
                return false;
            }
            
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            Console.ReadKey();
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            
            Console.WriteLine("Saldo atual da conta {0} e {1}", this.Nome, this.Saldo);
            Console.ReadKey();
        }

        public void Transferir(double valorTrasferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTrasferencia))
            {
                contaDestino.Depositar(valorTrasferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }
}