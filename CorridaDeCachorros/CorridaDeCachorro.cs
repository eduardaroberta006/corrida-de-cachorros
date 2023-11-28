// agrupamento de código
namespace CorridaDeCachorros;

// classe pública pai
public class CorridaDeCachorro
{
    // propriedades privadas, definem o numero minimo de apostadores e corredores
    private const int NUMERO_MINIMO_DE_APOSTADORES = 5;
    private const int NUMERO_MINIMO_DE_CORREDORES = 4;

    // propriedade pública que permite retornar e/ou alterar o valor total de apostas
    public double ValorTotalDeApostas { get; set; } = 0.0;

    // propriedade pública que permite retornar a lista de apostadores e lista de corredores
    public List<Apostador> Apostadores { get; }
    public List<Corredor> Corredores { get; }

    // classes públicas que permitem retornar e/ou alterar o primeiro, segundo e terceiro colocado
    public Corredor Primeiro { get; set; }
    public Corredor Segundo { get; set; }
    public Corredor Terceiro { get; set; }

    // classes públicas que permitem retornar e/ou alterar o premio de cada colocado
    public Premio PrimeiroPremio { get; set; }
    public Premio SegundoPremio { get; set; }
    public Premio TerceiroPremio { get; set; }

    // método corrida de cachorro
    public CorridaDeCachorro
        (int numeroDeApostadores = 5,
         int numeroDeCorredores = 4
        )
    {   
        // valida se possui o número minimo de participantes
        if (numeroDeApostadores < NUMERO_MINIMO_DE_APOSTADORES)
        {
            throw new ArgumentException("No minimo é permitido 5 apostadores");
        }

        if (numeroDeCorredores < NUMERO_MINIMO_DE_CORREDORES)
        {
            throw new ArgumentException("No minimo é permitido 4 corredores");
        }

        // faz a lista dos apostadores
        Apostadores = new List<Apostador>();

        for (int i = 0; i < numeroDeApostadores; i++)
        {
            Apostadores.Add(new Apostador(i));
        }

        // faz a lista dos corredores
        Corredores = new List<Corredor>();
        for (int i = 0; i < numeroDeCorredores; i++)
        {
            Corredores.Add(new Corredor(i));
        }
    }

    // método apostar
    public void Apostar(Apostador apostador, Corredor corredor, double totalAposta)
    {
        // valida se há saldo suficiente
        if (apostador.Saldo < totalAposta)
        {
            throw new Exception("Não tem dinheiro");
        }

        // adiciona valor da aposta ao valor total de apostas
        ValorTotalDeApostas += totalAposta;
        // identifica o cachorro apostado
        apostador.CachorroApostado = corredor.Id;
        // diminui saldo do apostador
        apostador.Saldo -= totalAposta;
    }


    public void Apostar(string NomeApostador, string NomeCorredor, double totalAposta)
    {
        var apostador = Apostadores.Find(apostador => apostador.Nome.Equals(NomeApostador));
        var cachorroCorredor = Corredores.Find(corredor => corredor.Nome.Equals(NomeCorredor));

        Apostar(apostador, cachorroCorredor, totalAposta);
    }

    // método correr
    public string Correr()
    {
        // enquanto a distancia percorrida for menos ou igual a 100...
        while (Corredores.Exists(corredor =>
            corredor.DistanciaPercorrida() <= 100)
            )
        {   
            // aciona o método
            VerificarCorredoresEcorrer();
        }

        DefinirPremioGanhadores();


        return "TODO";
    }

    // método definir prêmio aos ganhadores
    public void DefinirPremioGanhadores()
    {
        // prêmio do primeiro colocado
        var apostadoresEmPrimeiro
        = Apostadores.FindAll(apostador => apostador.CachorroApostado.Equals(Primeiro.Id));
        PrimeiroPremio =
            new Premio(Posicoes.Primeiro, (ValorTotalDeApostas * 0.7), apostadoresEmPrimeiro);

        // prêmio do segundo colocado
        var apostadoresEmSegundo
            = Apostadores.FindAll(apostador => apostador.CachorroApostado.Equals(Segundo.Id));
        SegundoPremio =
            new Premio(Posicoes.Segundo, (ValorTotalDeApostas * 0.2), apostadoresEmSegundo);

        // prêmio do terceiro colocado
        var apostadoresEmTerceiro
        = Apostadores.FindAll(apostador => apostador.CachorroApostado.Equals(Terceiro.Id));
        TerceiroPremio =
            new Premio(Posicoes.Terceiro, (ValorTotalDeApostas * 0.1), apostadoresEmTerceiro);


    }

    // médoto verificar corredores e correr
    private void VerificarCorredoresEcorrer()
    {
        // define as posições dos corredores
        foreach (var corredor in Corredores)
        {
            corredor.Mover();
            if (corredor.DistanciaPercorrida() >= 100.00)
            {
                if (Primeiro is null)
                {
                    Primeiro = corredor;
                    corredor.Posicao = Posicoes.Primeiro;
                    continue;
                }
                if (Segundo is null)
                {
                    Segundo = corredor;
                    corredor.Posicao = Posicoes.Segundo;
                    continue;
                }
                if (Terceiro is null)
                {
                    Terceiro = corredor;
                    corredor.Posicao = Posicoes.Terceiro;
                    continue;
                }
                corredor.Posicao = Posicoes.NaoGanho;
            }
        }
    }
}
