namespace ListaDeContatos.WEBApp.Models.Entidades;

public class Pesssoa : EntidadeBase
{
    public string PrimeiroNome { get; set; }
    public string UltimoNome { get; set; }
    public string NrDocumento { get; set; }
    public DateTime DataNascimento { get; set; }
    public string FotoPerfilNomeArquivo { get; set; }
    public IFormFile FotoPerfilArquivo { get; set; }
    public List<Endereco> Endereco { get; set; }
    public List<Contato> Contatos { get; set; }

    public Pesssoa()
    {
        Contatos = new List<Contato>();
        Endereco = new List<Endereco>(); 
    }
}