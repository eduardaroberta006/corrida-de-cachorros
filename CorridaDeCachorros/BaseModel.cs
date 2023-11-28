// agrupamento de código
namespace CorridaDeCachorros;

// classe abstrata pública
public abstract class BaseModel
{
    //
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public BaseModel()
    {
        Id = Guid.NewGuid();
        Nome = string.Empty;
    }
}
