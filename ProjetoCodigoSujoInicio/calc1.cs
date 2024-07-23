namespace ProjetoCodigoSujo_1Inicio;

public class calc1
{
    public decimal calculos(decimal val, int tip, int anos)
    {
        decimal res = 0;
        decimal desc = (anos > 5) ? (decimal)5 / 100 : (decimal)anos / 100;

        if (tip == 1) { res = val; }
        else if (tip == 2)
        {
            res = (val - (0.1m * val)) - desc * (val - (0.1m * val));
        }
        else if (tip == 3)
        {
            res = (0.7m * val) - desc * (0.7m * val);
        }
        else if (tip == 4)
        {
            res = (val - (0.5m * val)) - desc * (val - (0.5m * val));
        }
        return res;
    }
}
