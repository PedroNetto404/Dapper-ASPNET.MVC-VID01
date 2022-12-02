namespace ListaDeContatos.WEBApp.Models.Entidades;

public abstract class EntidadeBase
{
    public Guid Id { get; private set; }

    protected EntidadeBase()
    {
        Id = Guid.NewGuid(); 
    }
}