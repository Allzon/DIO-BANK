using System;
using System.Collections.Generic;

namespace DIO
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaouser();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaouser();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista de Contas");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada ");
                return;
            }
            for(int i = 0; i<listContas.Count; i++)
            {
                Conta conta= listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que gostaria de depositar: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[numConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que gostaria de sacar: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[numConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da Conta receptora: ");
            Conta numrecep = listContas[int.Parse(Console.ReadLine())];

            Console.WriteLine("Digite o valor que gostaria de sacar: ");
            double valorTrasferencia = double.Parse(Console.ReadLine());

            listContas[numConta].Transferir(valorTrasferencia, numrecep);
        }

        private static void InserirConta()
        {
            Console.Clear();
            Console.WriteLine("Inserir nova conta");
            
            Console.WriteLine("Digite 1 para pessoa fisica ou 2 para pessoa juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        nome: entradaNome,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito);
            
            listContas.Add(novaConta);
        }

        private static string ObterOpcaouser()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Tesferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string optUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return optUser;
        }
    }
}
