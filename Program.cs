using System.Security.Principal;

namespace ProjetoContas{
public class Cliente
{
    string nome;
    public Cliente(string Nome)
    {
        this.nome = Nome;
    }
}

public class MovimentoBancario
{
    public string descricao;
    public float valor;

    public MovimentoBancario(string Descricao, float Valor)
    {
        descricao = Descricao;
        valor = Valor;
    }
}

public class ContaCorrente
{
    Cliente cliente;
    List<MovimentoBancario> Movimentos = new List<MovimentoBancario>();

    public ContaCorrente(ref Cliente Nome)
    {
        this.cliente = Nome;
    }

    public void RealizaDeposito(string descricao, float valorDeposito)
    {
        MovimentoBancario novoMovimento = new MovimentoBancario(descricao, valorDeposito);
        Movimentos.Add(novoMovimento);
        Console.WriteLine("valor depositado!");
        Console.ReadKey();
    }

    public void RealizaSaque(string descricao, float valorSaque)
    {
        MovimentoBancario novoMovimento = new MovimentoBancario(descricao, -(valorSaque));
        Movimentos.Add(novoMovimento);
        Console.WriteLine("valor sacado!");
        Console.ReadKey();
    }

    public float ObtemSaldo()
    {
        float saldo = 0;
        foreach (MovimentoBancario movimento in Movimentos)
        {
            saldo += movimento.valor;
        }
        return saldo;
    }

    public float obterValorMensalidade(int maxiConta)
    {
        float valorMensalidade = 0;
        float valorPacote;
        float saldo = ObtemSaldo();
        float desconto;
        
        if (maxiConta == 1) //Maxi Conta Total
        {
            valorPacote = 50f;
            if (saldo >= 200)
            {
                desconto = ((saldo - 200)*100)/1800;
                valorMensalidade = valorPacote - (valorPacote * (desconto/100));
            }
            else
            {
                valorMensalidade = valorPacote;
            }
        }
        
        else if (maxiConta == 2) //Maxi Conta Simples
        {
            valorPacote = 20f;
            int CustoAdd = 0;
            
            if (saldo >= 100)
            {
                int mov = Movimentos.Count();
                if (mov > 5)
                {
                    CustoAdd = mov - 5;
                }
                desconto = ((saldo - 100)*100)/1400;
                valorMensalidade = (valorPacote ) - (valorPacote * (desconto/100))+ CustoAdd ;
            }
        }
        
        else if (maxiConta == 3) //Maxi Conta Economica
        {
            
        }
        return valorMensalidade;
    }

}

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            float valorSaque, valorDeposto;
            string descricaoSaque, descricaoDeposito;

            Console.WriteLine("Qual é seu nome?");
            string nome = Console.ReadLine();
            Cliente cliente = new Cliente(nome);
                
            Console.WriteLine("Qual tipo de conta voce deseja criar?");
            Console.WriteLine("1 - Conta Total");
            Console.WriteLine("2 - Conta Simples");
            Console.WriteLine("3 - Conta Economica");
                
            int maxiConta = int.Parse(Console.ReadLine());
            ContaCorrente contaCorrente = new ContaCorrente(ref cliente);
            
            int operacao;
            
            do
            {
                    Console.WriteLine("Qual tipo de operação deseja fazer?");
                    Console.WriteLine("1 - Depositar");
                    Console.WriteLine("2 - Sacar");
                    Console.WriteLine("3 - Consultar Saldo");
                    Console.WriteLine("4 - Ver mensalidade");
                    Console.WriteLine("5 - voltar");
                    operacao = int.Parse(Console.ReadLine());

                
                    switch (operacao)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Qual valor deseja depositar?");
                            valorDeposto = float.Parse(Console.ReadLine());
                            Console.WriteLine("Qual o motivo do deposito?");
                            descricaoDeposito = Console.ReadLine();
                            contaCorrente.RealizaDeposito(descricaoDeposito, valorDeposto);
                            break;
                        
                        case 2: 
                            Console.Clear();
                            Console.WriteLine("Qual valor deseja sacar?");
                            valorSaque = float.Parse(Console.ReadLine());
                            Console.WriteLine("Qual o motivo do saque?");
                            descricaoSaque = Console.ReadLine();
                            contaCorrente.RealizaSaque(descricaoSaque, valorSaque);
                            break;
                        
                        case 3:
                            Console.Clear();
                            contaCorrente.ObtemSaldo();
                            Console.WriteLine("Seu saldo é: " + contaCorrente.ObtemSaldo());
                            Console.ReadKey();
                            break;
                        
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Sua mensalidade é: " + contaCorrente.obterValorMensalidade(maxiConta));
                            Console.ReadKey();
                            break;
                    }
            } while (operacao != 5);

        }
    }
}
