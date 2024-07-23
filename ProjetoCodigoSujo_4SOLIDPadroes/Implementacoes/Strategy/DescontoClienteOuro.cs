using ProjetoCodigoSujo_4SOLIDPadroes.Interfaces;

namespace ProjetoCodigoSujo_4SOLIDPadroes.Implementacoes.Strategy;

public class DescontoClienteOuro : ICalculadoraDesconto
{
    public decimal AplicarDesconto(decimal preco)
    {
        return preco - (Constantes.DESCONTO_CLIENTE_OURO * preco);
    }
}
