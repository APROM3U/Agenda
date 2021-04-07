using System;
using System.Data.SqlClient;

/// <summary>
/// Descrição resumida de Conexao
/// </summary>
public class Conexao
{
    private String _StringConexao;
    private SqlConnection _Conexao;

    public Conexao(String con)
    {
        this._Conexao = new SqlConnection();
        this.StringConexao = con;
        this._Conexao.ConnectionString = con;
    }

    public String StringConexao
    {
        get { return this._StringConexao; }
        set { this._StringConexao = value; }
    }

    public SqlConnection objConex
    {
        get { return this._Conexao; }
        set { this._Conexao = value; }
    }

    public void Conectar()
    {
        this._Conexao.Open();
    }
    public void Desconectar()
    {
        this._Conexao.Close();
    }
}