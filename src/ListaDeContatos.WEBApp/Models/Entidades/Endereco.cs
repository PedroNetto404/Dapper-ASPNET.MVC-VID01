namespace ListaDeContatos.WEBApp.Models.Entidades;

public class Endereco : EntidadeBase
{
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string  Bairro { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
    public string Cep { get; set; }

    public override string ToString()
    {
        return @$"Rua {Rua} nº {Numero}, - {Bairro} / {Estado} - {Pais} [{Cep}]"; 
    }
}