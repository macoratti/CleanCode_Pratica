namespace ProjetoCodigoSujo_4SOLIDPadroes.Interfaces;

public interface ICalculadoraDescontoPorFidelidade
{
    decimal CalcularDesconto(decimal precoProduto, int tempoDaContaEmAnos);

}
