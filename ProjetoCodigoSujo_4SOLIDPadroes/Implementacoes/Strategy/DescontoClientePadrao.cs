using ProjetoCodigoSujo_4SOLIDPadroes.Interfaces;

namespace ProjetoCodigoSujo_4SOLIDPadroes.Implementacoes.Strategy;

public class DescontoClientePadrao : ICalculadoraDesconto
{
    public decimal AplicarDesconto(decimal preco)
    {
        return preco;
    }
}
