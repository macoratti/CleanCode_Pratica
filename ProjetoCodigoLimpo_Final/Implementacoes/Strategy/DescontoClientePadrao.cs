using ProjetoCodigoLimpo_Final.Interfaces;

namespace ProjetoCodigoLimpo_Final.Implementacoes.Strategy;

public class DescontoClientePadrao : ICalculadoraDesconto
{
    public decimal AplicarDesconto(decimal preco)
    {
        return preco;
    }
}
