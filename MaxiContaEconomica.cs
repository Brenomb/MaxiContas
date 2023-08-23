namespace Contas;

public class MaxiContaEconomica : TipoConta
{
    float TipoConta.obtemMensalidade(float _saldo, List<MovimentoBancario> Movimentos)
    {
        float valorPacote = 10f;
        Movimentos.ForEach(movimento => { valorPacote += 1.5f;});
        return valorPacote;
    }
}