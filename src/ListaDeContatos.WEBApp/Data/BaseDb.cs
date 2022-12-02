using System.Data;
using System.Data.SqlClient;

namespace ListaDeContatos.WEBApp.Data;

public abstract class BaseDb
{
    protected readonly IDbConnection _connection;

    public BaseDb()
    {
        _connection = new SqlConnection("Data")
    }
}