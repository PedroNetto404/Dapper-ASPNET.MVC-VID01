using System.Data;
using System.Data.SqlClient;
using Dapper;
using ListaDeContatos.WEBApp.Models.Entidades;

namespace ListaDeContatos.WEBApp.Data;

public class AcessoDados
{
    private readonly IDbConnection _dbConnection;

    public AcessoDados(IConfiguration config)
    {
        _dbConnection = new SqlConnection(config.GetConnectionString("Default")); 
    }

    public async Task<List<Pesssoa>> ObterTodasPessoas()
    {
        string query = @"
                        SELECT * 
                        FROM tb_pessoas p
                        LEFT JOIN tb_contatos_pessoa cp ON (p.Id = cp.DonoId)
                        LEFT JOIN tb_enderecos_pessoa ep ON (p.Id = ep.DonoID)
                        ";
        try
        {
            AbrirConexao();

            if (ConexaoAberta())
            {
                var response = new List<Pesssoa>();

                _ = await _dbConnection.QueryAsync<Pesssoa, Contato, Endereco, Pesssoa>
                (
                    sql: query,
                    map: (pessoa, contato, endereco) =>
                    {
                        //Vendo se já existe essa pessoa na lista
                        var pessoaNaLista = response.FirstOrDefault(p => p.Id == pessoa.Id);
                        
                        if (pessoaNaLista != null) //Caso exista alteramos o estado do item da lista
                        {
                            if(contato != null)
                                pessoaNaLista.Contatos.Add(contato);
                            if(endereco != null)
                                pessoaNaLista.Endereco.Add(endereco);
                        }
                        else //Caso exista, alteramos o estado do objeto em questão e adicionamos a lista
                        {
                            if(contato != null)
                            {
                                if (pessoa.Id == contato.DonoId)
                                    pessoa.Contatos.Add(contato);
                                
                            }
                            if (endereco != null)
                            {
                                if(pessoa.Id == endereco.Id)
                                    pessoa.Endereco.Add(endereco);
                            }
                            
                            response.Add(pessoa);
                        }
                        return pessoa;
                    }); 

            }
            else
                return null;
        }
        catch (Exception e)
        {
            return null; 
        }
        finally
        {
           FecharConexao();
        }
    }

    private void AbrirConexao()
    {
        _dbConnection.Open();
    }

    private bool ConexaoAberta()
    {
        return _dbConnection.State == ConnectionState.Open; 
    }

    private void FecharConexao()
    {
        _dbConnection.Close();
    }
}