namespace Contas;

public class ContaCorrente
{
    Cliente cliente;
    public TipoConta tipoDeConta;
    List<MovimentoBancario> Movimentos = new List<MovimentoBancario>();

    public ContaCorrente(ref Cliente Nome, TipoConta _tipoDeConta)
    {
        this.cliente = Nome;
        this.tipoDeConta = _tipoDeConta;
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

    public float obterValorMensalidade()
    {
        TipoConta conta;
        conta = tipoDeConta;
        return conta.obtemMensalidade(ObtemSaldo(), Movimentos);
    }
}