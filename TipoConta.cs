namespace Contas;

public interface TipoConta
{
    public float obtemMensalidade(float saldo, List<MovimentoBancario> Movimentos);
}
