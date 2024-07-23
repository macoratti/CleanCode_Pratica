namespace ProjetoCodigoSujo_3NumerosMagicos;

public class CalculadoraDeDesconto
{
    public decimal CalcularDesconto(decimal precoDoProduto,
                                    StatusDaConta statusDaConta,
                                    int tempoDaContaEmAnos)
    {
        decimal precoDepoisDoDesconto = 0;

        decimal percentualDoDescontoPorFidelidade = (tempoDaContaEmAnos > Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE) ?
                                                   (decimal)Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE / 100 :
                                                   (decimal)tempoDaContaEmAnos / 100;

        switch(statusDaConta)
        {
            case StatusDaConta.ClientePadrao:
                precoDepoisDoDesconto = precoDoProduto;
                break;
            case StatusDaConta.ClienteEspecial:
                precoDepoisDoDesconto = CalcularPrecoDepoisDoDesconto(precoDoProduto,
                                                                  Constantes.DESCONTO_CLIENTE_ESPECIAL,
                                                                  percentualDoDescontoPorFidelidade);
                break;
            case StatusDaConta.ClienteOuro:
                precoDepoisDoDesconto = CalcularPrecoDepoisDoDesconto(precoDoProduto,
                                                                  Constantes.DESCONTO_CLIENTE_OURO,
                                                                  percentualDoDescontoPorFidelidade);
                break;
            case StatusDaConta.ClienteVIP:
                precoDepoisDoDesconto = CalcularPrecoDepoisDoDesconto(precoDoProduto,
                                                                  Constantes.DESCONTO_CLIENTE_VIP,
                                                                  percentualDoDescontoPorFidelidade);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return precoDepoisDoDesconto;
    }

    public decimal CalcularPrecoDepoisDoDesconto(decimal precoDoProduto,
                                                 decimal percentualDesconto,
                                                 decimal percentualDoDescontoPorFidelidade)
    {
        decimal precoComDesconto = precoDoProduto - (percentualDesconto * precoDoProduto);
        return precoComDesconto - (percentualDoDescontoPorFidelidade * precoComDesconto);
    }
}