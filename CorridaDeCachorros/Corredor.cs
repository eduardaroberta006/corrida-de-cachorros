// agrupamento de código
namespace CorridaDeCachorros;

    // classe filha da classe base model
public class Corredor : BaseModel
{

    private static readonly Random Random = new();

    // propriedade privada distancia percorrida pelo cachorro
    private double _distanciaPercorrida { get; set; }

    // propriedade pública posição do cachorro
    public Posicoes Posicao { get; set; }

    // método corredor: informa a posição, zera a distância percorrida e a colocação final antes de iniciar a corrida
    public Corredor(int posicaoCorredor) : base()
    {
        Nome = $"Corredor-{posicaoCorredor}";
        _distanciaPercorrida = 0.0;
        Posicao = Posicoes.NaoGanho;
    }

    // método mover: inicia a corrida e calcula a distância percorrida pelo cachorro
    public void Mover10cm60cm()
    {
        // Os corredores podem mover aleatoriamente a cada rodada entre 10cm até 60cm
        int distanciaPercorrida = Random.Next(1, 6);

        _distanciaPercorrida += (distanciaPercorrida * 0.1);
    }

    public void Mover0cm70cm()
    {
        // Os corredores podem mover aleatoriamente a cada rodada entre 0cm até 70cm
        int distanciaPercorrida = Random.Next(0, 7);

        _distanciaPercorrida += (distanciaPercorrida * 0.1);
    }

    public void Mover30cm50cm()
    {
        // Os corredores podem mover aleatoriamente a cada rodada entre 30cm até 50cm
        int distanciaPercorrida = Random.Next(3, 5);

        _distanciaPercorrida += (distanciaPercorrida * 0.1);
    }

    public void Mover20cm40cm()
    {
        // Os corredores podem mover aleatoriamente a cada rodada entre 20cm até 40cm
        int distanciaPercorrida = Random.Next(2, 4);

        _distanciaPercorrida += (distanciaPercorrida * 0.1);
    }

    // método distancia percorrida: retorna a distância percorrida
    public double DistanciaPercorrida()
    {
        return _distanciaPercorrida;
    }
}
