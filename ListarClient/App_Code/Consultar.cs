using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descrição resumida de Consultar
/// </summary>
public class Consultar
{
    #region Variável e Instância

    // Variáveis
    public string msg = "";

    SqlCommand cmd = new SqlCommand();

    #endregion

    #region Construtor

    public Consultar()
    {

    }

    #endregion

    #region Método Listar

    public DataTable Listar(int? inicial, int? final)
    {
        DataTable oDt = new DataTable();
        SqlDataAdapter oLista = new SqlDataAdapter("select * from cadClient where id between " + inicial + " and " + final, cmd.Connection);
        oLista.Fill(oDt);
        return oDt;
    }

    #endregion

}