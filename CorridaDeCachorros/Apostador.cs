// agrupamento de código
namespace CorridaDeCachorros;

// classe filha do basemodel
public class Apostador : BaseModel
{
    // propriedade privada saldo do apostador
    private const double VALOR_INICIAL_CORRIDA = 20.0;

    // propriedades públicas que podem ser retornadas e/ou alteradas: saldo e cachorro apostado
    public double Saldo { get; set; }
    public Guid CachorroApostado { get; set; }

    // método apostador
    public Apostador(int posicaoApostador) : base()
    {
        Saldo = VALOR_INICIAL_CORRIDA;
        Nome = $"Apostador-{posicaoApostador}";
    }

    public Apostador()
    {

    }
}
