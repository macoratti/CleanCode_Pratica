using Microsoft.Extensions.DependencyInjection;
using ProjetoCodigoLimpo_Final;
using ProjetoCodigoLimpo_Final.Implementacoes;
using ProjetoCodigoLimpo_Final.Implementacoes.Factory;
using ProjetoCodigoLimpo_Final.Interfaces;

var serviceProvider = new ServiceCollection()
            .AddScoped<ICalculadoraDescontoStatusContaFactory, CalculadoraDescontoStatusContaFactory>()
            .AddScoped<ICalculadoraDescontoPorFidelidade, CalculadoraDescontoPorFidelidade>()
            .AddScoped<CalculadoraDeDesconto>()
            .BuildServiceProvider();

var calculadoraDeDesconto = serviceProvider.GetService<CalculadoraDeDesconto>()
    ?? throw new InvalidOperationException("A instância de CalculadoraDeDesconto não pôde ser criada.");

decimal precoProduto = 100m;
int tempoDeContaEmAnos = 3;

decimal precoComDesconto = calculadoraDeDesconto.AplicarDesconto(precoProduto,
                                    StatusDaConta.ClientePadrao, tempoDeContaEmAnos);
Console.WriteLine($"\nCliente Padrao - Preco com Desconto: {precoComDesconto:C}");

precoComDesconto = calculadoraDeDesconto.AplicarDesconto(precoProduto,
                                    StatusDaConta.ClienteEspecial, tempoDeContaEmAnos);
Console.WriteLine($"\nCliente Especial - Preco com Desconto: {precoComDesconto:C}");

precoComDesconto = calculadoraDeDesconto.AplicarDesconto(precoProduto,
                                    StatusDaConta.ClienteOuro, tempoDeContaEmAnos);
Console.WriteLine($"\nCliente Ouro - Preco com Desconto: {precoComDesconto:C}");

precoComDesconto = calculadoraDeDesconto.AplicarDesconto(precoProduto,
                                    StatusDaConta.ClienteVIP, tempoDeContaEmAnos);
Console.WriteLine($"\nCliente VIP - Preco com Desconto: {precoComDesconto:C}");

Console.ReadKey();

