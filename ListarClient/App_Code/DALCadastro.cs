using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descrição resumida de Class1
/// </summary>
public class DALCadastro
{
    private Conexao objConex;

    public DALCadastro(Conexao conexao)
    {
        objConex = conexao;
    }

    public void Incluir(Cadastro ctt)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = objConex.objConex;
        cmd.CommandText = "insert into CadClient(nome_client, email_client, tel_client) values(@p_Nome, @p_Email, @p_Fone); select @@Identity;";
        cmd.Parameters.AddWithValue("@p_Nome", ctt.Nome);
        cmd.Parameters.AddWithValue("@p_Email", ctt.Email);
        cmd.Parameters.AddWithValue("@p_Fone", ctt.Fone);
        objConex.Conectar();
        ctt.Id = Convert.ToInt32(cmd.ExecuteScalar());
        objConex.Desconectar();
    }

    public void Alterar(Cadastro ctt)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = objConex.objConex;
        cmd.CommandText = "update CadClient set nome_client = @p_Nome, email_client = @p_Email, tel_client = @p_Fone where id = @p_Id";
        cmd.Parameters.AddWithValue("@p_Nome", ctt.Nome.ToUpper().Trim());
        cmd.Parameters.AddWithValue("@p_Email", ctt.Email.ToLower().Trim());
        cmd.Parameters.AddWithValue("@p_Fone", ctt.Fone);
        cmd.Parameters.AddWithValue("@p_Id", ctt.Id);
        objConex.Conectar();
        cmd.ExecuteNonQuery();
        objConex.Desconectar();
    }

    public void Excluir(int? id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = objConex.objConex;
        cmd.CommandText = "delete from CadClient where id = @p_Id";
        cmd.Parameters.AddWithValue("@p_Id", id);
        objConex.Conectar();
        cmd.ExecuteNonQuery();
        objConex.Desconectar();
    }

    public DataTable Pesquisar(int? inicial, int? final)
    {
        DataTable oDt = new DataTable();
        SqlDataAdapter oLista = new SqlDataAdapter("select * from cadClient where id between " + inicial + " and " + final, objConex.StringConexao);
        oLista.Fill(oDt);
        return oDt;
    }

    public Cadastro SelCadastro(int codigo)
    {
        Cadastro oCadastro = new Cadastro();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = objConex.objConex;
        cmd.CommandText = "select * from cadClient where id = " + codigo.ToString();
        objConex.Conectar();
        SqlDataReader regSel = cmd.ExecuteReader();

        if (regSel.HasRows)
        {
            regSel.Read();
            oCadastro.Id = Convert.ToInt32(regSel["id"]);
            oCadastro.Nome = Convert.ToString(regSel["nome_client"]);
            oCadastro.Email = Convert.ToString(regSel["email_client"]);
            oCadastro.Fone = Convert.ToString(regSel["tel_client"]);
        }

        return oCadastro;

    }

}