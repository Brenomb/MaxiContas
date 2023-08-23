namespace Contas;

public class MovimentoBancario
{
    public string descricao;
    public float valor;

    public MovimentoBancario(string _descricao, float _valor)
    {
        descricao = _descricao;
        valor = _valor;
    }
}