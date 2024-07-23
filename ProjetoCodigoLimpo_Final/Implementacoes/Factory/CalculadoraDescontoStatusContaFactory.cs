using ProjetoCodigoLimpo_Final.Implementacoes.Strategy;
using ProjetoCodigoLimpo_Final.Interfaces;

namespace ProjetoCodigoLimpo_Final.Implementacoes.Factory;

public class CalculadoraDescontoStatusContaFactory : ICalculadoraDescontoStatusContaFactory
{
    public ICalculadoraDesconto GetCalculoDescontoStatusConta(StatusDaConta statusDaConta)
    {
        ICalculadoraDesconto calcular;

        switch (statusDaConta)
        {
            case StatusDaConta.ClientePadrao:
                calcular = new DescontoClientePadrao();
                break;
            case StatusDaConta.ClienteEspecial:
                calcular = new DescontoClienteEspecial();
                break;
            case StatusDaConta.ClienteOuro:
                calcular = new DescontoClienteOuro();
                break;
            case StatusDaConta.ClienteVIP:
                calcular = new DescontoClienteVIP();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return calcular;
    }
}
