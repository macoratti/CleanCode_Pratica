using Microsoft.Extensions.DependencyInjection;
using ProjetoCodigoLimpo_Final;
using ProjetoCodigoLimpo_Final.Implementacoes;
using ProjetoCodigoLimpo_Final.Implementacoes.Factory;
using ProjetoCodigoLimpo_Final.Interfaces;

namespace ProjetoCodigoLimpo_Tests;

public class CalculadoraDeDescontoTests
{
    private readonly CalculadoraDeDesconto _calculadoraDeDesconto;

    public CalculadoraDeDescontoTests()
    {
        // Configurar o container de serviços
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<ICalculadoraDescontoStatusContaFactory,
                                       CalculadoraDescontoStatusContaFactory>();

        serviceCollection.AddTransient<ICalculadoraDescontoPorFidelidade,
                                       CalculadoraDescontoPorFidelidade>();

        serviceCollection.AddTransient<CalculadoraDeDesconto>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolver a instância de CalculadoraDeDesconto
        _calculadoraDeDesconto = serviceProvider.GetService<CalculadoraDeDesconto>()
                                 ?? throw new InvalidOperationException("A instância de CalculadoraDeDesconto não pôde ser criada.");

    }

    [Theory]
    [InlineData(100, StatusDaConta.ClientePadrao, 0, 100)]
    [InlineData(100, StatusDaConta.ClienteEspecial, 2, 88.20)]
    [InlineData(100, StatusDaConta.ClienteOuro, 3, 67.90)]
    [InlineData(100, StatusDaConta.ClienteVIP, 5, 47.50)]
    public void CalcularDesconto_ValidInputs_ReturnsExpectedResult(decimal precoProduto,
                                                              StatusDaConta statusDaConta,
                                                              int tempoDeContaEmAnos,
                                                              decimal resultadoEsperado)
    {
        // Act - executa o teste
        var resultado = _calculadoraDeDesconto.AplicarDesconto(precoProduto, statusDaConta, tempoDeContaEmAnos);

        // Assert - verifica o resultado
        // precisao de duas casas decimais
        Assert.Equal(resultadoEsperado, resultado, 2);
    }

    [Fact]
    public void CalcularDesconto_InvalidStatusDaConta_ThrowsArgumentOutOfRangeException()
    {
        // Arrange - Preparação do testes
        var precoProduto = 100m;
        var tempoDeContaEmAnos = 1;
        // status invalido
        var statusDaConta = (StatusDaConta)99;

        // Act & Assert - execução e verificação
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             _calculadoraDeDesconto.AplicarDesconto(precoProduto, statusDaConta, tempoDeContaEmAnos));
    }
}