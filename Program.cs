namespace Contas;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int operacao;
            float valorSaque, valorDeposto;
            string descricaoSaque, descricaoDeposito;

            Console.WriteLine("Qual é seu nome?");
            string nome = Console.ReadLine();
            
            
                
            Console.WriteLine("Qual tipo de conta voce deseja criar?");
            Console.WriteLine("1 - Conta Total");
            Console.WriteLine("2 - Conta Simples");
            Console.WriteLine("3 - Conta Economica");
                
            int maxiConta = int.Parse(Console.ReadLine());

            TipoConta tipoConta = null;
            Cliente cliente = new Cliente(nome);

            if (maxiConta == 1)
            {
                tipoConta = new MaxiContaTotal();
            }
            else if (maxiConta == 2)
            {
                tipoConta = new MaxiContaSimples();
            }
            else if (maxiConta == 3)
            {
                tipoConta = new MaxiContaEconomica();
            }
            ContaCorrente conta = new ContaCorrente(ref cliente, tipoConta);

            do
            {
                    Console.WriteLine("Qual tipo de operação deseja fazer?");
                    Console.WriteLine("1 - Depositar");
                    Console.WriteLine("2 - Sacar");
                    Console.WriteLine("3 - Consultar Saldo");
                    Console.WriteLine("4 - Ver mensalidade");
                    Console.WriteLine("5 - trocar de conta");
                    Console.WriteLine("6 - sair");
                    operacao = int.Parse(Console.ReadLine());

                
                    switch (operacao)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Qual valor deseja depositar?");
                            valorDeposto = float.Parse(Console.ReadLine());
                            Console.WriteLine("Qual o motivo do deposito?");
                            descricaoDeposito = Console.ReadLine();
                            conta.RealizaDeposito(descricaoDeposito, valorDeposto);
                            break;
                        
                        case 2: 
                            Console.Clear();
                            Console.WriteLine("Qual valor deseja sacar?");
                            valorSaque = float.Parse(Console.ReadLine());
                            Console.WriteLine("Qual o motivo do saque?");
                            descricaoSaque = Console.ReadLine();
                            conta.RealizaSaque(descricaoSaque, valorSaque);
                            break;
                        
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Seu saldo é: " + conta.ObtemSaldo());
                            Console.ReadKey();
                            break;
                        
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Sua mensalidade é: " + conta.obterValorMensalidade());
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.WriteLine("Pra qual conta deseja alterar?");
                            Console.WriteLine("1 - Conta Total");
                            Console.WriteLine("2 - Conta Simples");
                            Console.WriteLine("3 - Conta Economica");

                            int novaConta = int.Parse(Console.ReadLine());

                            if (novaConta == 1)
                            {
                                conta.tipoDeConta = new MaxiContaTotal();
                            }

                            else if (novaConta == 2)
                            {
                                conta.tipoDeConta = new MaxiContaSimples();
                            }
                            else
                            {
                                conta.tipoDeConta = new MaxiContaEconomica();
                            }
                                
                            
                            break;
                    }
            } while (operacao != 6);

        }
    }
