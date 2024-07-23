using ProjetoCodigoLimpo_Final.Interfaces;

namespace ProjetoCodigoLimpo_Final.Implementacoes.Strategy;

public class DescontoClienteVIP : ICalculadoraDesconto
{
    public decimal AplicarDesconto(decimal preco)
    {
        return preco - (Constantes.DESCONTO_CLIENTE_VIP * preco);
    }
}
