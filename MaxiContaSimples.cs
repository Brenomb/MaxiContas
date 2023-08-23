namespace Contas;

public class MaxiContaSimples : TipoConta
{
    float TipoConta.obtemMensalidade(float _saldo, List<MovimentoBancario> Movimentos)
    {
        float valorMensalidade = 0;
        float valorPacote = 20f;
        float desconto = 0;
        float saldo = _saldo;
        
        int CustoAdd = 0;

        if(saldo < 100 && Movimentos.Count() < 5)
        {
            return valorPacote;
        }
        else
        {
            int mov = Movimentos.Count();
            if (mov > 5)
            {
                CustoAdd = mov - 5;
            }

            desconto = ((saldo - 100) * 100) / 1400;
            valorMensalidade = (valorPacote) - (valorPacote * (desconto / 100)) + CustoAdd;
        }

        return valorMensalidade;
    }
}