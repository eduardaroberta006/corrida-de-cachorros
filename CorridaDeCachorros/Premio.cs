// agrupamento de código
namespace CorridaDeCachorros;

    // classe pública pai
public class Premio
{
    public Premio(Posicoes posicao, double valorTotal, List<Apostador> apostadores) 
    {
        // propriedades
        Posicao = posicao;
        ValorTotal = valorTotal;
        Apostadores = apostadores;
        ValorParcial = ValorTotal / Apostadores?.Count > 0 ? Apostadores.Count : 1;
        foreach (var apostador in Apostadores)
        {
            apostador.Saldo += ValorParcial;
        }
    }

    // retornar posição
    public Posicoes Posicao { get; }
    // retornar valor total
    public double ValorTotal { get; }
    // retornar valor parcial
    public double ValorParcial { get; }
    //retornar lista de apostadores
    public List<Apostador>? Apostadores { get; }

    // retorna string vazia
    public override string ToString()
    {
        return "";
    }
}
