using ProjetoCodigoLimpo_Final.Interfaces;

namespace ProjetoCodigoLimpo_Final;

public class CalculadoraDeDesconto
{
    private readonly ICalculadoraDescontoStatusContaFactory _calculadoraDescontoStatusContaFactory;
    private readonly ICalculadoraDescontoPorFidelidade _calculadoraDescontoPorFidelidade;

    public CalculadoraDeDesconto(ICalculadoraDescontoStatusContaFactory calculadoraDescontoStatusContaFactory, 
                                 ICalculadoraDescontoPorFidelidade calculadoraDescontoPorFidelidade)
    {
        _calculadoraDescontoStatusContaFactory = calculadoraDescontoStatusContaFactory;
        _calculadoraDescontoPorFidelidade = calculadoraDescontoPorFidelidade;
    }

    public decimal AplicarDesconto(decimal precoDoProduto, StatusDaConta statusDaConta, int tempoDaContaEmAnos)
    {

        var calculadoraDesconto = _calculadoraDescontoStatusContaFactory.GetCalculoDescontoStatusConta(statusDaConta);

        var precoComDescontoStatus = calculadoraDesconto.AplicarDesconto(precoDoProduto);

        var precoFinal = _calculadoraDescontoPorFidelidade.CalcularDesconto(precoComDescontoStatus, tempoDaContaEmAnos);

        return precoFinal;
    }
}