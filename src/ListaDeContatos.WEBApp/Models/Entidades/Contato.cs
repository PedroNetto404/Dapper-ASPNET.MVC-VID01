namespace ListaDeContatos.WEBApp.Models.Entidades;

public class Contato : EntidadeBase
{
    public string TipoContato { get; set; }
    public string ValorContato { get; set; }
    public Guid DonoId { get; set; }

    public override string ToString()
    {
        return $"Tipo contato: {TipoContato}, Contato: {ValorContato}"; 
    }
}