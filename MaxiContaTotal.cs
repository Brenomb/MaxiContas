namespace Contas;

public class MaxiContaTotal : TipoConta
{
    float TipoConta.obtemMensalidade(float _saldo, List<MovimentoBancario> Movimentos)
    {
        float valorMensalidade = 0;
        float valorPacote = 50f;
        float desconto = 0;
        float saldo = _saldo;
            
        if (saldo >= 200)
        {
            desconto = ((saldo - 200)*100)/1800;
            valorMensalidade = valorPacote - (valorPacote * (desconto/100));
        }
        else
        {
            valorMensalidade = valorPacote;
        }
        return valorMensalidade;
    }
}